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

using Antelope.Binders;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Services.Socle;
using Antelope.Services.HSE;
using Antelope.Repositories.QSE;
using Antelope.ViewModels.Socle.DataTables;
using Antelope.DTOs.QSE;
using Antelope.Models;
using Antelope.Models.QSE;

using ActionQSE = Antelope.Domain.Models.ActionQSE;

namespace Antelope.Controllers.API.QSE
{
    public class ActionQSEController : ApiController
    {
        private AntelopeEntities db = new AntelopeEntities();

        private PersonneAnnuaireService _personneAnnuaireService;

        private FicheSecuriteServices _ficheSecuriteServices;

        private ActionQSERepository _actionQSERepository;

        public PersonneAnnuaireService PersonneAnnuaireService
        {
            get
            {
                try
                {
                    if (_personneAnnuaireService == null)
                    {
                        _personneAnnuaireService = new PersonneAnnuaireService(db);
                    }
                    return _personneAnnuaireService;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public FicheSecuriteServices FicheSecuriteServices
        {
            get
            {
                if (_ficheSecuriteServices == null)
                {
                    _ficheSecuriteServices = new FicheSecuriteServices();
                }
                return _ficheSecuriteServices;
            }
        }

        public ActionQSERepository ActionQSERepository
        {
            get
            {
                if (_actionQSERepository == null)
                {
                    _actionQSERepository = new ActionQSERepository();
                }
                return _actionQSERepository;
            }
        }

        /// <summary>
        /// Obtient une liste d'actions.
        /// </summary>
        /// <param name="actionParams">Paramètres venant de datatable.</param>
        /// <returns>Message de reponse Http.</returns>
        public HttpResponseMessage Get(ActionParams actionParams)
        {
            DataTableViewModel<ActionQSEDTO> dataTableViewModel = ActionQSERepository.GetFromParams(actionParams);
            return Request.CreateResponse(HttpStatusCode.OK, dataTableViewModel);
        }

        // GET api/ActionQSE/5
        [ResponseType(typeof(ActionQSE))]
        public IHttpActionResult GetActionQSE(int id)
        {
            ActionQSE actionqse = db.ActionQSEs.Find(id);
            if (actionqse == null)
            {
                return NotFound();
            }

            return Ok(actionqse);
        }

        // PUT api/ActionQSE/5
        public HttpResponseMessage PutActionQSE(int id, ActionQSE actionqse)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Configuration.Formatters.JsonFormatter);
            }

            if (id != actionqse.ActionQSEId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Configuration.Formatters.JsonFormatter);
            }


            var currentAction = db.ActionQSEs.Find(actionqse.ActionQSEId);
            db.Entry(currentAction).CurrentValues.SetValues(actionqse);

            db.Entry(currentAction).State = EntityState.Modified;

            try
            {
                if (currentAction.ResponsableId == 0)
                {
                    currentAction.Responsable = PersonneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                        currentAction.Responsable.Nom, currentAction.Responsable.Prenom, currentAction.ResponsableId, db
                    );
                }

                if (currentAction.VerificateurId == 0)
                {
                    currentAction.Responsable = PersonneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                        currentAction.Responsable.Nom, currentAction.Responsable.Prenom, currentAction.ResponsableId, db
                    );
                }

                db.SaveChanges();

                if (currentAction.CauseQSEId != 0 && currentAction.CauseQSEId != null)
                {
                    FicheSecuriteServices.FicheSecuriteOpenOrClose(currentAction);
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionQSEExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, Configuration.Formatters.JsonFormatter);
                }
                else
                {
                    throw;
                }
            }
            // Si l'action appartient à une FS (et non une NC) >> On passe aussi la FS pour chercher la mise à jour de l'état de la FS (Workflow) dans la View.
            if (currentAction.CauseQSEId != null)
            {
                Dictionary<string, Object> Response = new Dictionary<string, Object>();

                Response.Add("FicheSecurite", currentAction.CauseQS.FicheSecurite);
                Response.Add("Action", currentAction);

                return Request.CreateResponse(HttpStatusCode.OK, Response, Configuration.Formatters.JsonFormatter);
            }
            return Request.CreateResponse(HttpStatusCode.OK, currentAction, Configuration.Formatters.JsonFormatter);
            //StatusCode(HttpStatusCode.NoContent, currentAction, Configuration.Formatters.JsonFormatter);
        }

        // POST api/ActionQSE 
        public HttpResponseMessage PostActionQSE(ActionQSE actionQSE)
        {
            actionQSE.Responsable = PersonneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(actionQSE.Responsable.Nom, actionQSE.Responsable.Prenom, actionQSE.ResponsableId, db);
            if (actionQSE.VerificateurId != 0 && actionQSE.VerificateurId != null)
            {
                actionQSE.Verificateur = PersonneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(actionQSE.Verificateur.Nom, actionQSE.Verificateur.Prenom, actionQSE.VerificateurId, db);

            }

            db.ActionQSEs.Add(actionQSE);
            db.SaveChanges();

            if (actionQSE.CauseQSEId != 0 && actionQSE.CauseQSEId != null)
            {
                FicheSecuriteServices.FicheSecuriteOpenOrClose(actionQSE);
            }

            return Request.CreateResponse<ActionQSE>(HttpStatusCode.OK, actionQSE, Configuration.Formatters.JsonFormatter);
        }

        // DELETE api/ActionQSE/5
        [ResponseType(typeof(ActionQSE))]
        public IHttpActionResult DeleteActionQSE(int id)
        {
            ActionQSE actionqse = db.ActionQSEs.Find(id);
            if (actionqse == null)
            {
                return NotFound();
            }

            db.ActionQSEs.Remove(actionqse);
            db.SaveChanges();

            if (actionqse.CauseQSEId != 0 && actionqse.CauseQSEId != null)
            {
                FicheSecuriteServices.FicheSecuriteOpenOrClose(actionqse);
            }

            return Ok(actionqse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActionQSEExists(int id)
        {
            return db.ActionQSEs.Count(e => e.ActionQSEId == id) > 0;
        }
    }
}