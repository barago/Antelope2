using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using Antelope.ViewModels.Socle.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Binbin.Linq;
using System.Linq.Dynamic;
using Antelope.DTOs.QSE;

namespace Antelope.Repositories.QSE
{
    public class ActionQSERepository
    {

        public AntelopeEntities _db { get; set; }

        public ActionQSERepository() : this(new AntelopeEntities())
        {

        }

        public ActionQSERepository(AntelopeEntities db)
        {
            _db = db;
        }

        public ActionQSE Get(Int32 id)
        {
            ActionQSE ActionQSE = _db.ActionQSEs.SingleOrDefault(r => r.ActionQSEId == id);
            return ActionQSE;
        }

        public DataTableViewModel<ActionQSEDTO> GetFromParams(Dictionary<string, string> DataTableParameters)
        {

            Int32 ParameterStart = Int32.Parse(DataTableParameters["start"]);
            Int32 ParameterLength = Int32.Parse(DataTableParameters["length"]);
            Int32 ParameterSiteId = Int32.Parse(DataTableParameters["siteId"]);
            Int32 ParameterServiceTypeId = Int32.Parse(DataTableParameters["serviceTypeId"]);
            Int32 ParameterOrigineId = Int32.Parse(DataTableParameters["nonConformiteOrigineId"]);
            Int32 ParameterGraviteId = Int32.Parse(DataTableParameters["nonConformiteGraviteId"]);
            Int32 ParameterDomaineId = Int32.Parse(DataTableParameters["nonConformiteDomaineId"]);
            Boolean ParameterIsActionEnCours = Convert.ToBoolean(DataTableParameters["isActionEnCours"]);
            Boolean ParameterIsActionRealise = Convert.ToBoolean(DataTableParameters["isActionRealise"]);
            Boolean ParameterIsActionRetard = Convert.ToBoolean(DataTableParameters["isActionRetard"]);
            Boolean ParameterIsActionCloture = Convert.ToBoolean(DataTableParameters["isActionCloture"]);
            Boolean ParameterIsColonne1Ordonnee = false;
            String ParameterColonne1Sens = null;
            Boolean ParameterIsColonne3Ordonnee = false;
            String ParameterColonne3Sens = null;
            Boolean ParameterIsColonne4Ordonnee = false;
            String ParameterColonne4Sens = null;

            String ParameterResponsableNom = DataTableParameters["responsableNom"];
            DateTime? ParameterDateButoirDebut = null;
            DateTime? ParameterDateButoirFin = null;

            if (DataTableParameters["order[0].column"] == "1")
            {
                ParameterIsColonne1Ordonnee = true;
                ParameterColonne1Sens = DataTableParameters["order[0].dir"];
            }
            if (DataTableParameters["order[0].column"] == "3")
            {
                ParameterIsColonne3Ordonnee = true;
                ParameterColonne3Sens = DataTableParameters["order[0].dir"];
            }
            if (DataTableParameters["order[0].column"] == "4")
            {
                ParameterIsColonne4Ordonnee = true;
                ParameterColonne4Sens = DataTableParameters["order[0].dir"];
            }
            if (DataTableParameters["dateButoirDebut"] != "")
            {
                try
                {
                    ParameterDateButoirDebut = DateTime.Parse(DataTableParameters["dateButoirDebut"]);
                }
                catch (Exception e)
                {

                }
            }
            if (DataTableParameters["dateButoirFin"] != "")
            {
                try
                {
                    ParameterDateButoirFin = DateTime.Parse(DataTableParameters["dateButoirFin"]);
                }
                catch (Exception e)
                {

                }
            }

            IQueryable<ActionQSEDTO> queryActionQSE = from a in _db.ActionQSEs
                                                   join nc in _db.NonConformites on a.NonConformiteId equals nc.Id
                                                      orderby nc.Date
                                                   select new ActionQSEDTO () { 
                                                        ActionQSEId = a.ActionQSEId,
                                                        Titre = a.Titre,
                                                        Description = a.Description,
                                                        DateButoireInitiale = a.DateButoireInitiale,
                                                        DateButoireNouvelle = a.DateButoireNouvelle,
                                                        NonConformiteId = a.NonConformiteId,
                                                        Responsable = a.Responsable,
                                                        Verificateur = a.Verificateur,
                                                        NonConformite = a.NonConformite,
                                                        RealiseDate = a.RealiseDate,
                                                        VerifieDate = a.VerifieDate,
                                                        ClotureDate = a.ClotureDate,
                                                        Avancement = a.Avancement,
                                                        CritereEfficaciteVerification = a.CritereEfficaciteVerification,
                                                        CommentaireEfficaciteVerification = a.CommentaireEfficaciteVerification
                                                   };

            queryActionQSE = queryActionQSE.Where(q => q.NonConformiteId != null);

            String WorkFlowWhereClause = "";
            Boolean FirstWorkFlowPredicate = false;

            if (ParameterIsActionEnCours == false || ParameterIsActionRealise == false || ParameterIsActionRetard == false || ParameterIsActionCloture == false)
            {
                if (ParameterIsActionEnCours == true)
                {
                    FirstWorkFlowPredicate = true;
                    // (realiseDate && DateTime && DatebutoirNouvelle != NULL) || (realiseDate && DateTime && DatebutoirNouvelle == NULL)
                    WorkFlowWhereClause += "((RealiseDate == null && DateTime.Today <= DateButoireInitiale && DateButoireNouvelle == null) || (RealiseDate == null && DateTime.Today <= DateButoireInitiale && DateTime.Today <= DateButoireNouvelle ))";
                }
                if (ParameterIsActionRealise == true)
                {
                    if (FirstWorkFlowPredicate == true)
                    {
                        WorkFlowWhereClause += "|| ";
                    }
                    WorkFlowWhereClause += "(RealiseDate != null && VerifieDate == null )";
                    FirstWorkFlowPredicate = true;
                }
                if (ParameterIsActionRetard == true)
                {
                    if (FirstWorkFlowPredicate == true)
                    {
                        WorkFlowWhereClause += "|| ";
                    }
                    WorkFlowWhereClause += "(RealiseDate == null && DateTime.Today > DateButoireNouvelle && VerifieDate == null)";
                    FirstWorkFlowPredicate = true;
                }
                if (ParameterIsActionCloture == true)
                {
                    if (FirstWorkFlowPredicate == true)
                    {
                        WorkFlowWhereClause += "|| ";
                    }
                    WorkFlowWhereClause += "(RealiseDate != null && VerifieDate != null)";
                    FirstWorkFlowPredicate = true;
                }
                if (WorkFlowWhereClause != "")
                {
                    queryActionQSE = queryActionQSE.Where(WorkFlowWhereClause);
                }
            }

            if (ParameterSiteId != null && ParameterSiteId != 0)
            {
                queryActionQSE = queryActionQSE.Where(q => q.NonConformite.SiteId == ParameterSiteId);
            }
            if (ParameterServiceTypeId != null && ParameterServiceTypeId != 0)
            {
                queryActionQSE = queryActionQSE.Where(q => q.NonConformite.ServiceTypeId == ParameterServiceTypeId);
            }
            if (ParameterOrigineId != null && ParameterOrigineId != 0)
            {
                queryActionQSE = queryActionQSE.Where(q => q.NonConformite.NonConformiteOrigineId == ParameterOrigineId);
            }
            if (ParameterGraviteId != null && ParameterGraviteId != 0)
            {
                queryActionQSE = queryActionQSE.Where(q => q.NonConformite.NonConformiteGraviteId == ParameterGraviteId);
            }
            if (ParameterDomaineId != null && ParameterDomaineId != 0)
            {
                queryActionQSE = queryActionQSE.Where(q => q.NonConformite.NonConformiteDomaineId == ParameterDomaineId);
            }
            if (ParameterResponsableNom != null && ParameterResponsableNom != "")
            {
                queryActionQSE = queryActionQSE.Where(q => q.Responsable.Nom == ParameterResponsableNom);
            }
            if (ParameterDateButoirDebut != null)
            {
                queryActionQSE = queryActionQSE.Where(
                    q => q.DateButoireInitiale >= ParameterDateButoirDebut 
                        || q.DateButoireNouvelle >= ParameterDateButoirDebut
                        );
            }
            if (ParameterDateButoirFin != null)
            {
                queryActionQSE = queryActionQSE.Where(
                    q => q.DateButoireInitiale <= ParameterDateButoirFin
                        || q.DateButoireNouvelle <= ParameterDateButoirFin
                        );
          
            }

            int RecordsFiltered = queryActionQSE.Count();
            int RecordsTotal = _db.ActionQSEs.Count();

            if (ParameterIsColonne1Ordonnee == true)
            {
                switch (ParameterColonne1Sens)
                {
                    case "asc":
                        queryActionQSE = queryActionQSE.OrderBy(q => q.NonConformite.CompteurAnnuelSite);
                        break;
                    case "desc":
                        queryActionQSE = queryActionQSE.OrderByDescending(q => q.NonConformite.CompteurAnnuelSite);
                        break;
                }
            }
            if (ParameterIsColonne3Ordonnee == true)
            {
                switch (ParameterColonne3Sens)
                {
                    case "asc":
                        queryActionQSE = queryActionQSE.OrderBy(q => q.Responsable.Nom);
                        break;
                    case "desc":
                        queryActionQSE = queryActionQSE.OrderByDescending(q => q.Responsable.Nom);
                        break;
                }
            }
            if (ParameterIsColonne4Ordonnee == true)
            {
                switch (ParameterColonne4Sens)
                {
                    case "asc":
                        queryActionQSE = queryActionQSE.OrderBy(q => q.DateButoireInitiale);
                        break;
                    case "desc":
                        queryActionQSE = queryActionQSE.OrderByDescending(q => q.DateButoireInitiale);
                        break;
                }
            }

            if (ParameterLength != -1)
            {
                queryActionQSE = queryActionQSE.Skip(ParameterStart).Take(ParameterLength);
            }
            List<ActionQSEDTO> AllActionQSE = queryActionQSE.ToList();

            DataTableViewModel<ActionQSEDTO> DataTableViewModel = new DataTableViewModel<ActionQSEDTO>()
            {
                recordsTotal = RecordsTotal,
                recordsFiltered = RecordsFiltered,
                data = AllActionQSE
            };

            return DataTableViewModel;

        }

        public DataTableViewModel<FicheSecurite> GetFromParams2(Dictionary<string, string> DataTableParameters)
        {


            Int32 ParameterStart = Int32.Parse(DataTableParameters["start"]);
            Int32 ParameterLength = Int32.Parse(DataTableParameters["length"]);
            Int32 ParameterSiteId = Int32.Parse(DataTableParameters["siteId"]);
            Int32 ParameterZoneId = Int32.Parse(DataTableParameters["zoneId"]);
            Int32 ParameterLieuId = Int32.Parse(DataTableParameters["lieuId"]);
            Int32 ParameterTypeId = Int32.Parse(DataTableParameters["typeId"]);
            String ParameterCode = DataTableParameters["Code"];
            String ParameterAge = DataTableParameters["Age"];
            Int32 ParameterPosteDeTravailId = Int32.Parse(DataTableParameters["posteDeTravailId"]);
            Int32 ParameterServiceId = Int32.Parse(DataTableParameters["serviceId"]);
            String ParameterPersonneConcerneeNom = DataTableParameters["personneConcerneeNom"];
            String ParameterResponsableNom = DataTableParameters["responsableNom"];
            Int32 ParameterCotationFrequence = (DataTableParameters["cotationFrequence"] == "") ? 0 : Int32.Parse(DataTableParameters["cotationFrequence"]);
            Int32 ParameterCotationGravite = (DataTableParameters["cotationGravite"] == "") ? 0 : Int32.Parse(DataTableParameters["cotationGravite"]);
            Int32 ParameterRisqueId = Int32.Parse(DataTableParameters["risqueId"]);
            Int32 ParameterDangerId = Int32.Parse(DataTableParameters["dangerId"]);
            Int32 ParameterCorpsHumainZoneId = Int32.Parse(DataTableParameters["corpsHumainZoneId"]);
            Int32 ParameterPlageHoraireId = Int32.Parse(DataTableParameters["plageHoraireId"]);
            DateTime? ParameterDateEvenementDebut = null;
            DateTime? ParameterDateEvenementFin = null;
            Boolean ParameterIsNouvelleFiche = Convert.ToBoolean(DataTableParameters["isNouvelleFiche"]);
            Boolean ParameterIsPlanActionValide = Convert.ToBoolean(DataTableParameters["isPlanActionValide"]);
            Boolean ParameterIsPlanActionAttente = Convert.ToBoolean(DataTableParameters["isPlanActionAttente"]);
            Boolean ParameterIsPlanActionRejete = Convert.ToBoolean(DataTableParameters["isPlanActionRejete"]);
            Boolean ParameterIsPlanActionCloture = Convert.ToBoolean(DataTableParameters["isPlanActionCloture"]);
            //Guid ParameterResponsableGuid = Guid.Parse(DataTableParameters["responsableGuid"]);
            Boolean ParameterIsColonne1Ordonnee = Convert.ToBoolean(Int32.Parse(DataTableParameters["order[0].column"]));
            String ParameterColonne1Sens = DataTableParameters["order[0].dir"];
            DateTime? ParameterDateButoirDebut = null;
            DateTime? ParameterDateButoirFin = null;
            DateTime? ParameterDateClotureDebut = null;
            DateTime? ParameterDateClotureFin = null;


            if (DataTableParameters["dateEvenementDebut"] != "")
            {
                try
                {
                    ParameterDateEvenementDebut = DateTime.Parse(DataTableParameters["dateEvenementDebut"]);
                }
                catch (Exception e)
                {

                }
            }
            if (DataTableParameters["dateEvenementFin"] != "")
            {
                try
                {
                    ParameterDateEvenementFin = DateTime.Parse(DataTableParameters["dateEvenementFin"]);
                }
                catch (Exception e)
                {

                }
            }
            if (DataTableParameters["dateButoirDebut"] != "")
            {
                try
                {
                    ParameterDateButoirDebut = DateTime.Parse(DataTableParameters["dateButoirDebut"]);
                }
                catch (Exception e)
                {

                }
            }
            if (DataTableParameters["dateButoirFin"] != "")
            {
                try
                {
                    ParameterDateButoirFin = DateTime.Parse(DataTableParameters["dateButoirFin"]);
                }
                catch (Exception e)
                {

                }
            }
            if (DataTableParameters["dateClotureDebut"] != "")
            {
                try
                {
                    ParameterDateClotureDebut = DateTime.Parse(DataTableParameters["dateClotureDebut"]);
                }
                catch (Exception e)
                {

                }
            }
            if (DataTableParameters["dateClotureFin"] != "")
            {
                try
                {
                    ParameterDateClotureFin = DateTime.Parse(DataTableParameters["dateClotureFin"]);
                }
                catch (Exception e)
                {

                }
            }
            String ParameterResponsbaleNomAction = DataTableParameters["responsableNomAction"];


            IQueryable<FicheSecurite> queryFicheSecurite =
                from f in _db.FicheSecurites
                join c in _db.CauseQSEs on f.FicheSecuriteID equals c.FicheSecuriteId
                join a in _db.ActionQSEs on c.CauseQSEId equals a.CauseQSEId
                //orderby f.WorkFlowCloturee && f.WorkFlowASEValidee, f.WorkFlowASEValidee, f.WorkFlowASERejetee, f.WorkFlowAttenteASEValidation, f.WorkFlowDiffusee
                //group new { f, c, a } by f.FicheSecuriteID into grp
                select f;//  new { f, c, a };




            String WorkFlowWhereClause = "";

            //TOCHECK : Peut-il etre REJETE ET EN ATTENTE VALIDATION
            Boolean FirstWorkFlowPredicate = false;

            if (ParameterIsPlanActionAttente == true)
            {
                FirstWorkFlowPredicate = true;
                WorkFlowWhereClause += "(WorkFlowASEValidee == false && WorkFlowAttenteASEValidation == true && WorkFlowASERejetee == false && WorkFlowCloturee == false) || (WorkFlowASEValidee == false && WorkFlowAttenteASEValidation == true && WorkFlowASERejetee == false && WorkFlowCloturee == true)";
            };

            if (ParameterIsPlanActionValide == true)
            {
                if (FirstWorkFlowPredicate == true)
                {

                    WorkFlowWhereClause += "|| (WorkFlowASEValidee == true && WorkFlowAttenteASEValidation == false && WorkFlowASERejetee == false && WorkFlowCloturee == false)";
                }
                else
                {
                    WorkFlowWhereClause += "(WorkFlowASEValidee == true && WorkFlowAttenteASEValidation == false && WorkFlowASERejetee == false && WorkFlowCloturee == false)";
                }
                FirstWorkFlowPredicate = true;
            }
            if (ParameterIsPlanActionRejete == true)
            {
                if (FirstWorkFlowPredicate == true)
                {
                    WorkFlowWhereClause += "|| (WorkFlowASEValidee == false && WorkFlowAttenteASEValidation == false && WorkFlowASERejetee == true && WorkFlowCloturee == false)";
                }
                else
                {
                    WorkFlowWhereClause += "(WorkFlowASEValidee == false && WorkFlowAttenteASEValidation == false && WorkFlowASERejetee == true && WorkFlowCloturee == false)";
                }
                FirstWorkFlowPredicate = true;
            }
            if (ParameterIsPlanActionCloture == true)
            {
                if (FirstWorkFlowPredicate == true)
                {
                    WorkFlowWhereClause += "|| (WorkFlowASEValidee == true && WorkFlowAttenteASEValidation == false && WorkFlowASERejetee == false && WorkFlowCloturee == true)";
                }
                else
                {
                    WorkFlowWhereClause += "(WorkFlowASEValidee == true && WorkFlowAttenteASEValidation == false && WorkFlowASERejetee == false && WorkFlowCloturee == true)";
                }
                FirstWorkFlowPredicate = true;
            }
            if (ParameterIsNouvelleFiche == true)
            {
                if (FirstWorkFlowPredicate == true)
                {
                    WorkFlowWhereClause += "|| (WorkFlowASEValidee == false && WorkFlowAttenteASEValidation == false && WorkFlowASERejetee == false && WorkFlowCloturee == false) || (WorkFlowASEValidee == false && WorkFlowAttenteASEValidation == false && WorkFlowASERejetee == false && WorkFlowCloturee == true)";
                }
                else
                {
                    WorkFlowWhereClause += "(WorkFlowASEValidee == false && WorkFlowAttenteASEValidation == false && WorkFlowASERejetee == false && WorkFlowCloturee == false) || (WorkFlowASEValidee == false && WorkFlowAttenteASEValidation == false && WorkFlowASERejetee == false && WorkFlowCloturee == true)";
                }
                FirstWorkFlowPredicate = true;
            }



            if (WorkFlowWhereClause != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(WorkFlowWhereClause);
            }
            if (ParameterSiteId != null && ParameterSiteId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.SiteId == ParameterSiteId);
            }
            if (ParameterZoneId != null && ParameterZoneId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.ZoneId == ParameterZoneId);
            }
            if (ParameterLieuId != null && ParameterLieuId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.LieuId == ParameterLieuId);
            }
            if (ParameterTypeId != null && ParameterTypeId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecuriteTypeId == ParameterTypeId);
            }
            if (ParameterCode != null && ParameterCode != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.Code == ParameterCode);
            }
            if (ParameterAge != null && ParameterAge != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.Age == ParameterAge);
            }
            if (ParameterPosteDeTravailId != null && ParameterPosteDeTravailId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.PosteDeTravailId == ParameterPosteDeTravailId);
            }
            if (ParameterServiceId != null && ParameterServiceId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.ServiceId == ParameterServiceId);
            }
            if (ParameterPersonneConcerneeNom != null && ParameterPersonneConcerneeNom != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.PersonneConcernee.Nom == ParameterPersonneConcerneeNom);
            }
            if (ParameterResponsableNom != null && ParameterResponsableNom != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.Responsable.Nom == ParameterResponsableNom);
            }
            if (ParameterCotationFrequence != null && ParameterCotationFrequence != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationFrequence == ParameterCotationFrequence);
            }
            if (ParameterCotationGravite != null && ParameterCotationGravite != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationGravite == ParameterCotationGravite);
            }
            if (ParameterRisqueId != null && ParameterRisqueId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.RisqueId == ParameterRisqueId);
            }
            if (ParameterDangerId != null && ParameterDangerId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.DangerId == ParameterDangerId);
            }
            if (ParameterCorpsHumainZoneId != null && ParameterCorpsHumainZoneId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.CorpsHumainZoneId == ParameterCorpsHumainZoneId);
            }
            if (ParameterPlageHoraireId != null && ParameterPlageHoraireId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.PlageHoraireId == ParameterPlageHoraireId);
            }
            if (ParameterDateEvenementDebut != null)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.DateEvenement >= ParameterDateEvenementDebut);
            }
            if (ParameterDateEvenementFin != null)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.DateEvenement <= ParameterDateEvenementFin);
            }
            if (ParameterDateButoirDebut != null)
            {
                queryFicheSecurite = queryFicheSecurite
                    .Join(_db.CauseQSEs, fs => fs.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                    .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                    .Where(j => j.ActionQSE2.DateButoireInitiale >= ParameterDateButoirDebut)
                    .Select(q => q.FicheSecurite2)
                    .Distinct();
            }
            if (ParameterDateButoirFin != null)
            {
                queryFicheSecurite = queryFicheSecurite
                .Join(_db.CauseQSEs, fs => fs.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                .Where(j => j.ActionQSE2.DateButoireInitiale <= ParameterDateButoirFin)
                .Select(q => q.FicheSecurite2)
                .Distinct();
            }
            if (ParameterDateClotureDebut != null)
            {
                queryFicheSecurite = queryFicheSecurite
                .Join(_db.CauseQSEs, fs => fs.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                .Where(j => j.ActionQSE2.ClotureDate >= ParameterDateClotureDebut)
                .Select(q => q.FicheSecurite2)
                .Distinct();
            }
            if (ParameterDateClotureFin != null)
            {
                queryFicheSecurite = queryFicheSecurite
                .Join(_db.CauseQSEs, fs => fs.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                .Where(j => j.ActionQSE2.ClotureDate >= ParameterDateClotureFin)
                .Select(q => q.FicheSecurite2)
                .Distinct();
            }

            //var queryFicheSecurite2 = from queryFicheSecurite
            //                          select f;


            //var query2 = queryFicheSecurite.Select(s => s.f).GroupBy(r => r.FicheSecuriteID);
            //var AllRecords2 = query2.ToList();

            //queryFicheSecurite.Distinct(s => s.f);

            //queryFicheSecurite.GroupBy(r => r.f);

            int RecordsFiltered = queryFicheSecurite.Count();
            int RecordsTotal = _db.FicheSecurites.Count();

            queryFicheSecurite = queryFicheSecurite.OrderBy(i => i.WorkFlowCloturee && i.WorkFlowASEValidee).ThenBy(i => i.WorkFlowASEValidee).ThenBy(i => i.WorkFlowASERejetee).ThenBy(i => i.WorkFlowAttenteASEValidation).ThenBy(i => i.WorkFlowDiffusee);

            if (ParameterIsColonne1Ordonnee == true)
            {
                switch (ParameterColonne1Sens)
                {
                    case "asc":
                        queryFicheSecurite = queryFicheSecurite.OrderBy(q => q.CompteurAnnuelSite);
                        break;
                    case "desc":
                        queryFicheSecurite = queryFicheSecurite.OrderByDescending(fs => fs.CompteurAnnuelSite);
                        break;
                }
            }

            queryFicheSecurite = queryFicheSecurite.Skip(ParameterStart).Take(ParameterLength);


            //queryFicheSecurite.Select(s => s.f).Distinct();
            //queryFicheSecurite = queryFicheSecurite.GroupBy(q => q.f.FicheSecuriteID);

            var AllRecords = queryFicheSecurite.ToList();
            List<FicheSecurite> AllFicheSecurite = queryFicheSecurite.ToList();
            //List<FicheSecurite> AllFicheSecurite = new List<FicheSecurite>();
            //IEnumerable<FicheSecurite> fsecu = AllRecords2.SelectMany(group => group);
            //AllFicheSecurite = fsecu.ToList();

            //foreach(var r in AllRecords2){
            //    AllFicheSecurite.Add(r);
            //};

            DataTableViewModel<FicheSecurite> DataTableViewModel = new DataTableViewModel<FicheSecurite>()
            {
                recordsTotal = RecordsTotal,
                recordsFiltered = RecordsFiltered,
                data = AllRecords
            };


            return DataTableViewModel;



        }


    }
}