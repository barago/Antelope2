using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antelope.Domain.Models;
using Antelope.ViewModels.HSE.FicheSecuriteViewModels;
using Antelope.Infrastructure.EntityFramework;
using Antelope.ViewModels.Socle.DataTables;
using Binbin.Linq;
using System.Linq.Dynamic;
using Antelope.DTOs.HSE;
using Antelope.Services.HSE.Enums;

namespace Antelope.Repositories.HSE
{
    public class FicheSecuriteRepository
    {

        public AntelopeEntities _db { get; set; }

        public FicheSecuriteRepository() : this(new AntelopeEntities())
        {

        }

        public FicheSecuriteRepository(AntelopeEntities db)
        {
            _db = db;
        }

        public FicheSecurite Get(int id)
        {
            FicheSecurite ficheSecurite = _db.FicheSecurites.SingleOrDefault(r => r.FicheSecuriteID == id);
            return ficheSecurite;
        }

        public List<FicheSecurite> GetAll()
        {
            return _db.FicheSecurites.ToList();
        }

        public FicheSecuritePaginatedList GetFromParams(RechercheFicheSecuriteParamModel RechercheFicheSecuriteParamModel)
        {
            IQueryable<FicheSecurite> queryFicheSecurite = from a in _db.FicheSecurites
                                                           orderby a.WorkFlowCloturee && a.WorkFlowASEValidee, a.WorkFlowASEValidee, a.WorkFlowASERejetee, a.WorkFlowAttenteASEValidation, a.WorkFlowDiffusee
                                     select a;


            if (RechercheFicheSecuriteParamModel.SiteId != null && RechercheFicheSecuriteParamModel.SiteId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.SiteId == RechercheFicheSecuriteParamModel.SiteId);
            }
            if (RechercheFicheSecuriteParamModel.ZoneId != null && RechercheFicheSecuriteParamModel.ZoneId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.ZoneId == RechercheFicheSecuriteParamModel.ZoneId);
            }
            if (RechercheFicheSecuriteParamModel.LieuId != null && RechercheFicheSecuriteParamModel.LieuId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.LieuId == RechercheFicheSecuriteParamModel.LieuId);
            }
            if (RechercheFicheSecuriteParamModel.FicheSecuriteTypeId != null && RechercheFicheSecuriteParamModel.FicheSecuriteTypeId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecuriteTypeId == RechercheFicheSecuriteParamModel.FicheSecuriteTypeId);
            }
            if (RechercheFicheSecuriteParamModel.Code != null && RechercheFicheSecuriteParamModel.Code != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.Code == RechercheFicheSecuriteParamModel.Code);
            }
            if (RechercheFicheSecuriteParamModel.Age != null && RechercheFicheSecuriteParamModel.Age != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.Age == RechercheFicheSecuriteParamModel.Age);
            }
            if (RechercheFicheSecuriteParamModel.PosteDeTravailId != null && RechercheFicheSecuriteParamModel.PosteDeTravailId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.PosteDeTravailId == RechercheFicheSecuriteParamModel.PosteDeTravailId);
            }
            if (RechercheFicheSecuriteParamModel.ServiceId != null && RechercheFicheSecuriteParamModel.ServiceId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.ServiceId == RechercheFicheSecuriteParamModel.ServiceId);
            }
            if (RechercheFicheSecuriteParamModel.DateEvenementDebut != null)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.DateEvenement >= RechercheFicheSecuriteParamModel.DateEvenementDebut);
            }
            if (RechercheFicheSecuriteParamModel.DateEvenementFin != null)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.DateEvenement <= RechercheFicheSecuriteParamModel.DateEvenementFin);
            }
            if (RechercheFicheSecuriteParamModel.PersonneConcerneeNom != null && RechercheFicheSecuriteParamModel.PersonneConcerneeNom != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.PersonneConcernee.Nom == RechercheFicheSecuriteParamModel.PersonneConcerneeNom);
            }
            if (RechercheFicheSecuriteParamModel.ResponsableNom != null && RechercheFicheSecuriteParamModel.ResponsableNom != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.Responsable.Nom == RechercheFicheSecuriteParamModel.ResponsableNom);
            }
            if (RechercheFicheSecuriteParamModel.CotationFrequence != null && RechercheFicheSecuriteParamModel.CotationFrequence != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationFrequence == RechercheFicheSecuriteParamModel.CotationFrequence);
            }
            if (RechercheFicheSecuriteParamModel.CotationGravite != null && RechercheFicheSecuriteParamModel.CotationGravite != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationGravite == RechercheFicheSecuriteParamModel.CotationGravite);
            }
            if (RechercheFicheSecuriteParamModel.RisqueId != null && RechercheFicheSecuriteParamModel.RisqueId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.RisqueId == RechercheFicheSecuriteParamModel.RisqueId);
            }
            if (RechercheFicheSecuriteParamModel.DangerId != null && RechercheFicheSecuriteParamModel.DangerId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.DangerId == RechercheFicheSecuriteParamModel.DangerId);
            }
            if (RechercheFicheSecuriteParamModel.CorpsHumainZoneId != null && RechercheFicheSecuriteParamModel.CorpsHumainZoneId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.CorpsHumainZoneId == RechercheFicheSecuriteParamModel.CorpsHumainZoneId);
            }
            if (RechercheFicheSecuriteParamModel.PlageHoraireId != null && RechercheFicheSecuriteParamModel.PlageHoraireId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.PlageHoraireId == RechercheFicheSecuriteParamModel.PlageHoraireId);
            }
            if (RechercheFicheSecuriteParamModel.ResponsableGuid != null && RechercheFicheSecuriteParamModel.ResponsableGuid != new Guid())
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.Responsable.Guid == RechercheFicheSecuriteParamModel.ResponsableGuid);
            }


            int TotalRowCount = queryFicheSecurite.Count();

            queryFicheSecurite = queryFicheSecurite.Skip(RechercheFicheSecuriteParamModel.PageSize * (RechercheFicheSecuriteParamModel.Page - 1)).Take(RechercheFicheSecuriteParamModel.PageSize);
            //queryFicheSecurite = queryFicheSecurite.Skip(0).Take(4);


                //.ThenBy(q => q.WorkFlowAttenteASEValidation)
                //.ThenBy(q => q.WorkFlowASERejetee)
                //.ThenBy(q => q.WorkFlowASEValidee)
                //.ThenBy(q => q.WorkFlowCloturee);

            List<FicheSecurite> AllFicheSecurite = queryFicheSecurite.ToList();

            FicheSecuritePaginatedList FicheSecuritePaginatedList = new FicheSecuritePaginatedList()
            {
                AllFicheSecurite = AllFicheSecurite,
                Page = RechercheFicheSecuriteParamModel.Page,
                PageSize = RechercheFicheSecuriteParamModel.PageSize,
                RowCount = TotalRowCount
            };

            return FicheSecuritePaginatedList;

        }


        public DataTableViewModel<FicheSecurite> GetAllFicheSecuriteFromParams(Dictionary<string, string> DataTableParameters)
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
            Boolean ParameterIsFicheSecuriteCloture = Convert.ToBoolean(DataTableParameters["isFicheSecuriteCloture"]);
            //Guid ParameterResponsableGuid = Guid.Parse(DataTableParameters["responsableGuid"]);
            Boolean ParameterIsColonne1Ordonnee = Convert.ToBoolean(Int32.Parse(DataTableParameters["order[0].column"]));
            String ParameterColonne1Sens = DataTableParameters["order[0].dir"];
            DateTime? ParameterDateButoirDebut = null;
            DateTime? ParameterDateButoirFin = null;
            DateTime? ParameterDateClotureDebut = null;
            DateTime? ParameterDateClotureFin = null;
            String ParameterResponsableNomAction = DataTableParameters["responsableNomAction"];
            String ParameterRechercheType = DataTableParameters["rechercheType"];
            Int32 ParameterCriticite = Int32.Parse(DataTableParameters["criticite"]);
            CriticiteNiveauEnum ParameterCriticiteNiveau = CriticiteNiveauEnum.NULL; // DataTableParameters["criticiteNiveau"];


            if (DataTableParameters["CriticiteNiveau"] != "NULL")
            {
                CriticiteNiveauEnum.TryParse(DataTableParameters["CriticiteNiveau"], out ParameterCriticiteNiveau); //CriticiteNiveauEnum.DataTableParameters["CriticiteNiveau"]  // Enum.TryParse("Active", out myStatus);
            }
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
                    ParameterDateEvenementFin = DateTime.Parse(DataTableParameters["dateEvenementFin"]).AddDays(1);
                }
                catch (Exception e)
                {

                }
            }
            if (DataTableParameters["dateButoirDebut"]!="")
            {
                try
                {
                    ParameterDateButoirDebut = DateTime.Parse(DataTableParameters["dateButoirDebut"]);
                }
                catch (Exception e )
                {

                }
            }
            if(DataTableParameters["dateButoirFin"]!=""){
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

            //IQueryable<FicheSecurite> queryFicheSecurite = null;


                IQueryable<FicheSecurite> queryFicheSecurite =
                    from f in _db.FicheSecurites
                    //join c in _db.CauseQSEs on f.FicheSecuriteID equals c.FicheSecuriteId
                    //join a in _db.ActionQSEs on c.CauseQSEId equals a.CauseQSEId
                    //orderby f.WorkFlowCloturee && f.WorkFlowASEValidee, f.WorkFlowASEValidee, f.WorkFlowASERejetee, f.WorkFlowAttenteASEValidation, f.WorkFlowDiffusee
                    //group new { f, c, a } by f.FicheSecuriteID into grp
                    select f;//  new { f, c, a };

            


                
            //    var queryFicheSecurite =
            //                        from f in _db.FicheSecurites
            //    join c in _db.CauseQSEs on f.FicheSecuriteID equals c.FicheSecuriteId
            //    join a in _db.ActionQSEs on c.CauseQSEId equals a.CauseQSEId
            //    //orderby f.WorkFlowCloturee && f.WorkFlowASEValidee, f.WorkFlowASEValidee, f.WorkFlowASERejetee, f.WorkFlowAttenteASEValidation, f.WorkFlowDiffusee
            //    //group new { f, c, a } by f.FicheSecuriteID into grp
            //    select /*f;*/  new { f, c, a };

            //}


         



            String WorkFlowWhereClause = "";   

            //TOCHECK : Peut-il etre REJETE ET EN ATTENTE VALIDATION
            Boolean FirstWorkFlowPredicate = false;

            if (ParameterIsPlanActionAttente == true)
            {
                FirstWorkFlowPredicate = true;
                WorkFlowWhereClause += "(WorkFlowASEValidee == false && WorkFlowAttenteASEValidation == true && WorkFlowASERejetee == false && WorkFlowCloturee == false && WorkFlowFicheSecuriteCloturee == false) || (WorkFlowASEValidee == false && WorkFlowAttenteASEValidation == true && WorkFlowASERejetee == false && WorkFlowCloturee == true && WorkFlowFicheSecuriteCloturee == false)";
            };

            if (ParameterIsPlanActionValide == true)
            {
                if (FirstWorkFlowPredicate == true)
                {
                    WorkFlowWhereClause += "|| ";
                }
                WorkFlowWhereClause += "(WorkFlowASEValidee == true && WorkFlowAttenteASEValidation == false && WorkFlowASERejetee == false && WorkFlowCloturee == false && WorkFlowFicheSecuriteCloturee == false)";
                FirstWorkFlowPredicate = true;
            }
            if (ParameterIsPlanActionRejete == true)
            {
                if (FirstWorkFlowPredicate == true)
                {
                    WorkFlowWhereClause += "|| ";
                }
                WorkFlowWhereClause += "(WorkFlowASEValidee == false && WorkFlowAttenteASEValidation == false && WorkFlowASERejetee == true && WorkFlowCloturee == false && WorkFlowFicheSecuriteCloturee == false)";
                FirstWorkFlowPredicate = true;
            }
            if (ParameterIsPlanActionCloture == true)
            {
                if (FirstWorkFlowPredicate == true)
                {
                    WorkFlowWhereClause += "|| ";
                }
                WorkFlowWhereClause += "(WorkFlowASEValidee == true && WorkFlowAttenteASEValidation == false && WorkFlowASERejetee == false && WorkFlowCloturee == true && WorkFlowFicheSecuriteCloturee == false)";
                FirstWorkFlowPredicate = true;
            }
            if (ParameterIsFicheSecuriteCloture == true)
            {
                if (FirstWorkFlowPredicate == true)
                {
                    WorkFlowWhereClause += "|| ";
                }
                WorkFlowWhereClause += "(WorkFlowFicheSecuriteCloturee == true)";
                FirstWorkFlowPredicate = true;
            }
            if (ParameterIsNouvelleFiche == true)
            {
                if (FirstWorkFlowPredicate == true)
                {
                    WorkFlowWhereClause += "|| ";
                }
                WorkFlowWhereClause += "(WorkFlowASEValidee == false && WorkFlowAttenteASEValidation == false && WorkFlowASERejetee == false && WorkFlowCloturee == false && WorkFlowFicheSecuriteCloturee == false) || (WorkFlowASEValidee == false && WorkFlowAttenteASEValidation == false && WorkFlowASERejetee == false && WorkFlowCloturee == true && WorkFlowFicheSecuriteCloturee == false)";
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
            if (ParameterCriticite != null && ParameterCriticite != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationFrequence * q.CotationGravite == ParameterCriticite);
            }
            if (ParameterCriticiteNiveau != null && ParameterCriticiteNiveau != CriticiteNiveauEnum.NULL)
            {
                switch (ParameterCriticiteNiveau){
                    case CriticiteNiveauEnum.BAS :
                        queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationFrequence * q.CotationGravite < 9);
                        break;
                    case CriticiteNiveauEnum.MOYEN:
                        queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationFrequence * q.CotationGravite >= 9 && q.CotationFrequence * q.CotationGravite <= 12);
                        break;
                    case CriticiteNiveauEnum.HAUT:
                        queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationFrequence * q.CotationGravite > 12 );
                        break;
                }
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
            if (ParameterResponsableNomAction != null && ParameterResponsableNomAction != "")
            {
                queryFicheSecurite = queryFicheSecurite
                .Join(_db.CauseQSEs, fs => fs.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                .Where(j => j.ActionQSE2.Responsable.Nom == ParameterResponsableNomAction)
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

            queryFicheSecurite = queryFicheSecurite.OrderBy(i => i.WorkFlowFicheSecuriteCloturee).ThenBy(i => i.WorkFlowCloturee && i.WorkFlowASEValidee).ThenBy(i => i.WorkFlowASEValidee).ThenBy(i => i.WorkFlowASERejetee).ThenBy(i => i.WorkFlowAttenteASEValidation).ThenBy(i => i.WorkFlowDiffusee);

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

            if (ParameterLength != -1)
            {
                queryFicheSecurite = queryFicheSecurite.Skip(ParameterStart).Take(ParameterLength);
            }

            //queryFicheSecurite.Select(s => s.f).Distinct();
            //queryFicheSecurite = queryFicheSecurite.GroupBy(q => q.f.FicheSecuriteID);

            var AllRecords = queryFicheSecurite.ToList();
            //List<FicheSecurite> AllFicheSecurite = queryFicheSecurite.ToList();
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

        public DataTableViewModel<FicheSecuriteActionRecherche> GetAllActionFromParams(Dictionary<string, string> DataTableParameters)
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
            Boolean ParameterIsFicheSecuriteCloture = Convert.ToBoolean(DataTableParameters["isFicheSecuriteCloture"]);
            //Guid ParameterResponsableGuid = Guid.Parse(DataTableParameters["responsableGuid"]);
            Boolean ParameterIsColonne1Ordonnee = false;
            String ParameterColonne1Sens = null;
            Boolean ParameterIsColonne2Ordonnee = false;
            String ParameterColonne2Sens = null;
            Boolean ParameterIsColonne4Ordonnee = false;
            String ParameterColonne4Sens = null;
            Boolean ParameterIsColonne5Ordonnee = false;
            String ParameterColonne5Sens = null;
            Boolean ParameterIsColonne6Ordonnee = false;
            String ParameterColonne6Sens = null;
            DateTime? ParameterDateButoirDebut = null;
            DateTime? ParameterDateButoirFin = null;
            DateTime? ParameterDateClotureDebut = null;
            DateTime? ParameterDateClotureFin = null;
            String ParameterResponsableNomAction = DataTableParameters["responsableNomAction"];
            String ParameterRechercheType = DataTableParameters["rechercheType"];
            Int32 ParameterCriticite = Int32.Parse(DataTableParameters["criticite"]);
            CriticiteNiveauEnum ParameterCriticiteNiveau = CriticiteNiveauEnum.NULL; // DataTableParameters["criticiteNiveau"];


            if (DataTableParameters["CriticiteNiveau"] != "NULL")
            {
                CriticiteNiveauEnum.TryParse(DataTableParameters["CriticiteNiveau"], out ParameterCriticiteNiveau); //CriticiteNiveauEnum.DataTableParameters["CriticiteNiveau"]  // Enum.TryParse("Active", out myStatus);
            }
            if (DataTableParameters["order[0].column"] == "1")
            {
                ParameterIsColonne1Ordonnee = true;
                ParameterColonne1Sens = DataTableParameters["order[0].dir"];
            }
            if (DataTableParameters["order[0].column"] == "2")
            {
                ParameterIsColonne2Ordonnee = true;
                ParameterColonne2Sens = DataTableParameters["order[0].dir"];
            }
            if (DataTableParameters["order[0].column"] == "4")
            {
                ParameterIsColonne4Ordonnee = true;
                ParameterColonne4Sens = DataTableParameters["order[0].dir"];
            }
            if (DataTableParameters["order[0].column"] == "5")
            {
                ParameterIsColonne5Ordonnee = true;
                ParameterColonne5Sens = DataTableParameters["order[0].dir"];
            }
            if (DataTableParameters["order[0].column"] == "6")
            {
                ParameterIsColonne6Ordonnee = true;
                ParameterColonne6Sens = DataTableParameters["order[0].dir"];
            }
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
                    ParameterDateEvenementFin = DateTime.Parse(DataTableParameters["dateEvenementFin"]).AddDays(1);
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

            //IQueryable<FicheSecurite> queryFicheSecurite = null;


                var queryFicheSecurite =
                                    from f in _db.FicheSecurites
                join c in _db.CauseQSEs on f.FicheSecuriteID equals c.FicheSecuriteId
                join a in _db.ActionQSEs on c.CauseQSEId equals a.CauseQSEId
                //orderby f.WorkFlowCloturee && f.WorkFlowASEValidee, f.WorkFlowASEValidee, f.WorkFlowASERejetee, f.WorkFlowAttenteASEValidation, f.WorkFlowDiffusee
                //group new { f, c, a } by f.FicheSecuriteID into grp
                select /*f;*/  new FicheSecuriteActionRecherche() {FicheSecurite = f , CauseQSE = c, ActionQSE = a };

            


            String WorkFlowWhereClause = "";

            //TOCHECK : Peut-il etre REJETE ET EN ATTENTE VALIDATION
            Boolean FirstWorkFlowPredicate = false;

            if (ParameterIsPlanActionAttente == true)
            {
                FirstWorkFlowPredicate = true;
                WorkFlowWhereClause += "(FicheSecurite.WorkFlowASEValidee == false && FicheSecurite.WorkFlowAttenteASEValidation == true && FicheSecurite.WorkFlowASERejetee == false && FicheSecurite.WorkFlowCloturee == false && FicheSecurite.WorkFlowFicheSecuriteCloturee == false) || (FicheSecurite.WorkFlowASEValidee == false && FicheSecurite.WorkFlowAttenteASEValidation == true && FicheSecurite.WorkFlowASERejetee == false && FicheSecurite.WorkFlowCloturee == true && FicheSecurite.WorkFlowFicheSecuriteCloturee == false)";
            };

            if (ParameterIsPlanActionValide == true)
            {
                if (FirstWorkFlowPredicate == true)
                {
                    WorkFlowWhereClause += "|| ";
                }
                WorkFlowWhereClause += "(FicheSecurite.WorkFlowASEValidee == true && FicheSecurite.WorkFlowAttenteASEValidation == false && FicheSecurite.WorkFlowASERejetee == false && FicheSecurite.WorkFlowCloturee == false && FicheSecurite.WorkFlowFicheSecuriteCloturee == false)";
                FirstWorkFlowPredicate = true;
            }
            if (ParameterIsPlanActionRejete == true)
            {
                if (FirstWorkFlowPredicate == true)
                {
                    WorkFlowWhereClause += "|| ";
                }
                WorkFlowWhereClause += "(FicheSecurite.WorkFlowASEValidee == false && FicheSecurite.WorkFlowAttenteASEValidation == false && FicheSecurite.WorkFlowASERejetee == true && FicheSecurite.WorkFlowCloturee == false && FicheSecurite.WorkFlowFicheSecuriteCloturee == false)";
                FirstWorkFlowPredicate = true;
            }
            if (ParameterIsPlanActionCloture == true)
            {
                if (FirstWorkFlowPredicate == true)
                {
                    WorkFlowWhereClause += "|| ";
                }
                WorkFlowWhereClause += "(FicheSecurite.WorkFlowASEValidee == true && FicheSecurite.WorkFlowAttenteASEValidation == false && FicheSecurite.WorkFlowASERejetee == false && FicheSecurite.WorkFlowCloturee == true && FicheSecurite.WorkFlowFicheSecuriteCloturee == false)";
                FirstWorkFlowPredicate = true;
            }
            if (ParameterIsFicheSecuriteCloture == true)
            {
                if (FirstWorkFlowPredicate == true)
                {
                    WorkFlowWhereClause += "|| ";
                }
                WorkFlowWhereClause += "(FicheSecurite.WorkFlowFicheSecuriteCloturee == true)";
                FirstWorkFlowPredicate = true;
            }
            if (ParameterIsNouvelleFiche == true)
            {
                if (FirstWorkFlowPredicate == true)
                {
                    WorkFlowWhereClause += "|| ";
                }
                WorkFlowWhereClause += "(FicheSecurite.WorkFlowASEValidee == false && FicheSecurite.WorkFlowAttenteASEValidation == false && FicheSecurite.WorkFlowASERejetee == false && FicheSecurite.WorkFlowCloturee == false && FicheSecurite.WorkFlowFicheSecuriteCloturee == false) || (FicheSecurite.WorkFlowASEValidee == false && FicheSecurite.WorkFlowAttenteASEValidation == false && FicheSecurite.WorkFlowASERejetee == false && FicheSecurite.WorkFlowCloturee == true && FicheSecurite.WorkFlowFicheSecuriteCloturee == false)";
                FirstWorkFlowPredicate = true;
            }

            if (WorkFlowWhereClause != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(WorkFlowWhereClause);
            }
            if (ParameterSiteId != null && ParameterSiteId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.SiteId == ParameterSiteId);
            }
            if (ParameterZoneId != null && ParameterZoneId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.ZoneId == ParameterZoneId);
            }
            if (ParameterLieuId != null && ParameterLieuId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.LieuId == ParameterLieuId);
            }
            if (ParameterTypeId != null && ParameterTypeId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.FicheSecuriteTypeId == ParameterTypeId);
            }
            if (ParameterCode != null && ParameterCode != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.Code == ParameterCode);
            }
            if (ParameterAge != null && ParameterAge != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.Age == ParameterAge);
            }
            if (ParameterPosteDeTravailId != null && ParameterPosteDeTravailId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.PosteDeTravailId == ParameterPosteDeTravailId);
            }
            if (ParameterServiceId != null && ParameterServiceId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.ServiceId == ParameterServiceId);
            }
            if (ParameterPersonneConcerneeNom != null && ParameterPersonneConcerneeNom != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.PersonneConcernee.Nom == ParameterPersonneConcerneeNom);
            }
            if (ParameterResponsableNom != null && ParameterResponsableNom != "")
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.Responsable.Nom == ParameterResponsableNom);
            }
            if (ParameterCotationFrequence != null && ParameterCotationFrequence != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.CotationFrequence == ParameterCotationFrequence);
            }
            if (ParameterCotationGravite != null && ParameterCotationGravite != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.CotationGravite == ParameterCotationGravite);
            }
            if (ParameterRisqueId != null && ParameterRisqueId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.RisqueId == ParameterRisqueId);
            }
            if (ParameterDangerId != null && ParameterDangerId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.DangerId == ParameterDangerId);
            }
            if (ParameterCorpsHumainZoneId != null && ParameterCorpsHumainZoneId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.CorpsHumainZoneId == ParameterCorpsHumainZoneId);
            }
            if (ParameterPlageHoraireId != null && ParameterPlageHoraireId != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.PlageHoraireId == ParameterPlageHoraireId);
            }
            if (ParameterDateEvenementDebut != null)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.DateEvenement >= ParameterDateEvenementDebut);
            }
            if (ParameterDateEvenementFin != null)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.DateEvenement <= ParameterDateEvenementFin);
            }
            if (ParameterCriticite != null && ParameterCriticite != 0)
            {
                queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.CotationFrequence * q.FicheSecurite.CotationGravite == ParameterCriticite);
            }
            if (ParameterCriticiteNiveau != null && ParameterCriticiteNiveau != CriticiteNiveauEnum.NULL)
            {
                switch (ParameterCriticiteNiveau)
                {
                    case CriticiteNiveauEnum.BAS:
                        queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.CotationFrequence * q.FicheSecurite.CotationGravite < 9);
                        break;
                    case CriticiteNiveauEnum.MOYEN:
                        queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.CotationFrequence * q.FicheSecurite.CotationGravite >= 9 && q.FicheSecurite.CotationFrequence * q.FicheSecurite.CotationGravite <= 12);
                        break;
                    case CriticiteNiveauEnum.HAUT:
                        queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.CotationFrequence * q.FicheSecurite.CotationGravite > 12);
                        break;
                }
            }
            if (ParameterDateButoirDebut != null)
            {
                queryFicheSecurite = queryFicheSecurite
                    .Join(_db.CauseQSEs, fs => fs.FicheSecurite.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                    .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                    //.Where(j => j.ActionQSE2.DateButoireInitiale >= ParameterDateButoirDebut)
                    .Select(q => q.FicheSecurite2)
                    .Distinct();

                queryFicheSecurite = queryFicheSecurite
                .Where(w => w.ActionQSE.DateButoireInitiale >= ParameterDateButoirDebut);
            }
            if (ParameterDateButoirFin != null)
            {
                queryFicheSecurite = queryFicheSecurite
                .Join(_db.CauseQSEs, fs => fs.FicheSecurite.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                //.Where(j => j.ActionQSE2.DateButoireInitiale <= ParameterDateButoirFin)
                .Select(q => q.FicheSecurite2)
                .Distinct();

                queryFicheSecurite = queryFicheSecurite
                .Where(w => w.ActionQSE.DateButoireInitiale <= ParameterDateButoirFin);
            }
            if (ParameterDateClotureDebut != null)
            {
                queryFicheSecurite = queryFicheSecurite
                .Join(_db.CauseQSEs, fs => fs.FicheSecurite.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                //.Where(j => j.ActionQSE2.ClotureDate >= ParameterDateClotureDebut)
                .Select(q => q.FicheSecurite2)
                .Distinct();

                queryFicheSecurite = queryFicheSecurite
                .Where(w => w.ActionQSE.ClotureDate >= ParameterDateClotureDebut);
            }
            if (ParameterDateClotureFin != null)
            {
                queryFicheSecurite = queryFicheSecurite
                .Join(_db.CauseQSEs, fs => fs.FicheSecurite.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                //.Where(j => j.ActionQSE2.ClotureDate >= ParameterDateClotureFin)
                .Select(q => q.FicheSecurite2)
                .Distinct();

                queryFicheSecurite = queryFicheSecurite
                .Where(w => w.ActionQSE.ClotureDate <= ParameterDateClotureFin);
            }
            if (ParameterResponsableNomAction != null && ParameterResponsableNomAction != "")
            {
                queryFicheSecurite = queryFicheSecurite
                .Join(_db.CauseQSEs, fs => fs.FicheSecurite.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                //.Where(j => j.ActionQSE2.Responsable.Nom == ParameterResponsableNomAction)
                .Select(q => q.FicheSecurite2)
                .Distinct();

                queryFicheSecurite = queryFicheSecurite
                    .Where(w => w.ActionQSE.Responsable.Nom == ParameterResponsableNomAction);
            }

            //var queryFicheSecurite2 = from queryFicheSecurite
            //                          select f;


            //var query2 = queryFicheSecurite.Select(s => s.f).GroupBy(r => r.FicheSecuriteID);
            //var AllRecords2 = query2.ToList();

            //queryFicheSecurite.Distinct(s => s.f);

            //queryFicheSecurite.GroupBy(r => r.f);

            int RecordsFiltered = queryFicheSecurite.Count();
            int RecordsTotal = _db.FicheSecurites.Count();

            queryFicheSecurite = queryFicheSecurite.OrderBy(i => i.FicheSecurite.WorkFlowFicheSecuriteCloturee).ThenBy(i => i.FicheSecurite.WorkFlowCloturee && i.FicheSecurite.WorkFlowASEValidee).ThenBy(i => i.FicheSecurite.WorkFlowASEValidee).ThenBy(i => i.FicheSecurite.WorkFlowASERejetee).ThenBy(i => i.FicheSecurite.WorkFlowAttenteASEValidation).ThenBy(i => i.FicheSecurite.WorkFlowDiffusee);

            if (ParameterIsColonne1Ordonnee == true)
            {
                switch (ParameterColonne1Sens)
                {
                    case "asc":
                        queryFicheSecurite = queryFicheSecurite.OrderBy(q => q.FicheSecurite.CompteurAnnuelSite);
                        break;
                    case "desc":
                        queryFicheSecurite = queryFicheSecurite.OrderByDescending(fs => fs.FicheSecurite.CompteurAnnuelSite);
                        break;
                }
            }
            if (ParameterIsColonne2Ordonnee == true)
            {
                switch (ParameterColonne2Sens)
                {
                    case "asc":
                        queryFicheSecurite = queryFicheSecurite.OrderBy(q => q.ActionQSE.Responsable.Nom);
                        break;
                    case "desc":
                        queryFicheSecurite = queryFicheSecurite.OrderByDescending(fs => fs.ActionQSE.Responsable.Nom);
                        break;
                }
            }
            if (ParameterIsColonne4Ordonnee == true)
            {
                switch (ParameterColonne4Sens)
                {
                    case "asc":
                        queryFicheSecurite = queryFicheSecurite.OrderBy(q => q.ActionQSE.DateButoireInitiale);
                        break;
                    case "desc":
                        queryFicheSecurite = queryFicheSecurite.OrderByDescending(fs => fs.ActionQSE.DateButoireInitiale);
                        break;
                }
            }
            if (ParameterIsColonne5Ordonnee == true)
            {
                switch (ParameterColonne5Sens)
                {
                    case "asc":
                        queryFicheSecurite = queryFicheSecurite.OrderBy(q => q.ActionQSE.DateButoireNouvelle);
                        break;
                    case "desc":
                        queryFicheSecurite = queryFicheSecurite.OrderByDescending(fs => fs.ActionQSE.DateButoireNouvelle);
                        break;
                }
            }
            if (ParameterIsColonne6Ordonnee == true)
            {
                switch (ParameterColonne6Sens)
                {
                    case "asc":
                        queryFicheSecurite = queryFicheSecurite.OrderBy(q => q.ActionQSE.ClotureDate);
                        break;
                    case "desc":
                        queryFicheSecurite = queryFicheSecurite.OrderByDescending(fs => fs.ActionQSE.ClotureDate);
                        break;
                }
            }

            queryFicheSecurite = queryFicheSecurite.Skip(ParameterStart).Take(ParameterLength);


            //queryFicheSecurite.Select(s => s.f).Distinct();
            //queryFicheSecurite = queryFicheSecurite.GroupBy(q => q.f.FicheSecuriteID);

            var AllRecords = queryFicheSecurite.ToList();
            //List<FicheSecurite> AllFicheSecurite = queryFicheSecurite.ToList();
            //List<FicheSecurite> AllFicheSecurite = new List<FicheSecurite>();
            //IEnumerable<FicheSecurite> fsecu = AllRecords2.SelectMany(group => group);
            //AllFicheSecurite = fsecu.ToList();

            //foreach(var r in AllRecords2){
            //    AllFicheSecurite.Add(r);
            //};

            DataTableViewModel<FicheSecuriteActionRecherche> DataTableViewModel = new DataTableViewModel<FicheSecuriteActionRecherche>()
            {
                recordsTotal = RecordsTotal,
                recordsFiltered = RecordsFiltered,
                data = AllRecords
            };


            return DataTableViewModel;

        }

        //public Review Add(Review review)
        //{
        //    _db.Reviews.Add(review);
        //    _db.SaveChanges();
        //    return review;
        //}

        //public Review Update(Review review)
        //{
        //    _db.Entry(review).State = EntityState.Modified;
        //    _db.SaveChanges();
        //    return review;
        //}

        //public void Delete(int reviewId)
        //{
        //    var review = Get(reviewId);
        //    _db.Reviews.Remove(review);
        //}

        //public IEnumerable<Review> GetByCategory(Category category)
        //{
        //    return _db.Reviews.Where(r => r.CategoryId == category.Id);
        //}

        //public IEnumerable<Comment> GetReviewComments(int id)
        //{
        //    return _db.Comments.Where(c => c.ReviewId == id);
        //}




    }
}