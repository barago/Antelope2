using Antelope.Domain.Models;
using Antelope.DTOs.QSE;
using Antelope.Infrastructure.EntityFramework;
using Antelope.ViewModels.HSE.FicheSecuriteViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Diagnostics;

namespace Antelope.Controllers.API.QSE
{
    public class QSEStatistiqueController : ApiController
    {

        private AntelopeEntities db = new AntelopeEntities();

        public HttpResponseMessage GetQSEStatistique()
        {

            DateTime DateDebut = new DateTime(DateTime.Now.Year, 1, 1).AddYears(-1);
            DateTime DateFin = DateTime.Now.AddDays(+1);

            var queryNonConformite = from n in db.NonConformites
                                     where n.Date >= DateDebut
                                     && n.Date <= DateFin
                                     && n.ServiceType.Nom.Equals("Qualité R/D")
                                     select new NonConformiteStatistique { Id = n.Id, DateEvnmt = n.Date, SiteId = n.SiteId, Site = n.Site.Trigramme, NonConformiteOrigineId = n.NonConformiteOrigineId, NonConformiteDomaineId = n.NonConformiteDomaineId, NonConformiteGraviteId = n.NonConformiteGraviteId, ActionQSEs = n.ActionQSEs, Code = n.Code};

            var AllNonConformite = queryNonConformite.ToList();

            foreach (var FS in AllNonConformite)
            {
                FS.TimeStamp = (Int32)(FS.DateEvnmt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            }

            List<Site> AllSite = db.Sites.ToList();

            List<NonConformiteDomaine> AllDomaine = db.NonConformiteDomaines.ToList();
            List<NonConformiteOrigine> AllOrigine = db.NonConformiteOrigines.Where(w => w.ServiceType.Nom.Equals("Qualité R/D")).ToList();
            List<NonConformiteGravite> AllGravite = db.NonConformiteGravites.ToList();

            Dictionary<string, Object> Response = new Dictionary<string, Object>();
            Dictionary<string, Object> ParamModel = new Dictionary<string, Object>();
            Response.Add("AllNonConformite", AllNonConformite);
            Response.Add("AllSite", AllSite);
            Response.Add("AllDomaine", AllDomaine);
            Response.Add("AllOrigine", AllOrigine);
            Response.Add("AllGravite", AllGravite);
            ParamModel.Add("DateDebut", DateDebut);
            ParamModel.Add("DateFin", DateFin);
            Response.Add("ParamModel", ParamModel);


            return Request.CreateResponse(HttpStatusCode.OK, Response);
        }

        public HttpResponseMessage StatistiqueFiltered(StatistiquePyramideParamModel statistiquePyramideParamModel)
        {

            //Dictionary<string, string> DataTableParameters = new Dictionary<string, string>();
            //DataTableParameters = Request.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);

            DateTime ParameterDateDebut = statistiquePyramideParamModel.DateDebut;
            DateTime ParameterDateFin = statistiquePyramideParamModel.DateFin;

            DateTime DateDebut = ParameterDateDebut;
            DateTime DateFin = ParameterDateFin.AddDays(+1);

            var queryNonConformite = from n in db.NonConformites
                                     where n.Date >= DateDebut
                                     && n.Date <= DateFin
                                     && n.ServiceType.Nom.Equals("Qualité R/D")
                                     select new NonConformiteStatistique { Id = n.Id, DateEvnmt = n.Date, SiteId = n.SiteId, Site = n.Site.Trigramme, NonConformiteOrigineId = n.NonConformiteOrigineId, NonConformiteDomaineId = n.NonConformiteDomaineId, NonConformiteGraviteId = n.NonConformiteGraviteId, ActionQSEs = n.ActionQSEs, Code = n.Code };

            var AllNonConformite = queryNonConformite.ToList();

            foreach (var NC in AllNonConformite)
            {
                NC.TimeStamp = (Int32)(NC.DateEvnmt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            }

            Dictionary<string, Object> Response = new Dictionary<string, Object>();
            Response.Add("AllNonConformite", AllNonConformite);


            return Request.CreateResponse(HttpStatusCode.OK, AllNonConformite);
        }
    }
}