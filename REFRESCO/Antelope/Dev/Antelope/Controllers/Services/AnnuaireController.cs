using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Antelope.Controllers.Services
{
    public class AnnuaireController : Controller
    {
        // GET: Annuaire
        public ActionResult Index()
        {
            
            
            
            
            return View("~/Views/Services/Annuaire/Index.cshtml");
        }
    }
}