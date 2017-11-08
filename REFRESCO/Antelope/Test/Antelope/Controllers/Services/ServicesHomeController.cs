using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Antelope.Controllers.Services
{
    public class ServicesHomeController : Controller
    {
        // GET: ServicesHome
        public ActionResult Index()
        {
            return View("~/Views/Services/ServicesHome/Index.cshtml");
        }
    }
}