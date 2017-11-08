using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Antelope.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
  
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A propso de la societe";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Page de contact : Email, Adresse, Téléphone, Fax ...";

            return View();
        }

        public ActionResult WebServiceTest()
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://dlf-s12k04");
            var buffer = Encoding.ASCII.GetBytes("export:Exp0rt");
            var authHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(buffer));
            client.DefaultRequestHeaders.Authorization = authHeader;
            var response = client.GetAsync("glpi-prod.listTickets").Result;

            string responseBody = "ET NON";
            
            if (response.IsSuccessStatusCode)
            {
                responseBody = response.Content.ReadAsStringAsync().Result;
            }



            return Content("IsSuccessStautCode : " + response.IsSuccessStatusCode + " responseBody : " + responseBody); ;
        }
    }
}