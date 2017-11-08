using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Repositories.Socle;
using Antelope.ViewModels.QSE.NonConformiteViewModels;
using Antelope.ViewModels.Socle.DataTables;
using Antelope.Repositories.QSE;
using Antelope.DTOs.QSE;

namespace Antelope.Controllers.API.QSE
{
    public class NonConformiteController : ApiController
    {
        private AntelopeEntities db = new AntelopeEntities();
        public ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository { get; set; }
        public NonConformiteRepository _nonConformiteRepository { get; set; }

        // GET: api/NonConformite
        public HttpResponseMessage Get()
        {

            _nonConformiteRepository = new NonConformiteRepository();
                        
            Dictionary<string, string> DataTableParameters = new Dictionary<string, string>();
            DataTableParameters = Request.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);

            DataTableViewModel<NonConformite> DataTableViewModel = _nonConformiteRepository.GetFromParams(DataTableParameters);

            //DataTableViewModel.aaData = nonConformites;
            //DataTableViewModel.iTotalRecords = 1;
            //DataTableViewModel.iTotalDisplayRecords = 1;
            //DataTableViewModel.sEcho = int.Parse(dataTableParameters["sEcho"]);

            return Request.CreateResponse(HttpStatusCode.OK, DataTableViewModel);
        }

        // GET: api/NonConformite/5
        [ResponseType(typeof(NonConformite))]
        public HttpResponseMessage Get(int id)
        {
            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();
            _nonConformiteRepository = new NonConformiteRepository();

            NonConformite nonConformite;

            if (id == -1)
            {
                Site SiteUser = _activeDirectoryUtilisateurRepository.GetCurrentUserSite();

                nonConformite = new NonConformite()
                {
                    SiteId = (SiteUser == null) ? 0 : SiteUser.SiteID,
                    ServiceTypeId = db.ServiceTypes.Where(w => w.Nom.Equals("Qualité R/D")).Single().ServiceTypeId
                };


            }
            else
            {
                nonConformite = _nonConformiteRepository.Get(id);

                if (nonConformite == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }

            var nonConformiteViewModel = new NonConformiteViewModel(nonConformite);
            return Request.CreateResponse(HttpStatusCode.OK, nonConformiteViewModel);
        }

        // PUT: api/NonConformite/5
        [ResponseType(typeof(void))]
        public HttpResponseMessage Put(int id, NonConformite nonConformite)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (id != nonConformite.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }


            var currentNonConformite = db.NonConformites.Find(nonConformite.Id);
            db.Entry(currentNonConformite).CurrentValues.SetValues(nonConformite);

            db.Entry(currentNonConformite).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NonConformiteExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, currentNonConformite);
                }
                else
                {
                    throw;
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, currentNonConformite);
        }

        // POST: api/NonConformite
        [ResponseType(typeof(NonConformite))]
        public HttpResponseMessage Post(NonConformite nonConformite)
        {
            nonConformite.DateCreation = DateTime.Now;

            nonConformite.CompteurAnnuelSite = 1;

            var QueryLastNonConformiteForSiteAnnee = from n in db.NonConformites
                                                where n.SiteId == nonConformite.SiteId
                                                && n.Date.Year == nonConformite.Date.Year
                                                orderby n.CompteurAnnuelSite descending
                                                select n;

            NonConformite LastNonConformiteForSiteAnnee = QueryLastNonConformiteForSiteAnnee.FirstOrDefault();

            if (LastNonConformiteForSiteAnnee != null)
            {
                if (LastNonConformiteForSiteAnnee.Date.Year == nonConformite.Date.Year)
                {
                    nonConformite.CompteurAnnuelSite = LastNonConformiteForSiteAnnee.CompteurAnnuelSite + 1;
                }
            }

            Site site = db.Sites.First(s => s.SiteID == nonConformite.SiteId);
            nonConformite.Code += site.Trigramme + "-" + nonConformite.Date.Year + "-" + nonConformite.CompteurAnnuelSite;

            db.NonConformites.Add(nonConformite);

            try
            {
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, nonConformite);
            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }

        }

        // DELETE: api/NonConformite/5
        //[ResponseType(typeof(NonConformite))]
        public HttpResponseMessage Delete(int id)
        {
            NonConformite nonConformite = db.NonConformites.Find(id);
            if (nonConformite == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.NonConformites.Remove(nonConformite);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NonConformiteExists(int id)
        {
            return db.NonConformites.Count(e => e.Id == id) > 0;
        }
    }
}