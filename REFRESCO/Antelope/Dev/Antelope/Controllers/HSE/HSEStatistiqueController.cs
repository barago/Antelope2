using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Antelope.Controllers.HSE
{
    public class HSEStatistiqueController : Controller
    {
        // GET: HSEStatistique
        public ActionResult Index()
        {
            return View("~/Views/HSE/HSEStatistique/Index.cshtml");
        }

        public ActionResult NbFSChrono()
        {
            return View("~/Views/HSE/HSEStatistique/NbFSChrono.cshtml");
        }
        public ActionResult Pyramide()
        {
            return View("~/Views/HSE/HSEStatistique/Pyramide.cshtml");
        }
        public ActionResult Detail()
        {
            return View("~/Views/HSE/HSEStatistique/Detail.cshtml");
        }
        public ActionResult DialogueSecurite()
        {
            return View("~/Views/HSE/HSEStatistique/DialogueSecurite.cshtml");
        }

    }
}