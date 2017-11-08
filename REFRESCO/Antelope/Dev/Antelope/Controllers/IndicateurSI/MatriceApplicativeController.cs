using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Antelope.Controllers.IndicateurSI
{
    public class MatriceApplicativeController : Controller
    {
        // GET: MatriceApplicative
        public ActionResult MatriceApplicative()
        {




            return View("~/Views/IndicateurSI/MatriceApplicative/MatriceApplicative.cshtml");
        }
    }
}