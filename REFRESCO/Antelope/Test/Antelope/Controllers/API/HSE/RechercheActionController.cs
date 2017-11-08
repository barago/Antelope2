using Antelope.Domain.Models;
using Antelope.Repositories.QSE;
using Antelope.ViewModels.Socle.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Antelope.Controllers.API.HSE
{
    public class RechercheActionController : ApiController
    {
        private ActionQSERepository _actionQSERepository { get; set; }

        public RechercheActionController()
        {

            _actionQSERepository = new ActionQSERepository();
        }

        public HttpResponseMessage Get()
        {
            //_actionQSERepository = new ActionQSERepository();

            Dictionary<string, string> DataTableParameters = new Dictionary<string, string>();
            DataTableParameters = Request.GetQueryNameValuePairs().ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);

            DataTableViewModel<FicheSecurite> DataTableViewModel = _actionQSERepository.GetFromParams2(DataTableParameters);

            //DataTableViewModel.aaData = nonConformites;
            //DataTableViewModel.iTotalRecords = 1;
            //DataTableViewModel.iTotalDisplayRecords = 1;
            //DataTableViewModel.sEcho = int.Parse(dataTableParameters["sEcho"]);

            return Request.CreateResponse(HttpStatusCode.OK, DataTableViewModel);
        }

         



    }
}
