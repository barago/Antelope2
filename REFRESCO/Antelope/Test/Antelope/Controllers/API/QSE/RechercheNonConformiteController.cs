using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Repositories.Socle;
using Antelope.ViewModels.QSE.NonConformiteViewModels;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Antelope.Controllers.API.QSE
{
    public class RechercheNonConformiteController : ApiController
    {

        private AntelopeEntities db = new AntelopeEntities();
        public ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository { get; set; }


        // GET: api/RechercheNonConformite
        public HttpResponseMessage Get()
        {

            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();

            UserPrincipal user = _activeDirectoryUtilisateurRepository.GetActiveDirectoryUser(System.Web.HttpContext.Current.User.Identity.Name.Split('\\')[1]);

                Site SiteUser = _activeDirectoryUtilisateurRepository.GetCurrentUserSite();

            RechercheNonConformiteParamModel RechercheNonConformiteParamModel = new RechercheNonConformiteParamModel()
            {
                SiteId = (SiteUser == null)? 0 : SiteUser.SiteID,
                NonConformiteDomaineId = 0,
                NonConformiteGraviteId = 0,
                NonConformiteOrigineId = 0,
                IsNCEnCours = true,
                IsNCCloture = true,
                IsActionEnCours = true,
                IsActionRealise = true,
                IsActionRetard = true,
                IsActionCloture = true,
                //Par défaut les Non-Conformité sont rattachées au Service Qualité.
                ServiceTypeId = db.ServiceTypes.Where(w => w.Nom.Equals("Qualité R/D")).Single().ServiceTypeId
            };

            RechercheNonConformiteViewModel RechercheNonConformiteViewModel = new RechercheNonConformiteViewModel(RechercheNonConformiteParamModel);

            return Request.CreateResponse(HttpStatusCode.OK, RechercheNonConformiteViewModel);

        }

        public HttpResponseMessage ExtractionFromParameters(Object obj)
        {

            Dictionary<string, int> DataTableParameters = new Dictionary<string, int>();
            DataTableParameters["start"] = 0;
            DataTableParameters["length"] = 0;
            DataTableParameters["siteId"] = 1;
            DataTableParameters["nonConformiteOrigineId"] = 1;
            DataTableParameters["nonConformiteGraviteId"] = 1;
            DataTableParameters["nonConformiteDomaineId"] = 1;
            

            return null;

        }

    }
}
