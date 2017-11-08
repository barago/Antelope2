using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Antelope.Controllers.QSE
{
    public class QSEParametrageController : Controller
    {
        // GET: QSEParametrage
        public ActionResult General()
        {


            ViewBag.CurrentQSERole = Session["CurrentQSERole"];



            return View("~/Views/QSE/Parametrage/Index.cshtml");
        }

        public ActionResult ChangeLog()
        {

            return View("~/Views/QSE/Parametrage/Changelog.cshtml");
        }
    }
}