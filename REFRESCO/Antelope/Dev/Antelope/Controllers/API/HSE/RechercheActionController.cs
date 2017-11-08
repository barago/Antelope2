using Antelope.Repositories.QSE;
using Antelope.ViewModels.Socle.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Antelope.Models.HSE;

using FicheSecurite = Antelope.Domain.Models.FicheSecurite;

namespace Antelope.Controllers.API.HSE
{
    public class RechercheActionController : ApiController
    {
        private ActionQSERepository _actionQSERepository { get; set; }

        public RechercheActionController()
        {
            _actionQSERepository = new ActionQSERepository();
        }

        public HttpResponseMessage Get(FicheSecuriteParams ficheSecuriteParams)
        {
            DataTableViewModel<FicheSecurite> dataTableViewModel = _actionQSERepository.GetFromParams2(ficheSecuriteParams);
            return Request.CreateResponse(HttpStatusCode.OK, dataTableViewModel);
        }
    }
}
