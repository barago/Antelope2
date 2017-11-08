using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Services.Socle;
using Antelope.Services.Socle.DataBaseHydratation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Antelope.Controllers.API.QSE
{
    public class QSEParametrageController : ApiController
    {


        private static AntelopeEntities context = new AntelopeEntities();
        private DataBaseTestHydratationService _dataBaseTestHydratationService = new DataBaseTestHydratationService();
        private DataBaseAcceptanceHydratationService _dataBaseAcceptanceHydratationService = new DataBaseAcceptanceHydratationService();
        private PersonneAnnuaireService _personneAnnuaireService = new PersonneAnnuaireService(context);

        [AcceptVerbs("GET")]
        public HttpResponseMessage GetQSEParametrage()
        {
            ParametrageQSE ParametrageQSE = context.ParametrageQSEs.FirstOrDefault();

            if (ParametrageQSE == null)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ParametrageQSE);
        }


        [AcceptVerbs("POST")]
        public HttpResponseMessage AlimenteBaseTest()
        {
            _dataBaseAcceptanceHydratationService.QSEListsAcceptanceHydrate();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [AcceptVerbs("POST")]
        public HttpResponseMessage ImportNonConformites()
        {

            List<ImportNonConformite> AllImportNonConformite = context.ImportNonConformites.ToList();

            foreach (ImportNonConformite ImportNonConformite in AllImportNonConformite){

                NonConformite NonConformite = new NonConformite() {
                    Date = ImportNonConformite.Date,
                    Description = ImportNonConformite.Description,
                    Attendu = ImportNonConformite.Attendu,
                    Cause = ImportNonConformite.Cause,
                    NonConformiteOrigineId = ImportNonConformite.NonConformiteOrigineId,
                    NonConformiteGraviteId = ImportNonConformite.NonConformiteGraviteId,
                    NonConformiteDomaineId = ImportNonConformite.NonConformiteDomaineId,
                    SiteId = ImportNonConformite.SiteId,
                    DateCreation = DateTime.Now
                };

                //-------

                NonConformite.CompteurAnnuelSite = 1;

                var QueryLastNonConformiteForSiteAnnee = from n in context.NonConformites
                                                         where n.SiteId == NonConformite.SiteId
                                                         && n.Date.Year == NonConformite.Date.Year
                                                         orderby n.CompteurAnnuelSite descending
                                                         select n;

                NonConformite LastNonConformiteForSiteAnnee = QueryLastNonConformiteForSiteAnnee.FirstOrDefault();

                if (LastNonConformiteForSiteAnnee != null)
                {
                    if (LastNonConformiteForSiteAnnee.Date.Year == NonConformite.Date.Year)
                    {
                        NonConformite.CompteurAnnuelSite = LastNonConformiteForSiteAnnee.CompteurAnnuelSite + 1;
                    }
                }

                Site site = context.Sites.First(s => s.SiteID == NonConformite.SiteId);
                NonConformite.Code += site.Trigramme + "-" + NonConformite.Date.Year + "-" + NonConformite.CompteurAnnuelSite;

                context.NonConformites.Add(NonConformite);
                context.SaveChanges();
                //-----

                var QueryImportActionforImportNonConformite = from a in context.ImportActions
                                                              where a.NonConformiteId == ImportNonConformite.Id
                                                              select a;

                List<ImportAction> AllImportAction = QueryImportActionforImportNonConformite.ToList();

                foreach (ImportAction ImportAction in AllImportAction)
                {
                    ActionQSE ActionQSE = new ActionQSE() {
                        NonConformiteId = NonConformite.Id,
                        Titre = ImportAction.Titre,
                        Description = ImportAction.Description,
                        DateButoireInitiale = ImportAction.DateButoireInitiale,
                        DateButoireNouvelle = ImportAction.DateButoireNouvelle,
                        Avancement = ImportAction.Avancement,
                        PreuveVerification = ImportAction.PreuveVerification,
                        CommentaireEfficaciteVerification = ImportAction.CommentaireEfficaciteVerification,
                        RealiseDate = ImportAction.RealiseDate,
                        VerifieDate = ImportAction.VerifieDate,
                        CritereEfficaciteVerification = ImportAction.CritereEfficaciteVerification
                    };

                    ActionQSE.Responsable = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                        ImportAction.ResponsableNom, ImportAction.ResponsablePrenom, null, context
                    );

                    ActionQSE.Verificateur = _personneAnnuaireService.GetPersonneFromAllAnnuaireOrCreate(
                        ImportAction.VerificateurNom, ImportAction.VerificateurPrenom, null, context
                    );


                    context.ActionQSEs.Add(ActionQSE);
                    context.SaveChanges();
                }

                


            }

            context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}
