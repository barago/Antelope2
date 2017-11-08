using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Antelope.Domain.Models;
using Antelope.ViewModels.HSE.FicheSecuriteViewModels;
using Antelope.Repositories.HSE;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using Antelope.Infrastructure.EntityFramework;
using System.Web;
using Antelope.Repositories.Socle;
using Antelope.Services.HSE.Enums;



namespace Antelope.Controllers.API.HSE
{
    public class RechercheFicheSecuriteController : ApiController
    {

        private AntelopeEntities db = new AntelopeEntities();
        public FicheSecuriteRepository _ficheSecuriteRepository { get; set; }
        public ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository { get; set; }


        // GET: api/RechercheFicheSecurite
        public HttpResponseMessage Get()
        {

            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();
      

            UserPrincipal user = _activeDirectoryUtilisateurRepository.GetActiveDirectoryUser(System.Web.HttpContext.Current.User.Identity.Name.Split('\\')[1]);

            String SiteTrigramme = _activeDirectoryUtilisateurRepository.GetCurrentUserSiteTrigramme();
            
            _ficheSecuriteRepository = new FicheSecuriteRepository();

            var queryPersonneConnectee = from p in db.Personnes
                    where p.Guid == user.Guid
                    select p;
            Personne PersonneConnectee = (Personne)queryPersonneConnectee.SingleOrDefault();

            var querySiteUser = from s in db.Sites
                                where s.Trigramme == SiteTrigramme
                                             select s;
            Site SiteUser = (Site)querySiteUser.SingleOrDefault();

            // TODO ZONEREPOSITORY
            var queryZone = from a in db.Zones
                            where a.SiteId == SiteUser.SiteID
                            select a;
            List<Zone> AllZone = queryZone.ToList();

            // TODO LIEUREPOSITORY
            List<Lieu> AllLieu = new List<Lieu>();

            // TODO POSTEDETRAVAILREPOSITORY
            List<PosteDeTravail> AllPosteDeTravail = new List<PosteDeTravail>();

            // TODO SERVICEREPOSITORY
            var queryService = from a in db.Services
                               where a.SiteId == SiteUser.SiteID
                               select a;
            List<Service> AllService = queryService.ToList();

            RechercheFicheSecuriteParamModel RechercheFicheSecuriteParamModel = new RechercheFicheSecuriteParamModel()
            {
                SiteId = SiteUser.SiteID,
                ZoneId = 0,
                LieuId = 0,
                FicheSecuriteTypeId = 0,
                Code = "",
                Age = "",
                PosteDeTravailId = 0,
                ServiceId = 0,
                DateEvenementDebut = new DateTime(2014, 01, 01),
                DateEvenementFin = new DateTime(2020, 12, 31),
                PersonneConcerneeNom = "",
                ResponsableNom = user.Surname,
                ResponsableGuid = user.Guid,
                CotationFrequence = null,
                CotationGravite = null,
                RisqueId = 0,
                DangerId = 0,
                CorpsHumainZoneId = 0,
                PlageHoraireId = 0,
                Page = 1,
                PageSize = 12,
                IsNouvelleFiche = true ,
                IsPlanActionValide = true,
                IsPlanActionAttente = true,
                IsPlanActionRejete = true,
                IsPlanActionCloture = true,
                IsFicheSecuriteCloture = true,
                CriticiteNiveau = CriticiteNiveauEnum.NULL,
                Criticite = 0
            };

            FicheSecuritePaginatedList FicheSecuritePaginatedList = _ficheSecuriteRepository.GetFromParams(RechercheFicheSecuriteParamModel);

            RechercheFicheSecuriteViewModel RechercheFicheSecuriteViewModel = new RechercheFicheSecuriteViewModel(RechercheFicheSecuriteParamModel, FicheSecuritePaginatedList, AllService, AllZone, AllLieu, AllPosteDeTravail);

            return Request.CreateResponse(HttpStatusCode.OK, RechercheFicheSecuriteViewModel);
        }


        //// GET: api/RechercheNonConformite
        /// 
        public IHttpActionResult Get2()
        {

            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();
            _ficheSecuriteRepository = new FicheSecuriteRepository();

            UserPrincipal user = _activeDirectoryUtilisateurRepository.GetActiveDirectoryUser(System.Web.HttpContext.Current.User.Identity.Name.Split('\\')[1]);

            Site SiteUser = _activeDirectoryUtilisateurRepository.GetCurrentUserSite();

            // TODO ZONEREPOSITORY
            var queryZone = from a in db.Zones
                            where a.SiteId == SiteUser.SiteID
                            select a;
            List<Zone> AllZone = queryZone.ToList();

            // TODO LIEUREPOSITORY
            List<Lieu> AllLieu = new List<Lieu>();

            // TODO POSTEDETRAVAILREPOSITORY
            List<PosteDeTravail> AllPosteDeTravail = new List<PosteDeTravail>();

            // TODO SERVICEREPOSITORY
            var queryService = from a in db.Services
                               where a.SiteId == SiteUser.SiteID
                               select a;
            List<Service> AllService = queryService.ToList();

            RechercheFicheSecuriteParamModel RechercheFicheSecuriteParamModel = new RechercheFicheSecuriteParamModel()
            {
                SiteId = (SiteUser == null) ? 0 : SiteUser.SiteID,
                ZoneId = 0,
                LieuId = 0,
                FicheSecuriteTypeId = 0,
                Code = "",
                Age = "",
                PosteDeTravailId = 0,
                ServiceId = 0,
                DateEvenementDebut = new DateTime(DateTime.Now.Year, 1, 1),
                DateEvenementFin = null,
                PersonneConcerneeNom = "",
                ResponsableNom = "", //user.Surname,
                ResponsableGuid = null, //user.Guid,
                CotationFrequence = null,
                CotationGravite = null,
                RisqueId = 0,
                DangerId = 0,
                CorpsHumainZoneId = 0,
                PlageHoraireId = 0,
                Page = 1,
                PageSize = 12,
                IsNouvelleFiche = true,
                IsPlanActionValide = true,
                IsPlanActionAttente = true,
                IsPlanActionRejete = true,
                IsPlanActionCloture = true,
                IsFicheSecuriteCloture = true,
                DateButoirDebut = null,
                DateButoirFin = null,
                DateClotureDebut = null,
                DateClotureFin = null,
                ResponsableNomAction = "",
                CriticiteNiveau = CriticiteNiveauEnum.NULL,
                Criticite = 0
            };

            RechercheFicheSecuriteViewModel RechercheFicheSecuriteViewModel = new RechercheFicheSecuriteViewModel(RechercheFicheSecuriteParamModel, AllService, AllZone, AllLieu, AllPosteDeTravail);
            return Ok(RechercheFicheSecuriteViewModel);
        }



        // GET: api/RechercheFicheSecurite/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RechercheFicheSecurite
        public HttpResponseMessage Post(RechercheFicheSecuriteParamModel RechercheFicheSecuriteParamModel)
        {

            _ficheSecuriteRepository = new FicheSecuriteRepository();

            //var queryFicheSecurite = from a in db.FicheSecurites select a;

            FicheSecuritePaginatedList FicheSecuritePaginatedList = _ficheSecuriteRepository.GetFromParams(RechercheFicheSecuriteParamModel);


            return Request.CreateResponse(HttpStatusCode.OK, FicheSecuritePaginatedList);



            //var query = from m in db.Products
            //            select m;

            //// Set the total count
            //// so GridView knows how many pages to create
            //e.Arguments.TotalRowCount = query.Count();

            //// Get only the rows we need for the page requested
            //query = query.Skip(GridView1.PageIndex * PAGE_SIZE).Take(PAGE_SIZE);

            //e.Result = query;

        }

        // PUT: api/RechercheFicheSecurite/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RechercheFicheSecurite/5
        public void Delete(int id)
        {
        }
    }
}
