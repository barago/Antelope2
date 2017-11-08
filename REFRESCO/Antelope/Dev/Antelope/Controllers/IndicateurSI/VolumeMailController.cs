using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Antelope.Controllers.IndicateurSI
{
    public class VolumeMailController : Controller
    {
        // GET: VolumeMail
        public ActionResult VolumeMail()
        {
            return View("~/Views/IndicateurSI/IndicateurSISupport/VolumeMail.cshtml");
        }
    }
}