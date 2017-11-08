using Antelope.Domain.Models;
using Antelope.Repositories.HSE;
using Antelope.ViewModels.HSE.FicheSecuriteViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Text;
using System.Threading;
using Antelope.Repositories.Socle;
using Antelope.DTOs.Socle;
using Antelope.Services.Socle;
using Antelope.Services.HSE;
using Antelope.Infrastructure.EntityFramework;
using System.Web.Mvc;
using System.Web;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Antelope.ViewModels.Socle.DataTables;
using Antelope.DTOs.HSE;
using Antelope.Models.HSE;

using FicheSecurite = Antelope.Domain.Models.FicheSecurite;

namespace Antelope.Controllers.API.HSE
{
    public class FicheSecuriteController : ApiController
    {
        private AntelopeEntities db = new AntelopeEntities();
        public FicheSecuriteRepository _ficheSecuriteRepository { get; set; }
        public PersonneRepository _personneRepository { get; set; }
        public ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository { get; set; }
        private PersonneAnnuaireService _personneAnnuaireService { get; set; }
        private EmailService _emailService { get; set; }


        public FicheSecuriteController()
        {

            _ficheSecuriteRepository = new FicheSecuriteRepository();
            _personneRepository = new PersonneRepository();
            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();
            _personneAnnuaireService = new PersonneAnnuaireService(db);
            _emailService = new EmailService();
        }

        // GET api/fichesecuriteapi
        public HttpResponseMessage Get(FicheSecuriteParams ficheSecuriteParams)
        {

            if (ficheSecuriteParams.RechercheType == "FICHESECURITE")
            {
                var dataTableViewModelForFicheSecurite = _ficheSecuriteRepository.GetAllFicheSecuriteFromParams(ficheSecuriteParams);
                return Request.CreateResponse(HttpStatusCode.OK, dataTableViewModelForFicheSecurite);
            }
            if (ficheSecuriteParams.RechercheType == "ACTION")
            {
                var dataTableViewModelForAction = _ficheSecuriteRepository.GetAllActionFromParams(ficheSecuriteParams);
                return Request.CreateResponse(HttpStatusCode.OK, dataTableViewModelForAction);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [System.Web.Http.ActionName("ActionColumns")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetActionColumns(FicheSecuriteParams ficheSecuriteParams)
        {
            List<string> columns = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                StringBuilder javascriptBuilder = new StringBuilder(" { ");
                javascriptBuilder.AppendLine("'visible': false, ");
                javascriptBuilder.AppendLine($"'sTitle': 'Action{i}', ");
                javascriptBuilder.AppendLine("'mData': function(data, type, val) { ");
                javascriptBuilder.AppendLine($"if (data.Actions.length > {i}) ");
                javascriptBuilder.AppendLine($"{{ return data.Actions[{i}]; }} ");
                javascriptBuilder.AppendLine(" return ''; ");
                javascriptBuilder.AppendLine(" } ");
                javascriptBuilder.AppendLine(" } ");
                columns.Add(javascriptBuilder.ToString());
            }

            Dictionary<string, object> response = new Dictionary<string, object>
            {
                { "columns", $"[{string.Join(",",columns)}]" }
            };

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // GET api/fichesecuriteapi/5
        public HttpResponseMessage Get(int id)
        {
            var boo = User.Identity.IsAuthenticated;
            var z = User.Identity.GetUserId();
            var p = 1;

            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();

            FicheSecurite ficheSecurite;
            List<Zone> AllZone;
            List<Lieu> AllLieu;
            List<Service> AllService;
            List<PosteDeTravail> AllPosteDeTravail;

            // Si l'ID = -1 >> Nouvelle Fiche

            if (id == -1)
            {

                Site SiteUser = _activeDirectoryUtilisateurRepository.GetCurrentUserSite();

                ficheSecurite = new FicheSecurite()
                {
                    CotationFrequence = 1,
                    CotationGravite = 1,
                    SiteId = SiteUser.SiteID,
                    WorkFlowDiffusee = false,
                    WorkFlowAttenteASEValidation = false,
                    WorkFlowASEValidee = false,
                    WorkFlowASERejetee = false,
                    WorkFlowCloturee = false
                };

                var queryZone = from a in db.Zones
                                where a.SiteId == SiteUser.SiteID
                                select a;
                AllZone = queryZone.ToList();

                AllLieu = new List<Lieu>();

                var queryService = from a in db.Services
                                   where a.SiteId == SiteUser.SiteID
                                   select a;
                AllService = queryService.ToList();

                AllPosteDeTravail = new List<PosteDeTravail>();


            }
            // Si l'ID != -1 >> Fiche existante
            else
            {

                ficheSecurite = _ficheSecuriteRepository.Get(id);

                if (ficheSecurite == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                var queryZone = from a in db.Zones
                                where a.SiteId == ficheSecurite.SiteId
                                select a;
                AllZone = queryZone.ToList();

                var queryLieu = from a in db.Lieux
                                where a.ZoneId == ficheSecurite.ZoneId
                                orderby a.Rang
                                select a;
                AllLieu = queryLieu.ToList();

                var queryService = from a in db.Services
                                   where a.SiteId == ficheSecurite.SiteId
                                   select a;
                AllService = queryService.ToList();

                var queryPosteDeTravail = from a in db.PosteDeTravails
                                          where a.ZoneId == ficheSecurite.ZoneId
                                          orderby a.Rang
                                          select a;
                AllPosteDeTravail = queryPosteDeTravail.ToList();

            }



            var ficheSecuriteViewModel = new FicheSecuriteViewModel(ficheSecurite, AllZone, AllLieu, AllService, AllPosteDeTravail);
            return Request.CreateResponse(HttpStatusCode.OK, ficheSecuriteViewModel);
        }

        private static void SendMailThread(MailMessage mail, SmtpClient smtp)
        {

            smtp.Send(mail);

        }

        // POST api/fichesecuriteapi
        public HttpResponseMessage Post(FicheSecurite FicheSecurite)
        {

            FicheSecurite.DateCreation = DateTime.Now;

            FicheSecurite.CompteurAnnuelSite = 1;

            var QueryLastFicheSecuriteForSiteAnnee = from f in db.FicheSecurites
                                                     where f.SiteId == FicheSecurite.SiteId
                                                     && f.DateEvenement.Year == FicheSecurite.DateEvenement.Year
                                                     orderby f.CompteurAnnuelSite descending
                                                     select f;

            FicheSecurite LastFicheSecuriteForSiteAnnee = QueryLastFicheSecuriteForSiteAnnee.FirstOrDefault();

            if (LastFicheSecuriteForSiteAnnee != null)
            {
                if (LastFicheSecuriteForSiteAnnee.DateEvenement.Year == FicheSecurite.DateEvenement.Year)
                {
                    FicheSecurite.CompteurAnnuelSite = LastFicheSecuriteForSiteAnnee.CompteurAnnuelSite + 1;
                }
            }

            Site site = db.Sites.First(s => s.SiteID == FicheSecurite.SiteId);
            FicheSecurite.Code += site.Trigramme + "-" + FicheSecurite.DateEvenement.Year + "-" + FicheSecurite.CompteurAnnuelSite;

            FicheSecurite.Responsable = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                FicheSecurite.Responsable.Nom, FicheSecurite.Responsable.Prenom, FicheSecurite.ResponsableId, db
                );
            FicheSecurite.PersonneConcernee = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                FicheSecurite.PersonneConcernee.Nom, FicheSecurite.PersonneConcernee.Prenom, FicheSecurite.PersonneConcerneeId, db
                ); ;

            FicheSecurite.WorkFlowDiffusee = true;

            db.FicheSecurites.Add(FicheSecurite);

            //try
            //{
            db.SaveChanges();

            //Url.Action("Edit", "FicheSecurite", new System.Web.Routing.RouteValueDictionary(new { id = id }), "http", Request.Url.Host)
            //Url.Link("DefaultApi", new { controller = "Albums", id = 3})
            //UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            //var a = url.Action("Edit", "FicheSecurite", new System.Web.Routing.RouteValueDictionary(new { id = FicheSecurite.FicheSecuriteID }), "http", HttpContext.Current.Request.Url.Host);  

            _emailService.SendEmailDiffusionFicheSecurite(FicheSecurite);

            return Request.CreateResponse(HttpStatusCode.OK, FicheSecurite);
            //}
            //catch (Exception e)
            //{


            //return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            //}

        }

        [System.Web.Http.AcceptVerbs("POST", "PUT")]
        public HttpResponseMessage ChangeWorkFlowEtat(FicheSecurite ficheSecurite, Int32 id, string param1)
        {

            FicheSecurite FicheSecurite = _ficheSecuriteRepository.Get(id);

            switch (param1)
            {
                case "AttenteASEValidation":
                    FicheSecurite.WorkFlowASEValidee = false;
                    FicheSecurite.WorkFlowASERejetee = false;
                    FicheSecurite.WorkFlowAttenteASEValidation = true;
                    FicheSecurite.WorkFlowFicheSecuriteCloturee = false;
                    _emailService.SendEmailDiffusionPlanActionFicheSecurite(ficheSecurite);
                    break;
                case "ASEValidee":
                    FicheSecurite.WorkFlowAttenteASEValidation = false;
                    FicheSecurite.WorkFlowASEValidee = true;
                    FicheSecurite.WorkFlowASERejetee = false;
                    FicheSecurite.WorkFlowFicheSecuriteCloturee = false;
                    _emailService.SendEmailValidationPlanActionFicheSecurite(ficheSecurite);
                    break;
                case "ASERejetee":
                    FicheSecurite.WorkFlowAttenteASEValidation = false;
                    FicheSecurite.WorkFlowASEValidee = false;
                    FicheSecurite.WorkFlowASERejetee = true;
                    FicheSecurite.WorkFlowASERejeteeCause = ficheSecurite.WorkFlowASERejeteeCause;
                    FicheSecurite.WorkFlowFicheSecuriteCloturee = false;
                    _emailService.SendEmailRejetPlanActionFicheSecurite(ficheSecurite);
                    break;
                case "ASEFicheSecuriteCloturee":
                    FicheSecurite.WorkFlowAttenteASEValidation = false;
                    FicheSecurite.WorkFlowASEValidee = true;
                    FicheSecurite.WorkFlowASERejetee = false;
                    FicheSecurite.WorkFlowFicheSecuriteCloturee = true;
                    // _emailService.SendEmailRejetPlanActionFicheSecurite(ficheSecurite); TODO : Voir si il faut un email à cette étape
                    break;
                case "ASEFicheSecuriteOuvrir":
                    FicheSecurite.WorkFlowAttenteASEValidation = false;
                    FicheSecurite.WorkFlowASEValidee = true;
                    FicheSecurite.WorkFlowASERejetee = false;
                    FicheSecurite.WorkFlowFicheSecuriteCloturee = false;
                    // _emailService.SendEmailRejetPlanActionFicheSecurite(ficheSecurite); TODO : Voir si il faut un email à cette étape
                    break;
            }

            _ficheSecuriteRepository._db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, FicheSecurite);
        }

        // PUT api/fichesecuriteapi/5
        [System.Web.Http.AcceptVerbs("PUT")]
        public HttpResponseMessage Put(int id, FicheSecurite ficheSecurite)
        {

            var currentFicheSecurite = db.FicheSecurites.Find(ficheSecurite.FicheSecuriteID);
            db.Entry(currentFicheSecurite).CurrentValues.SetValues(ficheSecurite);

            db.Entry(currentFicheSecurite).State = EntityState.Modified;


            db.SaveChanges();


            return Request.CreateResponse(HttpStatusCode.OK, currentFicheSecurite);


        }

        // PUT api/fichesecuriteapi/5
        [System.Web.Http.AcceptVerbs("POST", "PUT")]
        public HttpResponseMessage PutCHSCTFields(FicheSecurite ficheSecurite, Int32 id, string param1)
        {

            FicheSecurite ficheSecuriteToEdit = db.FicheSecurites.Find(ficheSecurite.FicheSecuriteID);

            ficheSecuriteToEdit.EnqueteDate = ficheSecurite.EnqueteDate;
            ficheSecuriteToEdit.EnqueteProtagoniste = ficheSecurite.EnqueteProtagoniste;
            ficheSecuriteToEdit.EnqueteRealisee = ficheSecurite.EnqueteRealisee;
            ficheSecuriteToEdit.CHSCTMembre = ficheSecurite.CHSCTMembre;


            //db.Entry(ficheSecurite).State = EntityState.Modified;


            db.SaveChanges();


            return Request.CreateResponse(HttpStatusCode.OK);


        }



        // DELETE api/fichesecuriteapi/5
        public HttpResponseMessage Delete(int id)
        {

            FicheSecurite FicheSecurite = db.FicheSecurites.Find(id);
            if (FicheSecurite == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.FicheSecurites.Remove(FicheSecurite);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
