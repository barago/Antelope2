using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Antelope.Controllers.API.Socle
{
    public class ServiceTypeController : ApiController
    {
        private AntelopeEntities db = new AntelopeEntities();

        public HttpResponseMessage getNonConformiteOriginesByServiceTypeId(int id)
        {
            var queryOrigine = from a in db.NonConformiteOrigines
                            where a.ServiceTypeId == id
                            orderby a.Nom
                            select a;
            List<NonConformiteOrigine> AllNonConformiteOrigine = queryOrigine.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, AllNonConformiteOrigine);
        }


    }
}
