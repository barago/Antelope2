using System;
using System.Collections.Generic;
using System.Linq;
using Antelope.Domain.Models;
using Antelope.DTOs.HSE;
using Antelope.Infrastructure.EntityFramework;
using Antelope.ViewModels.HSE.FicheSecuriteViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Antelope.ViewModels.HSE.DialogueSecuriteViewModels;

namespace Antelope.Controllers.API.HSE
{
    public class DialogueSecuriteStatistiqueController : ApiController
    {

        private AntelopeEntities db = new AntelopeEntities();

        public HttpResponseMessage GetDialogueSecuriteStatistique()
        {

            DateTime DateDebut = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime DateFin = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);

            var queryDialogueSecurite = from d in db.DialogueSecurites
                                        where d.Date >= DateDebut
                                        && d.Date <= DateFin
                                        select new DialogueSecuriteStatistique
                                        {
                                            Id = d.Id,
                                            Date = d.Date,
                                            SiteId = d.SiteId,
                                            Site = d.Site.Trigramme,
                                            ZoneId = d.ZoneId,
                                            Dialogueur1Id = d.Dialogueur1Id,
                                            Dialogueur2Id = d.Dialogueur2Id,
                                            Dialogueur3Id = d.Dialogueur3Id,
                                            Entretenu1Id = d.Entretenu1Id,
                                            Entretenu2Id = d.Entretenu2Id,
                                            Entretenu3Id = d.Entretenu3Id,
                                            Dialogueur1 = d.Dialogueur1,
                                            Dialogueur2 = d.Dialogueur2,
                                            Dialogueur3 = d.Dialogueur3,
                                            Entretenu1 = d.Entretenu1,
                                            Entretenu2 = d.Entretenu2,
                                            Entretenu3 = d.Entretenu3,
                                            ServiceTypeDialogueur1Id = d.ServiceTypeDialogueur1Id,
                                            ServiceTypeDialogueur2Id = d.ServiceTypeDialogueur2Id,
                                            ServiceTypeDialogueur3Id = d.ServiceTypeDialogueur3Id,
                                            ServiceTypeEntretenu1Id = d.ServiceTypeEntretenu1Id,
                                            ServiceTypeEntretenu2Id = d.ServiceTypeEntretenu2Id,
                                            ServiceTypeEntretenu3Id = d.ServiceTypeEntretenu3Id,
                                            ThematiqueId = d.ThematiqueId
                                        };

            var AllDialogueSecurite = queryDialogueSecurite.ToList();

            foreach (var DS in AllDialogueSecurite)
            {
                DS.TimeStamp = (Int32)(DS.Date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            }

            List<Site> AllSite = db.Sites.ToList();
            List<Zone> AllZone = db.Zones.ToList();
            List<Service> AllService = db.Services.ToList();
            List<Thematique> AllThematique = db.Thematiques.ToList();
            List<ServiceType> AllServiceType = db.ServiceTypes.ToList();

            Dictionary<string, Object> Response = new Dictionary<string, Object>();
            Dictionary<string, Object> ParamModel = new Dictionary<string, Object>();
            Response.Add("AllDialogueSecurite", AllDialogueSecurite);
            Response.Add("AllSite", AllSite);
            Response.Add("AllZone", AllZone);
            Response.Add("AllService", AllService);
            Response.Add("AllThematique", AllThematique);
            ParamModel.Add("DateDebut", DateDebut);
            ParamModel.Add("DateFin", DateFin);
            Response.Add("ParamModel", ParamModel);
            Response.Add("AllServiceType",AllServiceType);


            return Request.CreateResponse(HttpStatusCode.OK, Response);
        }


        public HttpResponseMessage DialogueSecuriteStatistiqueFiltered(StatistiquePyramideParamModel statistiquePyramideParamModel)
        {

            //Dictionary<string, string> DataTableParameters = new Dictionary<string, string>();
            //DataTableParameters = Request.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);

            DateTime ParameterDateDebut = statistiquePyramideParamModel.DateDebut;
            DateTime ParameterDateFin = statistiquePyramideParamModel.DateFin;

            DateTime DateDebut = ParameterDateDebut;
            DateTime DateFin = ParameterDateFin.AddDays(+1);

            var queryDialogueSecurite = from d in db.DialogueSecurites
                                        where d.Date >= DateDebut
                                        && d.Date <= DateFin
                                        select new DialogueSecuriteStatistique
                                        {
                                            Id = d.Id,
                                            Date = d.Date,
                                            SiteId = d.SiteId,
                                            Site = d.Site.Trigramme,
                                            ZoneId = d.ZoneId,
                                            Dialogueur1Id = d.Dialogueur1Id,
                                            Dialogueur2Id = d.Dialogueur2Id,
                                            Dialogueur3Id = d.Dialogueur3Id,
                                            Entretenu1Id = d.Entretenu1Id,
                                            Entretenu2Id = d.Entretenu2Id,
                                            Entretenu3Id = d.Entretenu3Id,
                                            Dialogueur1 = d.Dialogueur1,
                                            Dialogueur2 = d.Dialogueur2,
                                            Dialogueur3 = d.Dialogueur3,
                                            Entretenu1 = d.Entretenu1,
                                            Entretenu2 = d.Entretenu2,
                                            Entretenu3 = d.Entretenu3
                                        };

            var AllDialogueSecurite = queryDialogueSecurite.ToList();

            foreach (var DS in AllDialogueSecurite)
            {
                DS.TimeStamp = (Int32)(DS.Date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            }

            Dictionary<string, Object> Response = new Dictionary<string, Object>();
            Response.Add("AllDialogueSecurite", AllDialogueSecurite);


            return Request.CreateResponse(HttpStatusCode.OK, AllDialogueSecurite);
        }

        [HttpPost]
        public HttpResponseMessage GetByParameters(StatistiqueDialogueSecuriteParamModel statistiqueDialogueSecuriteParamModel) //, String dateDebut, String dateFin
        {

            Dictionary<string, string> DataTableParameters = new Dictionary<string, string>();
            DataTableParameters = Request.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);


            //            Int32 ParameterStart = Int32.Parse(DataTableParameters["start"]);
            //Int32 ParameterLength = Int32.Parse(DataTableParameters["length"]);

            //Int32? ParameterSiteId = statistiqueDialogueSecuriteParamModel.SiteId;
            //string ParameterAtelier = DataTableParameters["atelier"];
            DateTime? ParameterDateDebut = statistiqueDialogueSecuriteParamModel.DateDebut;
            DateTime? ParameterDateFin = statistiqueDialogueSecuriteParamModel.DateFin;


            //if (DataTableParameters["dateDebut"] != "")
            //{
            //    try
            //    {
            //        ParameterDateDebut = DateTime.Parse(DataTableParameters["dateDebut"]);
            //    }
            //    catch (Exception e)
            //    {

            //    }
            //}
            //if (DataTableParameters["dateFin"] != "")
            //{
            //    try
            //    {
            //        ParameterDateFin = DateTime.Parse(DataTableParameters["dateFin"]);
            //    }
            //    catch (Exception e)
            //    {

            //    }
            //}

            List<DialogueSecurite> AllDialogueSecurite = new List<DialogueSecurite>();

            //if (ParameterSiteId == 0)
            //{
                var queryDS = from a in db.DialogueSecurites
                              where a.Date >= ParameterDateDebut
                              && a.Date <= ParameterDateFin
                              select a;
                AllDialogueSecurite = queryDS.ToList();
            //}
            //else
            //{
                //var queryDS = from a in db.DialogueSecurites
                //              where a.SiteId == ParameterSiteId
                //              && a.Date >= ParameterDateDebut
                //              && a.Date <= ParameterDateFin
                //              select a;
                //AllDialogueSecurite = queryDS.ToList();
            //}

            return Request.CreateResponse(HttpStatusCode.OK, AllDialogueSecurite);
        }



    }
}
