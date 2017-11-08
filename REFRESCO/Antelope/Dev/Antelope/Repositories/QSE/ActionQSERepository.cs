using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;

using Antelope.DTOs.QSE;
using Antelope.Extensions;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Models.HSE;
using Antelope.Models.QSE;
using Antelope.ViewModels.Socle.DataTables;

using ActionQSE = Antelope.Domain.Models.ActionQSE;
using FicheSecurite = Antelope.Domain.Models.FicheSecurite;

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


        public DataTableViewModel<ActionQSEDTO> GetFromParams(ActionParams actionParams)
        {
            var allActionQse = FilterActions(actionParams);

            int recordsFiltered = allActionQse.Count();

            if (actionParams.Length != -1)
            {
                allActionQse = allActionQse.Skip(actionParams.Start).Take(actionParams.Length);
            }

            DataTableViewModel<ActionQSEDTO> dataTableViewModel = new DataTableViewModel<ActionQSEDTO>
            {
                recordsTotal = _db.ActionQSEs.Count(),
                recordsFiltered = recordsFiltered,
                data = allActionQse.ToList()
            };

            return dataTableViewModel;
        }

        private IQueryable<ActionQSEDTO> FilterActions(ActionParams actionParams)
        {
            try
            {
                IQueryable<ActionQSEDTO> queryActionQSE = from a in _db.ActionQSEs
                                                          join nc in _db.NonConformites on a.NonConformiteId equals nc.Id
                                                          orderby nc.Date
                                                          select new ActionQSEDTO
                                                          {
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

                if (!actionParams.ShowArchived)
                {
                    DateTime lastShowingYear = new DateTime(DateTime.Now.Year - 2, 1, 1);
                    queryActionQSE = queryActionQSE.Where(q => !q.ClotureDate.HasValue || (q.ClotureDate.HasValue && q.ClotureDate.Value.Year > lastShowingYear.Year));
                }

                List<Expression<Func<ActionQSEDTO, bool>>> actionsFilter = new List<Expression<Func<ActionQSEDTO, bool>>>();

                List<bool> filters = actionParams.GetBoolFilters();

                if (!filters.All(x => x) && filters.Any(x => x))
                {
                    if (actionParams.IsActionEnCours)
                    {
                        actionsFilter.Add(ActionQSEDTO.EnCours);
                    }
                    if (actionParams.IsActionRealise)
                    {
                        actionsFilter.Add(ActionQSEDTO.Realisees);
                    }
                    if (actionParams.IsActionRetard)
                    {
                        actionsFilter.Add(ActionQSEDTO.EnRetard);
                    }
                    if (actionParams.IsActionCloture)
                    {
                        actionsFilter.Add(ActionQSEDTO.Cloturees);
                    }

                    queryActionQSE = queryActionQSE.Where(actionsFilter.Join());
                }

                if (actionParams.SiteId != 0)
                {
                    queryActionQSE = queryActionQSE.Where(q => q.NonConformite.SiteId == actionParams.SiteId);
                }
                if (actionParams.ServiceTypeId != 0)
                {
                    queryActionQSE = queryActionQSE.Where(q => q.NonConformite.ServiceTypeId == actionParams.ServiceTypeId);
                }
                if (actionParams.NonConformiteOrigineId != 0)
                {
                    queryActionQSE = queryActionQSE.Where(q => q.NonConformite.NonConformiteOrigineId == actionParams.NonConformiteOrigineId);
                }
                if (actionParams.NonConformiteGraviteId != 0)
                {
                    queryActionQSE = queryActionQSE.Where(q => q.NonConformite.NonConformiteGraviteId == actionParams.NonConformiteGraviteId);
                }
                if (actionParams.NonConformiteDomaineId != 0)
                {
                    queryActionQSE = queryActionQSE.Where(q => q.NonConformite.NonConformiteDomaineId == actionParams.NonConformiteDomaineId);
                }
                if (!string.IsNullOrEmpty(actionParams.ResponsableNom))
                {
                    queryActionQSE = queryActionQSE.Where(q => q.Responsable.Nom == actionParams.ResponsableNom);
                }
                if (actionParams.DateButoirDebut.HasValue)
                {
                    queryActionQSE = queryActionQSE.Where(q => q.DateButoireInitiale >= actionParams.DateButoirDebut || q.DateButoireNouvelle >= actionParams.DateButoirDebut);
                }
                if (actionParams.DateButoirFin.HasValue)
                {
                    queryActionQSE = queryActionQSE.Where(q => q.DateButoireInitiale <= actionParams.DateButoirFin || q.DateButoireNouvelle <= actionParams.DateButoirFin);
                }
                if (!string.IsNullOrWhiteSpace(actionParams.ActionCode))
                {
                    string actionCode = actionParams.ActionCode.Trim().ToLower();
                    queryActionQSE = queryActionQSE.Where(q => q.Titre.ToLower().Contains(actionCode));
                }
                if (!string.IsNullOrEmpty(actionParams.NonConformiteCode))
                {
                    string nonConformiteCode = actionParams.NonConformiteCode.Trim().ToLower();
                    queryActionQSE = queryActionQSE.Where(q => q.NonConformite.Code.ToLower().Contains(nonConformiteCode));
                }

                var orderOne = actionParams.Order.FirstOrDefault();
                if (orderOne != null)
                {
                    Expression<Func<ActionQSEDTO, object>> filterColumn = null;
                    switch (orderOne.OrderingColumn)
                    {
                        case 1:
                            filterColumn = q => q.NonConformite.CompteurAnnuelSite;
                            break;
                        case 3:
                            filterColumn = q => q.Responsable.Nom;
                            break;
                        case 4:
                            filterColumn = q => q.DateButoireInitiale;
                            break;
                    }

                    if (filterColumn != null)
                    {
                        queryActionQSE = queryActionQSE.ObjectSort(filterColumn, orderOne.OrderingDirection == "desc" ? SortOrder.Descending : SortOrder.Ascending);
                    }
                }

                return queryActionQSE;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataTableViewModel<FicheSecurite> GetFromParams2(FicheSecuriteParams actionParams)
        {
            try
            {
                IQueryable<FicheSecurite> queryFicheSecurite =
                    from f in _db.FicheSecurites
                    join c in _db.CauseQSEs on f.FicheSecuriteID equals c.FicheSecuriteId
                    join a in _db.ActionQSEs on c.CauseQSEId equals a.CauseQSEId
                    select f;

                List<Expression<Func<FicheSecurite, bool>>> actionsFilter = new List<Expression<Func<FicheSecurite, bool>>>();

                List<bool> filters = actionParams.GetBoolFilters();

                if (!filters.All(x => x) && filters.Any(x => x))
                {
                    if (actionParams.IsPlanActionAttente)
                    {
                        actionsFilter.Add(FicheSecurite.PlanActionAttente);
                    }
                    if (actionParams.IsPlanActionValide)
                    {
                        actionsFilter.Add(FicheSecurite.PlanActionValide);
                    }
                    if (actionParams.IsPlanActionRejete)
                    {
                        actionsFilter.Add(FicheSecurite.PlanActionRejete);
                    }
                    if (actionParams.IsPlanActionCloture)
                    {
                        actionsFilter.Add(FicheSecurite.PlanActionCloture);
                    }
                    if (actionParams.IsNouvelleFiche)
                    {
                        actionsFilter.Add(FicheSecurite.NouvelleFiche);
                    }

                    queryFicheSecurite = queryFicheSecurite.Where(actionsFilter.Join());
                }

                if (actionParams.SiteId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.SiteId == actionParams.SiteId);
                }
                if (actionParams.ZoneId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.ZoneId == actionParams.ZoneId);
                }
                if (actionParams.LieuId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.LieuId == actionParams.LieuId);
                }
                if (actionParams.TypeId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecuriteTypeId == actionParams.TypeId);
                }
                if (!string.IsNullOrEmpty(actionParams.Code))
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.Code == actionParams.Code);
                }
                if (!string.IsNullOrEmpty(actionParams.Age))
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.Age == actionParams.Age);
                }
                if (actionParams.PosteDeTravailId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.PosteDeTravailId == actionParams.PosteDeTravailId);
                }
                if (actionParams.ServiceId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.ServiceId == actionParams.ServiceId);
                }
                if (!string.IsNullOrEmpty(actionParams.PersonneConcerneeNom))
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.PersonneConcernee.Nom == actionParams.PersonneConcerneeNom);
                }
                if (!string.IsNullOrEmpty(actionParams.ResponsableNom))
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.Responsable.Nom == actionParams.ResponsableNom);
                }
                if (actionParams.CotationFrequence.HasValue && actionParams.CotationFrequence != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationFrequence == actionParams.CotationFrequence);
                }
                if (actionParams.CotationGravite.HasValue && actionParams.CotationGravite != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationGravite == actionParams.CotationGravite);
                }
                if (actionParams.RisqueId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.RisqueId == actionParams.RisqueId);
                }
                if (actionParams.DangerId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.DangerId == actionParams.DangerId);
                }
                if (actionParams.CorpsHumainZoneId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.CorpsHumainZoneId == actionParams.CorpsHumainZoneId);
                }
                if (actionParams.PlageHoraireId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.PlageHoraireId == actionParams.PlageHoraireId);
                }
                if (actionParams.DateEvenementDebut.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.DateEvenement >= actionParams.DateEvenementDebut);
                }
                if (actionParams.DateEvenementFin.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.DateEvenement <= actionParams.DateEvenementFin);
                }
                if (actionParams.DateButoirDebut.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite
                        .Join(_db.CauseQSEs, fs => fs.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                        .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                        .Where(j => j.ActionQSE2.DateButoireInitiale >= actionParams.DateButoirDebut)
                        .Select(q => q.FicheSecurite2)
                        .Distinct();
                }
                if (actionParams.DateButoirFin.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite
                    .Join(_db.CauseQSEs, fs => fs.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                    .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                    .Where(j => j.ActionQSE2.DateButoireInitiale <= actionParams.DateButoirFin)
                    .Select(q => q.FicheSecurite2)
                    .Distinct();
                }
                if (actionParams.DateClotureDebut.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite
                    .Join(_db.CauseQSEs, fs => fs.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                    .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                    .Where(j => j.ActionQSE2.ClotureDate >= actionParams.DateClotureDebut)
                    .Select(q => q.FicheSecurite2)
                    .Distinct();
                }
                if (actionParams.DateClotureFin.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite
                    .Join(_db.CauseQSEs, fs => fs.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                    .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                    .Where(j => j.ActionQSE2.ClotureDate >= actionParams.DateClotureFin)
                    .Select(q => q.FicheSecurite2)
                    .Distinct();
                }

                int recordsFiltered = queryFicheSecurite.Count();
                int recordsTotal = _db.FicheSecurites.Count();

                queryFicheSecurite = queryFicheSecurite.OrderBy(i => i.WorkFlowCloturee && i.WorkFlowASEValidee).ThenBy(i => i.WorkFlowASEValidee).ThenBy(i => i.WorkFlowASERejetee).ThenBy(i => i.WorkFlowAttenteASEValidation).ThenBy(i => i.WorkFlowDiffusee);


                var orderOne = actionParams.Order.FirstOrDefault();
                if (orderOne != null && orderOne.OrderingColumn == 1)
                {
                    switch (orderOne.OrderingDirection)
                    {
                        case "asc":
                            queryFicheSecurite = queryFicheSecurite.OrderBy(q => q.DateCreation);
                            break;
                        case "desc":
                            queryFicheSecurite = queryFicheSecurite.OrderByDescending(fs => fs.DateCreation);
                            break;
                    }
                }

                if (actionParams.Length != -1)
                {
                    queryFicheSecurite = queryFicheSecurite.Skip(actionParams.Start).Take(actionParams.Length);
                }


                var allRecords = queryFicheSecurite.ToList();

                DataTableViewModel<FicheSecurite> dataTableViewModel = new DataTableViewModel<FicheSecurite>()
                {
                    recordsTotal = recordsTotal,
                    recordsFiltered = recordsFiltered,
                    data = allRecords
                };


                return dataTableViewModel;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}