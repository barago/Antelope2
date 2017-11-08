using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Antelope.Controllers.QSE
{
    public class QSEHomeController : Controller
    {
        // GET: QSEHome
        public ActionResult Index()
        {
            return View("~/Views/QSE/QSEHome/Index.cshtml");
        }
    }
}