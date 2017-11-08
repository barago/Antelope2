using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using Antelope.Services.HSE;
using Antelope.Services.Socle.DataBaseHydratation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Antelope.Controllers.API.HSE
{
    public class HSEParametrageController : ApiController
    {

        private AntelopeEntities context = new AntelopeEntities();
        private DataBaseTestHydratationService _dataBaseTestHydratationService = new DataBaseTestHydratationService();
        private DataBaseAcceptanceHydratationService _dataBaseAcceptanceHydratationService = new DataBaseAcceptanceHydratationService();

        [AcceptVerbs("GET")]       
        public HttpResponseMessage GetHSEParametrage()
        {
            ParametrageHSE ParametrageHSE = context.ParametrageHSEs.FirstOrDefault();

            if (ParametrageHSE == null)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            var queryRoles = from a in context.ADRoles
                            where a.RoleType == "HSE"
                            select a;
            List<ADRole> AllADRole = queryRoles.ToList();

            // ! Créer une objet de réponse au lieu de mettre ça dans un dictionnary
            Dictionary<String, Object> Response = new Dictionary<String, Object>();
            Response.Add("Parametrage", ParametrageHSE);
            Response.Add("Roles", AllADRole);

            return Request.CreateResponse(HttpStatusCode.OK, Response);
        }

        public HttpResponseMessage saveParametrageHSEEmail(ParametrageHSE parametrageHSE)
        {
           context.Entry(parametrageHSE).State = EntityState.Modified;
           context.SaveChanges();


            return Request.CreateResponse(HttpStatusCode.OK, parametrageHSE);
        }

        [AcceptVerbs("POST")]
        public HttpResponseMessage DebugFicheCloturees()
        {
            
            List<ActionQSE> allActionQSE = context.ActionQSEs.Where(a => a.CauseQSEId != null).ToList();


            foreach (ActionQSE action in allActionQSE)
            {
                FicheSecuriteServices _ficheSecuriteServices = new FicheSecuriteServices();
                _ficheSecuriteServices.FicheSecuriteOpenOrClose(action);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [AcceptVerbs("POST")]
        public HttpResponseMessage AlimenteBaseTest()
        {
            _dataBaseTestHydratationService.FullDataBaseTestHydrate();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [AcceptVerbs("POST")]
        public HttpResponseMessage AlimenteBaseAcceptance()
        {
            _dataBaseAcceptanceHydratationService.FullDataBaseAcceptanceHydrate();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [AcceptVerbs("POST")]
        public HttpResponseMessage AlimenteListeNSG()
        {
            _dataBaseTestHydratationService.FullDataBaseTestHydrate();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage AddADRole(ADRole ADRole,Int32 id)
        {

            context.ADRoles.Add(ADRole);

            context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, ADRole);
        }

        public HttpResponseMessage DeleteADRole(ADRole ADRole, Int32 id)
        {

            ADRole ADRoleToDelete =  context.ADRoles.Find(id);

            if (ADRoleToDelete == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ADRole);
            }

            context.ADRoles.Remove(ADRoleToDelete);
            context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, ADRoleToDelete);
        }

    }
}
