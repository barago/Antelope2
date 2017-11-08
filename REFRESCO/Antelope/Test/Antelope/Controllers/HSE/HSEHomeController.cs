using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Antelope.Controllers.HSE
{
    public class HSEHomeController : Controller
    {
        //
        // GET: /HSEHome/
        public ActionResult Index()
        {
            return View("~/Views/HSE/HSEHome/Index.cshtml");
        }
	}
}