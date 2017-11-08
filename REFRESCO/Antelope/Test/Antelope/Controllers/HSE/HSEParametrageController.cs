using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Antelope.Controllers.HSE
{
    public class HSEParametrageController : Controller
    {
        // GET: HSEParametrage
        public ActionResult General()
        {


            ViewBag.CurrentHSERole = Session["CurrentHSERole"];



            return View("~/Views/HSE/Parametrage/Index.cshtml");
        }

        public ActionResult ChangeLog()
        {

            return View("~/Views/HSE/Parametrage/Changelog.cshtml");
        }


    }
}