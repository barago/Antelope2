using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;

using Antelope.Domain.Models;
using Antelope.DTOs.HSE;
using Antelope.Extensions;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Models.HSE;
using Antelope.Services.HSE.Enums;
using Antelope.ViewModels.HSE.FicheSecuriteViewModels;
using Antelope.ViewModels.Socle.DataTables;

using FicheSecurite = Antelope.Domain.Models.FicheSecurite;

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

        public FicheSecuritePaginatedList GetFromParams(RechercheFicheSecuriteParamModel rechercheFicheSecuriteParamModel)
        {
            try
            {
                IQueryable<FicheSecurite> queryFicheSecurite = from a in _db.FicheSecurites
                                                               orderby a.WorkFlowCloturee && a.WorkFlowASEValidee, a.WorkFlowASEValidee, a.WorkFlowASERejetee, a.WorkFlowAttenteASEValidation, a.WorkFlowDiffusee
                                                               select a;

                if (rechercheFicheSecuriteParamModel.SiteId.HasValue && rechercheFicheSecuriteParamModel.SiteId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.SiteId == rechercheFicheSecuriteParamModel.SiteId);
                }
                if (rechercheFicheSecuriteParamModel.ZoneId.HasValue && rechercheFicheSecuriteParamModel.ZoneId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.ZoneId == rechercheFicheSecuriteParamModel.ZoneId);
                }
                if (rechercheFicheSecuriteParamModel.LieuId.HasValue && rechercheFicheSecuriteParamModel.LieuId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.LieuId == rechercheFicheSecuriteParamModel.LieuId);
                }
                if (rechercheFicheSecuriteParamModel.FicheSecuriteTypeId.HasValue && rechercheFicheSecuriteParamModel.FicheSecuriteTypeId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecuriteTypeId == rechercheFicheSecuriteParamModel.FicheSecuriteTypeId);
                }
                if (!string.IsNullOrEmpty(rechercheFicheSecuriteParamModel.Code))
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.Code == rechercheFicheSecuriteParamModel.Code);
                }
                if (!string.IsNullOrEmpty(rechercheFicheSecuriteParamModel.Age))
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.Age == rechercheFicheSecuriteParamModel.Age);
                }
                if (rechercheFicheSecuriteParamModel.PosteDeTravailId.HasValue && rechercheFicheSecuriteParamModel.PosteDeTravailId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.PosteDeTravailId == rechercheFicheSecuriteParamModel.PosteDeTravailId);
                }
                if (rechercheFicheSecuriteParamModel.ServiceId.HasValue && rechercheFicheSecuriteParamModel.ServiceId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.ServiceId == rechercheFicheSecuriteParamModel.ServiceId);
                }
                if (rechercheFicheSecuriteParamModel.DateEvenementDebut.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.DateEvenement >= rechercheFicheSecuriteParamModel.DateEvenementDebut);
                }
                if (rechercheFicheSecuriteParamModel.DateEvenementFin.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.DateEvenement <= rechercheFicheSecuriteParamModel.DateEvenementFin);
                }
                if (!string.IsNullOrEmpty(rechercheFicheSecuriteParamModel.PersonneConcerneeNom))
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.PersonneConcernee.Nom == rechercheFicheSecuriteParamModel.PersonneConcerneeNom);
                }
                if (!string.IsNullOrEmpty(rechercheFicheSecuriteParamModel.ResponsableNom))
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.Responsable.Nom == rechercheFicheSecuriteParamModel.ResponsableNom);
                }
                if (rechercheFicheSecuriteParamModel.CotationFrequence.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationFrequence == rechercheFicheSecuriteParamModel.CotationFrequence);
                }
                if (rechercheFicheSecuriteParamModel.CotationGravite.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationGravite == rechercheFicheSecuriteParamModel.CotationGravite);
                }
                if (rechercheFicheSecuriteParamModel.RisqueId.HasValue && rechercheFicheSecuriteParamModel.RisqueId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.RisqueId == rechercheFicheSecuriteParamModel.RisqueId);
                }
                if (rechercheFicheSecuriteParamModel.DangerId.HasValue && rechercheFicheSecuriteParamModel.DangerId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.DangerId == rechercheFicheSecuriteParamModel.DangerId);
                }
                if (rechercheFicheSecuriteParamModel.CorpsHumainZoneId.HasValue && rechercheFicheSecuriteParamModel.CorpsHumainZoneId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.CorpsHumainZoneId == rechercheFicheSecuriteParamModel.CorpsHumainZoneId);
                }
                if (rechercheFicheSecuriteParamModel.PlageHoraireId.HasValue && rechercheFicheSecuriteParamModel.PlageHoraireId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.PlageHoraireId == rechercheFicheSecuriteParamModel.PlageHoraireId);
                }
                if (rechercheFicheSecuriteParamModel.ResponsableGuid.HasValue && rechercheFicheSecuriteParamModel.ResponsableGuid != new Guid())
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.Responsable.Guid == rechercheFicheSecuriteParamModel.ResponsableGuid);
                }

                int totalRowCount = queryFicheSecurite.Count();

                queryFicheSecurite = queryFicheSecurite.Skip(rechercheFicheSecuriteParamModel.PageSize * (rechercheFicheSecuriteParamModel.Page - 1)).Take(rechercheFicheSecuriteParamModel.PageSize);

                List<FicheSecurite> allFicheSecurite = queryFicheSecurite.ToList();

                FicheSecuritePaginatedList ficheSecuritePaginatedList = new FicheSecuritePaginatedList
                {
                    AllFicheSecurite = allFicheSecurite,
                    Page = rechercheFicheSecuriteParamModel.Page,
                    PageSize = rechercheFicheSecuriteParamModel.PageSize,
                    RowCount = totalRowCount
                };

                return ficheSecuritePaginatedList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTableViewModel<FicheSecurite> GetAllFicheSecuriteFromParams(FicheSecuriteParams ficheSecuriteParams)
        {
            try
            {
                IQueryable<FicheSecurite> queryFicheSecurite = from f in _db.FicheSecurites select f;

                List<Expression<Func<FicheSecurite, bool>>> ficheSecuriteFilters = new List<Expression<Func<FicheSecurite, bool>>>();

                List<bool> filters = ficheSecuriteParams.GetBoolFilters();

                if (!filters.All(x => x) && filters.Any(x => x))
                {
                    if (ficheSecuriteParams.IsPlanActionAttente)
                    {
                        ficheSecuriteFilters.Add(FicheSecurite.PlanActionAttente);
                    }
                    if (ficheSecuriteParams.IsPlanActionValide)
                    {
                        ficheSecuriteFilters.Add(FicheSecurite.PlanActionValide);
                    }
                    if (ficheSecuriteParams.IsPlanActionRejete)
                    {
                        ficheSecuriteFilters.Add(FicheSecurite.PlanActionRejete);
                    }
                    if (ficheSecuriteParams.IsPlanActionCloture)
                    {
                        ficheSecuriteFilters.Add(FicheSecurite.PlanActionCloture);
                    }
                    if (ficheSecuriteParams.IsFicheSecuriteCloture)
                    {
                        ficheSecuriteFilters.Add(FicheSecurite.FicheSecuriteCloture);
                    }
                    if (ficheSecuriteParams.IsNouvelleFiche)
                    {
                        ficheSecuriteFilters.Add(FicheSecurite.NouvelleFiche);
                    }

                    queryFicheSecurite = queryFicheSecurite.Where(ficheSecuriteFilters.Join());
                }

                if (ficheSecuriteParams.SiteId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.SiteId == ficheSecuriteParams.SiteId);
                }
                if (ficheSecuriteParams.ZoneId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.ZoneId == ficheSecuriteParams.ZoneId);
                }
                if (ficheSecuriteParams.LieuId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.LieuId == ficheSecuriteParams.LieuId);
                }
                if (ficheSecuriteParams.TypeId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecuriteTypeId == ficheSecuriteParams.TypeId);
                }
                if (!string.IsNullOrEmpty(ficheSecuriteParams.Code))
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.Code == ficheSecuriteParams.Code);
                }
                if (!string.IsNullOrEmpty(ficheSecuriteParams.Age))
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.Age == ficheSecuriteParams.Age);
                }
                if (ficheSecuriteParams.PosteDeTravailId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.PosteDeTravailId == ficheSecuriteParams.PosteDeTravailId);
                }
                if (ficheSecuriteParams.ServiceId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.ServiceId == ficheSecuriteParams.ServiceId);
                }
                if (!string.IsNullOrEmpty(ficheSecuriteParams.PersonneConcerneeNom))
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.PersonneConcernee.Nom == ficheSecuriteParams.PersonneConcerneeNom);
                }
                if (!string.IsNullOrEmpty(ficheSecuriteParams.ResponsableNom))
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.Responsable.Nom == ficheSecuriteParams.ResponsableNom);
                }
                if (ficheSecuriteParams.CotationFrequence.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationFrequence == ficheSecuriteParams.CotationFrequence);
                }
                if (ficheSecuriteParams.CotationGravite.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationGravite == ficheSecuriteParams.CotationGravite);
                }
                if (ficheSecuriteParams.RisqueId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.RisqueId == ficheSecuriteParams.RisqueId);
                }
                if (ficheSecuriteParams.DangerId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.DangerId == ficheSecuriteParams.DangerId);
                }
                if (ficheSecuriteParams.CorpsHumainZoneId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.CorpsHumainZoneId == ficheSecuriteParams.CorpsHumainZoneId);
                }
                if (ficheSecuriteParams.PlageHoraireId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.PlageHoraireId == ficheSecuriteParams.PlageHoraireId);
                }
                if (ficheSecuriteParams.Criticite != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationFrequence * q.CotationGravite == ficheSecuriteParams.Criticite);
                }
                if (ficheSecuriteParams.CriticiteNiveau != CriticiteNiveauEnum.NULL)
                {
                    switch (ficheSecuriteParams.CriticiteNiveau)
                    {
                        case CriticiteNiveauEnum.BAS:
                            queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationFrequence * q.CotationGravite < 8);
                            break;
                        case CriticiteNiveauEnum.MOYEN:
                            queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationFrequence * q.CotationGravite >= 8 && q.CotationFrequence * q.CotationGravite <= 20);
                            break;
                        case CriticiteNiveauEnum.HAUT:
                            queryFicheSecurite = queryFicheSecurite.Where(q => q.CotationFrequence * q.CotationGravite > 20);
                            break;
                    }
                }
                if (ficheSecuriteParams.DateEvenementDebut.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.DateEvenement >= ficheSecuriteParams.DateEvenementDebut);
                }
                if (ficheSecuriteParams.DateEvenementFin.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.DateEvenement <= ficheSecuriteParams.DateEvenementFin);
                }
                if (ficheSecuriteParams.DateButoirDebut.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite
                        .Join(_db.CauseQSEs, fs => fs.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                        .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                        .Where(j => j.ActionQSE2.DateButoireInitiale >= ficheSecuriteParams.DateButoirDebut)
                        .Select(q => q.FicheSecurite2)
                        .Distinct();
                }
                if (ficheSecuriteParams.DateButoirFin.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite
                    .Join(_db.CauseQSEs, fs => fs.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                    .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                    .Where(j => j.ActionQSE2.DateButoireInitiale <= ficheSecuriteParams.DateButoirFin)
                    .Select(q => q.FicheSecurite2)
                    .Distinct();
                }
                if (ficheSecuriteParams.DateClotureDebut.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite
                    .Join(_db.CauseQSEs, fs => fs.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                    .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                    .Where(j => j.ActionQSE2.ClotureDate >= ficheSecuriteParams.DateClotureDebut)
                    .Select(q => q.FicheSecurite2)
                    .Distinct();
                }
                if (ficheSecuriteParams.DateClotureFin.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite
                    .Join(_db.CauseQSEs, fs => fs.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                    .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                    .Where(j => j.ActionQSE2.ClotureDate >= ficheSecuriteParams.DateClotureFin)
                    .Select(q => q.FicheSecurite2)
                    .Distinct();
                }

                if (!string.IsNullOrEmpty(ficheSecuriteParams.ResponsableNomAction))
                {
                    queryFicheSecurite = queryFicheSecurite
                    .Join(_db.CauseQSEs, fs => fs.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                    .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                    .Where(j => j.ActionQSE2.Responsable.Nom == ficheSecuriteParams.ResponsableNomAction)
                    .Select(q => q.FicheSecurite2)
                    .Distinct();
                }

                int recordsFiltered = queryFicheSecurite.Count();
                int recordsTotal = _db.FicheSecurites.Count();

                queryFicheSecurite = queryFicheSecurite
                    .OrderBy(i => i.WorkFlowFicheSecuriteCloturee).ThenBy(i => i.WorkFlowCloturee && i.WorkFlowASEValidee).ThenBy(i => i.WorkFlowASEValidee).ThenBy(i => i.WorkFlowASERejetee).ThenBy(i => i.WorkFlowAttenteASEValidation).ThenBy(i => i.WorkFlowDiffusee);

                var orderOne = ficheSecuriteParams.Order.FirstOrDefault();
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

                if (ficheSecuriteParams.Length != -1)
                {
                    queryFicheSecurite = queryFicheSecurite.Skip(ficheSecuriteParams.Start).Take(ficheSecuriteParams.Length);
                }

                foreach (var ficheSecurite in queryFicheSecurite)
                {
                    ficheSecurite.Actions = ficheSecurite.CauseQSEs?.SelectMany(x => x.ActionQSEs)?.Select(y => $"{y.CauseQS.Description} => {y.Description}")?.ToList();
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
                return null;
            }
        }

        public DataTableViewModel<FicheSecuriteActionRecherche> GetAllActionFromParams(FicheSecuriteParams ficheSecuriteParams)
        {
            try
            {
                var queryFicheSecurite =
                              from f in _db.FicheSecurites
                              join c in _db.CauseQSEs on f.FicheSecuriteID equals c.FicheSecuriteId
                              join a in _db.ActionQSEs on c.CauseQSEId equals a.CauseQSEId
                              select new FicheSecuriteActionRecherche { FicheSecurite = f, CauseQSE = c, ActionQSE = a };

                //TO CHECK : Peut-il etre REJETE ET EN ATTENTE VALIDATION

                List<Expression<Func<FicheSecuriteActionRecherche, bool>>> ficheSecuriteActionFilters = new List<Expression<Func<FicheSecuriteActionRecherche, bool>>>();
                List<bool> filters = ficheSecuriteParams.GetBoolFilters();

                if (!filters.All(x => x) && filters.Any(x => x))
                {
                    if (ficheSecuriteParams.IsPlanActionAttente)
                    {
                        ficheSecuriteActionFilters.Add(FicheSecuriteActionRecherche.PlanActionAttente);
                    }
                    if (ficheSecuriteParams.IsPlanActionValide)
                    {
                        ficheSecuriteActionFilters.Add(FicheSecuriteActionRecherche.PlanActionValide);
                    }
                    if (ficheSecuriteParams.IsPlanActionRejete)
                    {
                        ficheSecuriteActionFilters.Add(FicheSecuriteActionRecherche.PlanActionRejete);
                    }
                    if (ficheSecuriteParams.IsPlanActionCloture)
                    {
                        ficheSecuriteActionFilters.Add(FicheSecuriteActionRecherche.PlanActionCloture);
                    }
                    if (ficheSecuriteParams.IsFicheSecuriteCloture)
                    {
                        ficheSecuriteActionFilters.Add(FicheSecuriteActionRecherche.FicheSecuriteCloture);
                    }
                    if (ficheSecuriteParams.IsNouvelleFiche)
                    {
                        ficheSecuriteActionFilters.Add(FicheSecuriteActionRecherche.NouvelleFiche);
                    }

                    queryFicheSecurite = queryFicheSecurite.Where(ficheSecuriteActionFilters.Join());
                }

                if (ficheSecuriteParams.SiteId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.SiteId == ficheSecuriteParams.SiteId);
                }
                if (ficheSecuriteParams.ZoneId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.ZoneId == ficheSecuriteParams.ZoneId);
                }
                if (ficheSecuriteParams.LieuId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.LieuId == ficheSecuriteParams.LieuId);
                }
                if (ficheSecuriteParams.TypeId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.FicheSecuriteTypeId == ficheSecuriteParams.TypeId);
                }
                if (!string.IsNullOrEmpty(ficheSecuriteParams.Code))
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.Code == ficheSecuriteParams.Code);
                }
                if (!string.IsNullOrEmpty(ficheSecuriteParams.Age))
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.Age == ficheSecuriteParams.Age);
                }
                if (ficheSecuriteParams.PosteDeTravailId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.PosteDeTravailId == ficheSecuriteParams.PosteDeTravailId);
                }
                if (ficheSecuriteParams.ServiceId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.ServiceId == ficheSecuriteParams.ServiceId);
                }
                if (!string.IsNullOrEmpty(ficheSecuriteParams.PersonneConcerneeNom))
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.PersonneConcernee.Nom == ficheSecuriteParams.PersonneConcerneeNom);
                }
                if (!string.IsNullOrEmpty(ficheSecuriteParams.ResponsableNom))
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.Responsable.Nom == ficheSecuriteParams.ResponsableNom);
                }
                if (ficheSecuriteParams.CotationFrequence.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.CotationFrequence == ficheSecuriteParams.CotationFrequence);
                }
                if (ficheSecuriteParams.CotationGravite.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.CotationGravite == ficheSecuriteParams.CotationGravite);
                }
                if (ficheSecuriteParams.RisqueId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.RisqueId == ficheSecuriteParams.RisqueId);
                }
                if (ficheSecuriteParams.DangerId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.DangerId == ficheSecuriteParams.DangerId);
                }
                if (ficheSecuriteParams.CorpsHumainZoneId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.CorpsHumainZoneId == ficheSecuriteParams.CorpsHumainZoneId);
                }
                if (ficheSecuriteParams.PlageHoraireId != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.PlageHoraireId == ficheSecuriteParams.PlageHoraireId);
                }
                if (ficheSecuriteParams.DateEvenementDebut.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.DateEvenement >= ficheSecuriteParams.DateEvenementDebut);
                }
                if (ficheSecuriteParams.DateEvenementFin.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.DateEvenement <= ficheSecuriteParams.DateEvenementFin);
                }
                if (ficheSecuriteParams.Criticite != 0)
                {
                    queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.CotationFrequence * q.FicheSecurite.CotationGravite == ficheSecuriteParams.Criticite);
                }
                if (ficheSecuriteParams.CriticiteNiveau != CriticiteNiveauEnum.NULL)
                {
                    switch (ficheSecuriteParams.CriticiteNiveau)
                    {
                        case CriticiteNiveauEnum.BAS:
                            queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.CotationFrequence * q.FicheSecurite.CotationGravite < 8);
                            break;
                        case CriticiteNiveauEnum.MOYEN:
                            queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.CotationFrequence * q.FicheSecurite.CotationGravite >= 8 && q.FicheSecurite.CotationFrequence * q.FicheSecurite.CotationGravite <= 20);
                            break;
                        case CriticiteNiveauEnum.HAUT:
                            queryFicheSecurite = queryFicheSecurite.Where(q => q.FicheSecurite.CotationFrequence * q.FicheSecurite.CotationGravite > 20);
                            break;
                    }
                }
                if (ficheSecuriteParams.DateButoirDebut != null)
                {
                    queryFicheSecurite = queryFicheSecurite
                        .Join(_db.CauseQSEs, fs => fs.FicheSecurite.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                        .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                        .Select(q => q.FicheSecurite2)
                        .Distinct();

                    queryFicheSecurite = queryFicheSecurite
                    .Where(w => w.ActionQSE.DateButoireInitiale >= ficheSecuriteParams.DateButoirDebut);
                }
                if (ficheSecuriteParams.DateButoirFin != null)
                {
                    queryFicheSecurite = queryFicheSecurite
                    .Join(_db.CauseQSEs, fs => fs.FicheSecurite.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                    .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                    .Select(q => q.FicheSecurite2)
                    .Distinct();

                    queryFicheSecurite = queryFicheSecurite
                    .Where(w => w.ActionQSE.DateButoireInitiale <= ficheSecuriteParams.DateButoirFin);
                }
                if (ficheSecuriteParams.DateClotureDebut.HasValue)
                {
                    queryFicheSecurite = queryFicheSecurite
                    .Join(_db.CauseQSEs, fs => fs.FicheSecurite.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                    .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                    .Select(q => q.FicheSecurite2)
                    .Distinct();

                    queryFicheSecurite = queryFicheSecurite
                    .Where(w => w.ActionQSE.ClotureDate >= ficheSecuriteParams.DateClotureDebut);
                }
                if (ficheSecuriteParams.DateClotureFin != null)
                {
                    queryFicheSecurite = queryFicheSecurite
                    .Join(_db.CauseQSEs, fs => fs.FicheSecurite.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                    .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                    .Select(q => q.FicheSecurite2)
                    .Distinct();

                    queryFicheSecurite = queryFicheSecurite
                    .Where(w => w.ActionQSE.ClotureDate <= ficheSecuriteParams.DateClotureFin);
                }
                if (!string.IsNullOrEmpty(ficheSecuriteParams.ResponsableNomAction))
                {
                    queryFicheSecurite = queryFicheSecurite
                    .Join(_db.CauseQSEs, fs => fs.FicheSecurite.FicheSecuriteID, c => c.FicheSecuriteId, (fs, c) => new { FicheSecurite = fs, CauseQSE = c })
                    .Join(_db.ActionQSEs, fs2 => fs2.CauseQSE.CauseQSEId, a => a.CauseQSEId, (fs2, a) => new { FicheSecurite2 = fs2.FicheSecurite, CauseQSE2 = fs2.CauseQSE, ActionQSE2 = a })
                    .Select(q => q.FicheSecurite2)
                    .Distinct();

                    queryFicheSecurite = queryFicheSecurite
                        .Where(w => w.ActionQSE.Responsable.Nom == ficheSecuriteParams.ResponsableNomAction);
                }

                int recordsFiltered = queryFicheSecurite.Count();
                int recordsTotal = _db.FicheSecurites.Count();

                queryFicheSecurite = queryFicheSecurite.OrderBy(i => i.FicheSecurite.WorkFlowFicheSecuriteCloturee).ThenBy(i => i.FicheSecurite.WorkFlowCloturee && i.FicheSecurite.WorkFlowASEValidee).ThenBy(i => i.FicheSecurite.WorkFlowASEValidee).ThenBy(i => i.FicheSecurite.WorkFlowASERejetee).ThenBy(i => i.FicheSecurite.WorkFlowAttenteASEValidation).ThenBy(i => i.FicheSecurite.WorkFlowDiffusee);

                var orderOne = ficheSecuriteParams.Order.FirstOrDefault();
                if (orderOne != null)
                {
                    Expression<Func<FicheSecuriteActionRecherche, object>> filterColumn = null;
                    switch (orderOne.OrderingColumn)
                    {
                        case 1:
                            filterColumn = q => q.FicheSecurite.DateCreation;
                            break;
                        case 2:
                            filterColumn = q => q.ActionQSE.Responsable.Nom;
                            break;
                        case 4:
                            filterColumn = q => q.ActionQSE.DateButoireInitiale;
                            break;
                        case 5:
                            filterColumn = q => q.ActionQSE.DateButoireNouvelle;
                            break;
                        case 6:
                            filterColumn = q => q.ActionQSE.ClotureDate;
                            break;
                    }

                    if (filterColumn != null)
                    {
                        queryFicheSecurite = queryFicheSecurite.ObjectSort(filterColumn, orderOne.OrderingDirection == "desc" ? SortOrder.Descending : SortOrder.Ascending);
                    }
                }

                if (ficheSecuriteParams.Length != -1)
                {
                    queryFicheSecurite = queryFicheSecurite.Skip(ficheSecuriteParams.Start).Take(ficheSecuriteParams.Length);
                }

                var allRecords = queryFicheSecurite.ToList();

                DataTableViewModel<FicheSecuriteActionRecherche> dataTableViewModel = new DataTableViewModel<FicheSecuriteActionRecherche>
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