using Antelope.Domain.Models;
using Antelope.DTOs.Services;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Repositories.Services;
using Antelope.Repositories.Socle;
using Antelope.ViewModels.Services;
using Antelope.ViewModels.Socle.DataTables;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Antelope.Controllers.API.Services
{
    public class AnnuaireController : ApiController
    {

        public ActiveDirectoryUtilisateurRepository _activeDirectoryUtilisateurRepository { get; set; }
        public AnnuaireRepository _annuaireRepository { get; set; }
        private AntelopeEntities db = new AntelopeEntities();

        public HttpResponseMessage GetAnnuaire()
        {

            _activeDirectoryUtilisateurRepository = new ActiveDirectoryUtilisateurRepository();

            String SiteTrigramme = _activeDirectoryUtilisateurRepository.GetCurrentUserSiteTrigramme();

            var querySiteUser = from s in db.Sites
                                where s.Trigramme == SiteTrigramme
                                select s;
            Site SiteUser = (Site)querySiteUser.SingleOrDefault();

            var SiteId = SiteUser.SiteID;

            var AllSite = db.Sites;

            AnnuaireParamModel AnnuaireParamModel= new AnnuaireParamModel()
            {
                SiteId = (SiteUser == null)? 0 : SiteUser.SiteID,
                Nom="",
                Prenom=""
            };

            Object Response = new { AnnuaireParamModel = AnnuaireParamModel, AllSite = AllSite };

             return Request.CreateResponse(HttpStatusCode.OK, Response);

        }


        public HttpResponseMessage GetData()
        {

            _annuaireRepository = new AnnuaireRepository();

            Dictionary<string, string> DataTableParameters = new Dictionary<string, string>();
            DataTableParameters = Request.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);

            DataTableViewModel<AnnuaireUtilisateurDTO> DataTableViewModel = _annuaireRepository.GetFromParams(DataTableParameters);

            return Request.CreateResponse(HttpStatusCode.OK, DataTableViewModel);
        }

    }
}
