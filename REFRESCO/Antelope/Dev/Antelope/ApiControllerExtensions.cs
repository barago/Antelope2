using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Antelope.ViewModels.Socle.DataTables;

namespace Antelope
{
    public static class HomeController
    {

        public static DataTableViewModel<T> DataTableSource<T>(this ApiController controller, Dictionary<string, string> dico)
        {

            return null;
        }
    }
}