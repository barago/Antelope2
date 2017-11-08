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
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

using Antelope.Binders;
using Antelope.Domain.Models;
using Antelope.DTOs.QSE;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Models;
using Antelope.Models.QSE;
using Antelope.Repositories.QSE;
using Antelope.Repositories.Socle;
using Antelope.ViewModels.QSE.NonConformiteViewModels;
using Antelope.ViewModels.Socle.DataTables;

namespace Antelope.Controllers.API.QSE
{
    public class NonConformiteController : ApiController
    {
        private AntelopeEntities db = new AntelopeEntities();
        private NonConformiteRepository _nonConformiteRepository;
        private ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository;


        /// <summary>
        /// Obtient les non conformité selon le filtre fournit.
        /// </summary>
        /// <param name="nonConformiteParams">Filtre datatable pour les non conformités.</param>
        /// <returns>Message de reponse Http.</returns>
        public HttpResponseMessage Get(NonConformiteParams nonConformiteParams)
        {
            DataTableViewModel<NonConformite> dataTableViewModel = NonConformiteRepository.GetFromParams(nonConformiteParams);
            return Request.CreateResponse(HttpStatusCode.OK, dataTableViewModel);
        }

        // GET: api/NonConformite/5
        [ResponseType(typeof(NonConformite))]
        public HttpResponseMessage Get(int id)
        {
            NonConformite nonConformite;

            if (id == -1)
            {
                Site SiteUser = ActiveDirectoryUtilisateurRepository.GetCurrentUserSite();

                nonConformite = new NonConformite()
                {
                    SiteId = (SiteUser == null) ? 0 : SiteUser.SiteID,
                    ServiceTypeId = db.ServiceTypes.Where(w => w.Nom.Equals("Qualité R/D")).Single().ServiceTypeId
                };
            }
            else
            {
                nonConformite = NonConformiteRepository.Get(id);

                if (nonConformite == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }

            var nonConformiteViewModel = new NonConformiteViewModel(nonConformite);
            return Request.CreateResponse(HttpStatusCode.OK, nonConformiteViewModel);
        }

        public ActiveDirectoryUtilisateurRepository ActiveDirectoryUtilisateurRepository
        {
            get
            {
                if (_activeDirectoryUtilisateurRepository == null)
                {
                    _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();
                }
                return _activeDirectoryUtilisateurRepository;
            }
        }
        public NonConformiteRepository NonConformiteRepository
        {
            get
            {
                if (_nonConformiteRepository == null)
                {
                    _nonConformiteRepository = new NonConformiteRepository();
                }
                return _nonConformiteRepository;
            }
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