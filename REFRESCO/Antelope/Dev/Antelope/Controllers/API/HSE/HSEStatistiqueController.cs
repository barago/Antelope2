using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Antelope.Domain.Models;
using Antelope.DTOs.HSE;
using Antelope.Infrastructure.EntityFramework;
using Antelope.ViewModels.HSE.FicheSecuriteViewModels;

namespace Antelope.Controllers.API.HSE
{
    /// <summary>
    /// Contrôleur dédié au statistique HSE.
    /// </summary>
    public class HSEStatistiqueController : ApiController
    {
        private AntelopeEntities db = new AntelopeEntities();

        /// <summary>
        /// Obtention des fiches sécurité et autre objet lié à la page pyramide sécurité.
        /// </summary>
        /// <returns>Réponse http.</returns>
        public HttpResponseMessage GetHSEStatistique()
        {
            try
            {
                DateTime dateDebut = new DateTime(DateTime.Now.Year, 1, 1);
                DateTime dateFin = DateTime.Now.AddDays(1);

                var queryFicheSecurite =
                    from f in db.FicheSecurites
                    where f.DateEvenement >= dateDebut && f.DateEvenement <= dateFin
                    select
                        new FicheSecuriteStatistique
                        {
                            Id = f.FicheSecuriteID,
                            DateEvnmt = f.DateEvenement,
                            SiteId = f.SiteId,
                            Site = f.Site.Trigramme,
                            ZoneId = f.ZoneId,
                            CauseQSEs = f.CauseQSEs,
                            FicheSecuriteType = f.FicheSecuriteType.Nom,
                            Responsable = f.Responsable,
                            FicheSecurtiteTypeID = f.FicheSecuriteTypeId,
                            WorkFlowASEValidee = f.WorkFlowASEValidee,
                            WorkFlowFicheSecuriteCloturee = f.WorkFlowFicheSecuriteCloturee,
                            WorkFlowCloturee = f.WorkFlowCloturee,
                            ServiceId = f.ServiceId,
                            Service = f.Service.ServiceType.Nom, // Service
                            Danger = f.Danger.Nom, // Danger
                            DangerId = f.Danger.DangerID, // Danger
                            CorpsHumainZoneId = f.CorpsHumainZoneId, // Lésions
                            CorpsHumainZoneCode = f.CorpsHumainZone.Code, // Lésions
                            CorpsHumainZone = f.CorpsHumainZone.Nom, // Lésions
                            //TimeStamp = (int)f.DateEvenement.Subtract(new DateTime(1970, 1, 1)).TotalSeconds
                        };

                var queryDialogueSecurite = from ds in db.DialogueSecurites
                                            where ds.Date >= dateDebut && ds.Date <= dateFin
                                            select new { Id = ds.Id, Site = ds.Site.Trigramme, SiteId = ds.SiteId, ZoneId = ds.ZoneId };

                var allFicheSecurite = queryFicheSecurite.ToList();

                var groupDangers = GetDangers(allFicheSecurite);
                var groupServices = GetServices(allFicheSecurite);
                var groupCorpsHumainZones = GetCorpsHumainZones(allFicheSecurite);

                var allDangers = db.Dangers.ToList();
                var allCorpsHumainZones = db.CorpsHumainZones.ToList();

                List<Site> allSite = db.Sites.ToList();
                List<Zone> allZone = db.Zones.ToList();
                List<Service> allService = db.Services.ToList();

                List<FicheSecuriteType> allFicheSecuriteType = db.FicheSecuriteTypes.ToList();

                Dictionary<string, object> response = new Dictionary<string, object>
                {
                    { "AllFicheSecurite", allFicheSecurite },
                    { "AllSite", allSite },
                    { "AllZone", allZone },
                    { "AllService", allService },
                    { "AllFicheSecuriteType", allFicheSecuriteType },
                    { "AllDialogueSecurite", queryDialogueSecurite.ToList() },
                    { "AllDangers", allDangers },
                    { "AllCorpsHumainZones", allCorpsHumainZones },
                    { "GroupDangers", groupDangers },
                    { "GroupServices", groupServices },
                    { "GroupCorpsHumainZones", groupCorpsHumainZones }
                };

                Dictionary<string, object> paramModel = new Dictionary<string, object>
                {
                    { "DateDebut", dateDebut },
                    { "DateFin", dateFin }
                };

                response.Add("ParamModel", paramModel);

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        /// <summary>
        /// Filtre des dialogues sécurités en fonction des paramètres.
        /// </summary>
        /// <param name="statistiquePyramideParamModel">Paramètres de filtre.</param>
        /// <returns>Reponse http.</returns>
        public HttpResponseMessage DialogueSecuriteFiltered(StatistiquePyramideParamModel statistiquePyramideParamModel)
        {
            DateTime dateDebut = statistiquePyramideParamModel.DateDebut;
            DateTime dateFin = statistiquePyramideParamModel.DateFin.AddDays(1);

            var queryDialogueSecurite =
                   from ds in db.DialogueSecurites
                   where ds.Date >= dateDebut && ds.Date <= dateFin
                   select new
                   {
                       Id = ds.Id,
                       Site = ds.Site.Trigramme,
                       SiteId = ds.SiteId,
                       ZoneId = ds.ZoneId
                   };

            return Request.CreateResponse(HttpStatusCode.OK, queryDialogueSecurite.ToList());
        }


        /// <summary>
        /// Filtre les fiches sécurités en fonction des paramètres.
        /// </summary>
        /// <param name="statistiquePyramideParamModel">Paramètre de filtre.</param>
        /// <returns>Reponse http.</returns>
        public HttpResponseMessage StatistiqueFiltered(StatistiquePyramideParamModel statistiquePyramideParamModel)
        {
            try
            {
                DateTime dateDebut = statistiquePyramideParamModel.DateDebut;
                DateTime dateFin = statistiquePyramideParamModel.DateFin.AddDays(1);

                var queryFicheSecurite =
                    from f in db.FicheSecurites
                    where f.DateEvenement >= dateDebut && f.DateEvenement <= dateFin
                    select new FicheSecuriteStatistique
                    {
                        Id = f.FicheSecuriteID,
                        DateEvnmt = f.DateEvenement,
                        //TimeStamp = (int)f.DateEvenement.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                        SiteId = f.SiteId,
                        Site = f.Site.Trigramme,
                        ZoneId = f.ZoneId,
                        CauseQSEs = f.CauseQSEs,
                        FicheSecuriteType = f.FicheSecuriteType.Nom,
                        Responsable = f.Responsable,
                        FicheSecurtiteTypeID = f.FicheSecuriteTypeId,
                        WorkFlowASEValidee = f.WorkFlowASEValidee,
                        WorkFlowFicheSecuriteCloturee = f.WorkFlowFicheSecuriteCloturee,
                        WorkFlowCloturee = f.WorkFlowCloturee,
                        ServiceId = f.ServiceId,
                        Service = f.Service.ServiceType.Nom, // Service
                        Danger = f.Danger.Nom, // Danger
                        DangerId = f.Danger.DangerID, // Danger
                        CorpsHumainZoneId = f.CorpsHumainZoneId, // Lésions
                        CorpsHumainZoneCode = f.CorpsHumainZone.Code, // Lésions
                        CorpsHumainZone = f.CorpsHumainZone.Nom, // Lésions
                    };


                var allFicheSecurite = queryFicheSecurite.ToList();

                var groupDangers = GetDangers(allFicheSecurite);
                var groupServices = GetServices(allFicheSecurite);
                var groupCorpsHumainZones = GetCorpsHumainZones(allFicheSecurite);

                Dictionary<string, object> response = new Dictionary<string, object>
                {
                    { "AllFicheSecurite", allFicheSecurite }, 
                    { "GroupDangers", groupDangers },
                    { "GroupServices", groupServices },
                    { "GroupCorpsHumainZones", groupCorpsHumainZones }
                };

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Groupement des fiches sécurités par dangers.
        /// </summary>
        /// <param name="ficheSecuriteStatistiques">Liste de fiche sécurités.</param>
        /// <returns>Dictionnaire de fiche sécurité groupées.</returns>
        private Dictionary<string, Dictionary<string, int>> GetDangers(List<FicheSecuriteStatistique> ficheSecuriteStatistiques)
        {
            var groupDangers = ficheSecuriteStatistiques
                .GroupBy(x => new { x.DangerId, x.Danger })
                .OrderBy(x => x.Key.Danger)
                .ToDictionary(
                x => x.Key.Danger,
                y => ficheSecuriteStatistiques
                    .Where(z => z.Danger == y.Key.Danger)
                    .GroupBy(a => a.Site)
                    .ToDictionary(x => x.Key, w => w.Count()));

            return groupDangers;
        }

        /// <summary>
        /// Groupement des fiches sécurités par services.
        /// </summary>
        /// <param name="ficheSecuriteStatistiques">Liste de fiche sécurités.</param>
        /// <returns>Dictionnaire de fiche sécurité groupées.</returns>
        private Dictionary<string, Dictionary<string, int>> GetServices(List<FicheSecuriteStatistique> ficheSecuriteStatistiques)
        { 
            var groupServices = ficheSecuriteStatistiques
                .GroupBy(x => new { x.Service })
                .OrderBy(x => x.Key.Service)
                .ToDictionary(
                x => x.Key.Service,
                y => ficheSecuriteStatistiques
                    .Where(z => z.Service == y.Key.Service)
                    .GroupBy(a => a.Site)
                    .ToDictionary(x => x.Key, w => w.Count()));

            return groupServices;
        }

        /// <summary>
        /// Groupement des fiches sécurités par zones du corps humains.
        /// </summary>
        /// <param name="ficheSecuriteStatistiques">Liste de fiche sécurités.</param>
        /// <returns>Dictionnaire de fiche sécurité groupées.</returns>
        private Dictionary<string, Dictionary<string, int>> GetCorpsHumainZones(List<FicheSecuriteStatistique> ficheSecuriteStatistiques)
        {
            var groupCorpsHumainZones = ficheSecuriteStatistiques
                .GroupBy(x => new { x.CorpsHumainZoneId, x.CorpsHumainZone })
                .OrderBy(x => x.Key.CorpsHumainZone)
                .ToDictionary(
                x => x.Key.CorpsHumainZone,
                y => ficheSecuriteStatistiques
                    .Where(z => z.CorpsHumainZone == y.Key.CorpsHumainZone)
                    .GroupBy(a => a.Site)
                    .ToDictionary(x => x.Key, w => w.Count()));

            return groupCorpsHumainZones;
        }
    }
}