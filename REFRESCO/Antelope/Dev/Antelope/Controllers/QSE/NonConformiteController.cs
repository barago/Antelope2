using Antelope.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace Antelope.Controllers.QSE
{
    public class NonConformiteController : Controller
    {

        private AntelopeEntities db = new AntelopeEntities();


        // GET: NonConformite
        public ActionResult Index(string sortOrder, string searchString, int page = 1)
        {

            var nonConformites = from s in db.NonConformites.Include(f => f.Site)   //Include > JOINTURE EAGER
                                 select s;



            //FicheSecuriteServices.AddTriParamsToViewBag(ViewBag, sortOrder);
            //ViewBag.CurrentSort = sortOrder;

            //ViewBag.SearchString = searchString != null ? searchString : "";

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    ficheSecurites = ficheSecurites.Where(f => f.Code.ToUpper().Contains(searchString.ToUpper()));
            //}


            //ficheSecurites = FicheSecuriteServices.TriFicheSecurites(ficheSecurites, sortOrder);

            int pageSize = 8;

            //return View("~/Views/HSE/NonConformite/Index.cshtml", nonConformites.ToPagedList(page, pageSize));
            return View("~/Views/QSE/NonConformite/Index.cshtml");
        }

        // GET: /NonConformite/Create
        public ActionResult Create()
        {
            ViewBag.Id = -1;

            return View("~/Views/QSE/NonConformite/Create.cshtml");
        }

        // GET: /FicheSecurite/Create
        public ActionResult Edit(int? id)
        {
            ViewBag.Id = id;
            ViewBag.CurrentHSERole = Session["CurrentQSERole"];


            return View("~/Views/QSE/NonConformite/Create.cshtml");
        }
    }
}