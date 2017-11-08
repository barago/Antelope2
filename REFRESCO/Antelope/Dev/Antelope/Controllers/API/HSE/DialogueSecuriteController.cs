using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Models.HSE;
using Antelope.Repositories.HSE;
using Antelope.Repositories.Socle;
using Antelope.Services.HSE;
using Antelope.Services.Socle;
using Antelope.ViewModels.HSE.DialogueSecuriteViewModels;
using Antelope.ViewModels.Socle.DataTables;

namespace Antelope.Controllers.API.HSE
{
    public class DialogueSecuriteController : ApiController
    {

        public DialogueSecuriteRepository _dialogueSecuriteRepository { get; set; }
        public ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository { get; set; }
        private AntelopeEntities db = new AntelopeEntities();
        private PersonneAnnuaireService _personneAnnuaireService { get; set; }
        private EmailService _emailService { get; set; }

        public DialogueSecuriteController()
        {
            _personneAnnuaireService = new PersonneAnnuaireService(db);
            _emailService = new EmailService();
            _dialogueSecuriteRepository = new DialogueSecuriteRepository();
        }


        public HttpResponseMessage Get(DialogueSecuriteParams dialogueSecuriteParams)
        {
            DataTableViewModel<DialogueSecuriteModel> dataTableViewModel = _dialogueSecuriteRepository.GetFromParams(dialogueSecuriteParams);
            return Request.CreateResponse(HttpStatusCode.OK, dataTableViewModel);
        }

        [ResponseType(typeof(DialogueSecurite))]
        public HttpResponseMessage Get(int id)
        {
            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();
            _dialogueSecuriteRepository = new DialogueSecuriteRepository();

            DialogueSecurite dialogueSecurite;
            List<Zone> allZone;
            List<Lieu> allLieu;

            if (id == -1)
            {
                Site SiteUser = _activeDirectoryUtilisateurRepository.GetCurrentUserSite();

                dialogueSecurite = new DialogueSecurite()
                {
                    SiteId = (SiteUser == null) ? 0 : SiteUser.SiteID
                };

                var queryZone = from a in db.Zones
                                where a.SiteId == SiteUser.SiteID
                                select a;
                allZone = queryZone.ToList();

                allLieu = new List<Lieu>(); 
            }
            else
            {
                dialogueSecurite = _dialogueSecuriteRepository.Get(id);

                if (dialogueSecurite == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                var queryZone = from a in db.Zones
                                where a.SiteId == dialogueSecurite.SiteId
                                select a;
                allZone = queryZone.ToList();

                var queryLieu = from a in db.Lieux
                                where a.ZoneId == dialogueSecurite.ZoneId
                                orderby a.Rang
                                select a;
                allLieu = queryLieu.ToList();
            }

            var dialogueSecuriteViewModel = new DialogueSecuriteViewModel(dialogueSecurite, allZone, allLieu);
            return Request.CreateResponse(HttpStatusCode.OK, dialogueSecuriteViewModel);
        }

        [ResponseType(typeof(void))]
        public HttpResponseMessage Put(int id, DialogueSecurite dialogueSecurite)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (id != dialogueSecurite.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }


            var currentdialogueSecurite = db.DialogueSecurites.Find(dialogueSecurite.Id);
            db.Entry(currentdialogueSecurite).CurrentValues.SetValues(dialogueSecurite);

            db.Entry(currentdialogueSecurite).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DialogueSecuriteExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, currentdialogueSecurite);
                }
                else
                {
                    throw;
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, currentdialogueSecurite);
        }


        public HttpResponseMessage Post(DialogueSecurite dialogueSecurite)
        {
            // DialogueSecurite.DateCreation = DateTime.Now;

            dialogueSecurite.CompteurAnnuelSite = 1;

            var QueryLastDialogueSecuriteForSiteAnnee = from ds in db.DialogueSecurites
                                                        where ds.SiteId == dialogueSecurite.SiteId
                                                     && ds.Date.Year == dialogueSecurite.Date.Year
                                                        orderby ds.CompteurAnnuelSite descending
                                                        select ds;

            DialogueSecurite LastDialogueSecuriteForSiteAnnee = QueryLastDialogueSecuriteForSiteAnnee.FirstOrDefault();

            if (LastDialogueSecuriteForSiteAnnee != null)
            {
                if (LastDialogueSecuriteForSiteAnnee.Date.Year == dialogueSecurite.Date.Year)
                {
                    dialogueSecurite.CompteurAnnuelSite = LastDialogueSecuriteForSiteAnnee.CompteurAnnuelSite + 1;
                }
            }

            Site site = db.Sites.First(s => s.SiteID == dialogueSecurite.SiteId);
            dialogueSecurite.Code += site.Trigramme + "-" + dialogueSecurite.Date.Year + "-" + dialogueSecurite.CompteurAnnuelSite;

            dialogueSecurite.Dialogueur1 = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                dialogueSecurite.Dialogueur1.Nom, dialogueSecurite.Dialogueur1.Prenom, dialogueSecurite.Dialogueur1Id, db
            );
            dialogueSecurite.Dialogueur2 = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                dialogueSecurite.Dialogueur2.Nom, dialogueSecurite.Dialogueur2.Prenom, dialogueSecurite.Dialogueur2Id, db
            );
            dialogueSecurite.Dialogueur3 = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                dialogueSecurite.Dialogueur3.Nom, dialogueSecurite.Dialogueur3.Prenom, dialogueSecurite.Dialogueur3Id, db
            );
            dialogueSecurite.Entretenu1 = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                dialogueSecurite.Entretenu1.Nom, dialogueSecurite.Entretenu1.Prenom, dialogueSecurite.Entretenu1Id, db
            );
            dialogueSecurite.Entretenu2 = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                dialogueSecurite.Entretenu2.Nom, dialogueSecurite.Entretenu2.Prenom, dialogueSecurite.Entretenu2Id, db
            );
            dialogueSecurite.Entretenu3 = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                dialogueSecurite.Entretenu3.Nom, dialogueSecurite.Entretenu3.Prenom, dialogueSecurite.Entretenu3Id, db
            );

            db.DialogueSecurites.Add(dialogueSecurite);

            //try
            //{
            db.SaveChanges();
            DialogueSecurite dbDialogueSecurite = db.DialogueSecurites
                .Where(ds => ds.Id == dialogueSecurite.Id)
                .Include(ds => ds.Thematique)
                .Include(ds => ds.ServiceType)
                .Include(ds => ds.ServiceType1)
                .Include(ds => ds.ServiceType2)
                .Include(ds => ds.ServiceType3)
                .Include(ds => ds.ServiceType4)
                .Include(ds => ds.ServiceType5)
                .FirstOrDefault();

            _emailService.SendEmailDiffusionDialogueSecurite(dbDialogueSecurite);
            return Request.CreateResponse(HttpStatusCode.OK, dbDialogueSecurite);
            //}
            //catch (Exception e)
            //{
            //    return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            //}

        }

        public HttpResponseMessage Delete(int id)
        {
            DialogueSecurite dialogueSecurite = db.DialogueSecurites.Find(id);
            if (dialogueSecurite == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.DialogueSecurites.Remove(dialogueSecurite);
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

        private bool DialogueSecuriteExists(int id)
        {
            return db.DialogueSecurites.Count(e => e.Id == id) > 0;
        }
    }
}