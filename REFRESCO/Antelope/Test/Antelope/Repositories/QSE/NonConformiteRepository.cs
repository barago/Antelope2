using Antelope.Domain.Models;
using Antelope.DTOs.QSE;
using Antelope.Infrastructure.EntityFramework;
using Antelope.ViewModels.Socle.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Binbin.Linq;
using System.Linq.Dynamic;
using Antelope.DTOs.HSE;
using Antelope.Services.HSE.Enums;

namespace Antelope.Repositories.QSE
{
    public class NonConformiteRepository
    {

        public AntelopeEntities _db { get; set; }

        public NonConformiteRepository() : this(new AntelopeEntities())
        {

        }

        public NonConformiteRepository(AntelopeEntities db)
        {
            _db = db;
        }

        public NonConformite Get(Int32 id)
        {
            NonConformite NonConformite = _db.NonConformites.SingleOrDefault(r => r.Id == id);
            return NonConformite;
        }

        public DataTableViewModel<NonConformite> GetFromParams(Dictionary<string, string> DataTableParameters)
        {

            Int32 ParameterStart = Int32.Parse(DataTableParameters["start"]);
            Int32 ParameterLength = Int32.Parse(DataTableParameters["length"]);
            Int32 ParameterSiteId = Int32.Parse(DataTableParameters["siteId"]);
            Int32 ParameterServiceTypeId = Int32.Parse(DataTableParameters["serviceTypeId"]);
            Int32 ParameterOrigineId = Int32.Parse(DataTableParameters["nonConformiteOrigineId"]);
            Int32 ParameterGraviteId = Int32.Parse(DataTableParameters["nonConformiteGraviteId"]);
            Int32 ParameterDomaineId = Int32.Parse(DataTableParameters["nonConformiteDomaineId"]);
            Boolean ParameterIsNCEnCours = Convert.ToBoolean(DataTableParameters["isNCEnCours"]);
            Boolean ParameterIsNCCloture = Convert.ToBoolean(DataTableParameters["isNCCloture"]);
            Boolean ParameterIsColonne1Ordonnee = false;
            String ParameterColonne1Sens = null;
            Boolean ParameterIsColonne2Ordonnee = false;
            String ParameterColonne2Sens = null;
            Boolean ParameterIsColonne3Ordonnee = false;
            String ParameterColonne3Sens = null;

            String ParameterResponsableNom = DataTableParameters["responsableNom"];
            DateTime? ParameterDateButoirDebut = null;
            DateTime? ParameterDateButoirFin = null;


            //String WorkFlowWhereClause = "";
            //Boolean FirstWorkFlowPredicate = false;

            //if (ParameterIsNCEnCours == true)
            //{
            //    //FirstWorkFlowPredicate = true;
            //    //WorkFlowWhereClause += "";
                    
                    
            //        //"(WorkFlowASEValidee == false && WorkFlowAttenteASEValidation == true && WorkFlowASERejetee == false && WorkFlowCloturee == false && WorkFlowFicheSecuriteCloturee == false) 
            //        //    || (WorkFlowASEValidee == false && WorkFlowAttenteASEValidation == true && WorkFlowASERejetee == false && WorkFlowCloturee == true && WorkFlowFicheSecuriteCloturee == false)";
            //};


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
            if (DataTableParameters["order[0].column"] == "3")
            {
                ParameterIsColonne3Ordonnee = true;
                ParameterColonne3Sens = DataTableParameters["order[0].dir"];
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


            //var queryNonConformite = from nc in _db.NonConformites
            //                        join a in _db.ActionQSEs on nc.Id equals a.NonConformiteId
            //                        orderby nc.Id
            //                        select new NonConformiteActionRecherche(){NonConformite =nc, ActionQSE = a};

            var queryNonConformite = from nc in _db.NonConformites
                                     //join a in _db.ActionQSEs on nc.Id equals a.NonConformiteId
                                     //orderby nc.Id
                                     select nc;

            
            if (ParameterIsNCEnCours == false || ParameterIsNCCloture == false)
            {
                if (ParameterIsNCCloture == true)
                {
                    var queryNonConformiteBis = queryNonConformite
                        .Join(_db.ActionQSEs, nc => nc.Id, a => a.NonConformiteId, (nc, a) => new { NonConformite = nc, ActionQSE = a })
                        .Where(j => j.ActionQSE.VerifieDate == null)
                        .Select(q => q.NonConformite)
                        .Distinct();

                    queryNonConformite = queryNonConformite.Except(queryNonConformiteBis);

                    queryNonConformite = queryNonConformite.Where(q => q.ActionQSEs.Count > 0);


                }
                if (ParameterIsNCEnCours == true)
                {
                    // Attention > gros bordel : Pour X raison, la clause Where de la lambda ne prends pas en compte la clause OR Action = 0 ... 
                    // On refait donc une requête qui les inclue et une UNION entre les deux, c'est pas beau, pas le temps de travailler plus là dessus.
                    
                    var queryNonConformiteBis = queryNonConformite
                        .Join(_db.ActionQSEs, nc => nc.Id, a => a.NonConformiteId, (nc, a) => new { NonConformite = nc, ActionQSE = a })
                        .Where(j => j.ActionQSE.VerifieDate == null)  //|| j.NonConformite.ActionQSEs.Count == 0
                        .Select(q => q.NonConformite)
                        .Distinct();

                    var queryNonConformiteWhereZeroAction = queryNonConformite.Where(q => q.ActionQSEs.Count == 0);

                    queryNonConformite = queryNonConformiteBis.Union(queryNonConformiteWhereZeroAction);

                }
            }
            if (ParameterSiteId != null && ParameterSiteId != 0)
            {
                queryNonConformite = queryNonConformite.Where(q => q.SiteId == ParameterSiteId);
            }
            if (ParameterServiceTypeId != null && ParameterServiceTypeId != 0)
            {
                queryNonConformite = queryNonConformite.Where(q => q.ServiceTypeId == ParameterServiceTypeId);
            }
            if (ParameterOrigineId != null && ParameterOrigineId != 0)
            {
                queryNonConformite = queryNonConformite.Where(q => q.NonConformiteOrigineId == ParameterOrigineId);
            }
            if (ParameterGraviteId != null && ParameterGraviteId != 0)
            {
                queryNonConformite = queryNonConformite.Where(q => q.NonConformiteGraviteId == ParameterGraviteId);
            }
            if (ParameterDomaineId != null && ParameterDomaineId != 0)
            {
                queryNonConformite = queryNonConformite.Where(q => q.NonConformiteDomaineId == ParameterDomaineId);
            }
            if (ParameterResponsableNom != null && ParameterResponsableNom != "")
            {
                //queryNonConformite = queryNonConformite.Where(q => q.Responsable.Nom == ParameterResponsableNom);

                queryNonConformite = queryNonConformite
                .Join(_db.ActionQSEs, nc => nc.Id, a => a.NonConformiteId, (nc, a) => new { NonConformite = nc, ActionQSE = a })
                .Where(j => j.ActionQSE.Responsable.Nom == ParameterResponsableNom)
                .Select(q => q.NonConformite)
                .Distinct();

                //queryNonConformite = queryNonConformite
                //    .Where(w => w.ActionQSE.Responsable.Nom == ParameterResponsableNom);
            }


            int RecordsFiltered = queryNonConformite.Count();
            int RecordsTotal = _db.NonConformites.Count();

            queryNonConformite = queryNonConformite.OrderBy(i => i.Id);

            if (ParameterIsColonne1Ordonnee == true)
            {
                switch (ParameterColonne1Sens)
                {
                    case "asc":
                        queryNonConformite = queryNonConformite.OrderBy(q => q.CompteurAnnuelSite);
                        break;
                    case "desc":
                        queryNonConformite = queryNonConformite.OrderByDescending(q => q.CompteurAnnuelSite);
                        break;
                }
            }
            if (ParameterIsColonne2Ordonnee == true)
            {
                switch (ParameterColonne2Sens)
                {
                    case "asc":
                        queryNonConformite = queryNonConformite.OrderBy(q => q.Date);
                        break;
                    case "desc":
                        queryNonConformite = queryNonConformite.OrderByDescending(q => q.Date);
                        break;
                }
            }
            if (ParameterIsColonne3Ordonnee == true)
            {
                switch (ParameterColonne3Sens)
                {
                    case "asc":
                        queryNonConformite = queryNonConformite.OrderBy(q => q.NonConformiteOrigine.Nom);
                        break;
                    case "desc":
                        queryNonConformite = queryNonConformite.OrderByDescending(q => q.NonConformiteOrigine.Nom);
                        break;
                }
            }



            if (ParameterLength != -1)
            {
                queryNonConformite = queryNonConformite.Skip(ParameterStart).Take(ParameterLength);
            }

            var AllNonConformite = queryNonConformite.ToList();

            DataTableViewModel<NonConformite> DataTableViewModel = new DataTableViewModel<NonConformite>()
            {
                recordsTotal = RecordsTotal,
                recordsFiltered = RecordsFiltered,
                data = AllNonConformite
            };


            return DataTableViewModel;

        }



    }
}