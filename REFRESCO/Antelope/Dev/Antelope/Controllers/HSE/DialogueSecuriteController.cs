using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Antelope.Controllers.HSE
{
    public class DialogueSecuriteController : Controller
    {
        // GET: DialogueSecurite
        public ActionResult Index()
        {
            return View("~/Views/HSE/DialogueSecurite/Index.cshtml");
        }
        public ActionResult Create()
        {
            ViewBag.Id = -1;

            return View("~/Views/HSE/DialogueSecurite/Create.cshtml");
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.Id = id;
            ViewBag.CurrentHSERole = Session["CurrentQSERole"];


            return View("~/Views/HSE/DialogueSecurite/Create.cshtml");
        }
    }
}