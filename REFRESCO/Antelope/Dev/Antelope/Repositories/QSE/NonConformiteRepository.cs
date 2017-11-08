using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

using Antelope.Domain.Models;
using Antelope.Extensions;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Models.QSE;
using Antelope.ViewModels.Socle.DataTables;

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
            NonConformite nonConformite = _db.NonConformites.SingleOrDefault(r => r.Id == id);
            return nonConformite;
        }

        public DataTableViewModel<NonConformite> GetFromParams(NonConformiteParams nonConformiteParams)
        {
            var allNonConformite = FilterNonConformites(nonConformiteParams);
            int recordsFiltered = allNonConformite.Count();
            if (nonConformiteParams.Length != -1)
            {
                allNonConformite = allNonConformite.Skip(nonConformiteParams.Start).Take(nonConformiteParams.Length);
            }

            DataTableViewModel<NonConformite> dataTableViewModel = new DataTableViewModel<NonConformite>()
            {
                recordsTotal = _db.NonConformites.Count(),
                recordsFiltered = recordsFiltered,
                data = allNonConformite.ToList()
            };

            return dataTableViewModel;
        }

        private IQueryable<NonConformite> FilterNonConformites(NonConformiteParams nonConformiteParams)
        {
            try
            {
                var queryNonConformite = from nc in _db.NonConformites select nc;

                if (!nonConformiteParams.ShowArchived)
                {
                    DateTime lastShowingYear = new DateTime(DateTime.Now.Year - 2, 1, 1);
                    queryNonConformite = queryNonConformite.Where(q => q.ActionQSEs.Any(x => !x.ClotureDate.HasValue || (x.ClotureDate.HasValue && x.ClotureDate.Value.Year > lastShowingYear.Year)));
                }

                if (!nonConformiteParams.IsNCEnCours || !nonConformiteParams.IsNCCloture)
                {
                    if (nonConformiteParams.IsNCCloture)
                    {
                        var queryNonConformiteBis = queryNonConformite
                            .Join(_db.ActionQSEs, nc => nc.Id, a => a.NonConformiteId, (nc, a) => new { NonConformite = nc, ActionQSE = a })
                            .Where(j => j.ActionQSE.VerifieDate == null)
                            .Select(q => q.NonConformite)
                            .Distinct();

                        queryNonConformite = queryNonConformite.Except(queryNonConformiteBis);

                        queryNonConformite = queryNonConformite.Where(q => q.ActionQSEs.Count > 0);
                    }
                    if (nonConformiteParams.IsNCEnCours)
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
                if (nonConformiteParams.SiteId != 0)
                {
                    queryNonConformite = queryNonConformite.Where(q => q.SiteId == nonConformiteParams.SiteId);
                }
                if (nonConformiteParams.ServiceTypeId != 0)
                {
                    queryNonConformite = queryNonConformite.Where(q => q.ServiceTypeId == nonConformiteParams.ServiceTypeId);
                }
                if (nonConformiteParams.NonConformiteOrigineId != 0)
                {
                    queryNonConformite = queryNonConformite.Where(q => q.NonConformiteOrigineId == nonConformiteParams.NonConformiteOrigineId);
                }
                if (nonConformiteParams.NonConformiteGraviteId != 0)
                {
                    queryNonConformite = queryNonConformite.Where(q => q.NonConformiteGraviteId == nonConformiteParams.NonConformiteGraviteId);
                }
                if (nonConformiteParams.NonConformiteDomaineId != 0)
                {
                    queryNonConformite = queryNonConformite.Where(q => q.NonConformiteDomaineId == nonConformiteParams.NonConformiteDomaineId);
                }
                if (!string.IsNullOrEmpty(nonConformiteParams.ResponsableNom))
                {
                    queryNonConformite = queryNonConformite
                    .Join(_db.ActionQSEs, nc => nc.Id, a => a.NonConformiteId, (nc, a) => new { NonConformite = nc, ActionQSE = a })
                    .Where(j => j.ActionQSE.Responsable.Nom == nonConformiteParams.ResponsableNom)
                    .Select(q => q.NonConformite)
                    .Distinct();
                }
                if (!string.IsNullOrEmpty(nonConformiteParams.NonConformiteCode))
                {
                    string nonConformiteCode = nonConformiteParams.NonConformiteCode.Trim().ToLower();
                    queryNonConformite = queryNonConformite.Where(q => q.Code.Contains(nonConformiteCode));
                }

                queryNonConformite = queryNonConformite.OrderBy(i => i.Id);

                var orderOne = nonConformiteParams.Order.FirstOrDefault();
                if (orderOne != null)
                {
                    Expression<Func<NonConformite, object>> filterColumn = null;
                    switch (orderOne.OrderingColumn)
                    {
                        case 1:
                            filterColumn = q => q.CompteurAnnuelSite;
                            break;
                        case 2:
                            filterColumn = q => q.Date;
                            break;
                        case 3:
                            filterColumn = q => q.NonConformiteOrigine.Nom;
                            break;
                    }

                    if (filterColumn != null)
                    {
                        queryNonConformite = queryNonConformite.ObjectSort(filterColumn, orderOne.OrderingDirection == "desc" ? SortOrder.Descending : SortOrder.Ascending);
                    } 

                }
                return queryNonConformite;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}