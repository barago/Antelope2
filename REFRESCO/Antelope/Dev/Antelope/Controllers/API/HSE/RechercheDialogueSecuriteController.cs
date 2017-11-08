using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Repositories.Socle;
using Antelope.ViewModels.HSE.DialogueSecuriteViewModels;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Antelope.Controllers.API.HSE
{
    public class RechercheDialogueSecuriteController : ApiController
    {

        private AntelopeEntities db = new AntelopeEntities();
        public ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository { get; set; }


        // GET: api/RechercheNonConformite
        public HttpResponseMessage Get()
        {

            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();

            UserPrincipal user = _activeDirectoryUtilisateurRepository.GetActiveDirectoryUser(System.Web.HttpContext.Current.User.Identity.Name.Split('\\')[1]);

            Site SiteUser = _activeDirectoryUtilisateurRepository.GetCurrentUserSite();

            RechercheDialogueSecuriteParamModel RechercheDialogueSecuriteParamModel = new RechercheDialogueSecuriteParamModel()
            {
                DateDebut = new DateTime(DateTime.Now.Year, 1, 1),
                SiteId = (SiteUser == null) ? 0 : SiteUser.SiteID
            };

            RechercheDialogueSecuriteViewModel RechercheDialogueSecuriteViewModel = new RechercheDialogueSecuriteViewModel(RechercheDialogueSecuriteParamModel);

            return Request.CreateResponse(HttpStatusCode.OK, RechercheDialogueSecuriteViewModel);

        }

        public HttpResponseMessage ExtractionFromParameters(Object obj)
        {

            Dictionary<string, int> DataTableParameters = new Dictionary<string, int>();
            DataTableParameters["start"] = 0;
            DataTableParameters["length"] = 0;
            DataTableParameters["siteId"] = 1;

            return null;

        }




    }
}
