using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Antelope.Services.HSE;
using Antelope.Services.Commons;
using System.Diagnostics;
using PagedList;
using Antelope.Domain.Models;
using System.Web.Security;
using System.Collections;
using Antelope.ViewModels.HSE.FicheSecuriteViewModels;
using Antelope.Infrastructure.EntityFramework;


namespace Antelope.Controllers.HSE
{
    public class FicheSecuriteController : Controller
    {
        private AntelopeEntities db = new AntelopeEntities();


        //[Authorize(Roles = "RFC-U-Informatique_ResponsableApplications")]
        //[Authorize]
        // GET: /FicheSecurite/
        public ActionResult Index(string sortOrder, string searchString, int page = 1)
        {

            var ficheSecurites = from s in db.FicheSecurites.Include(f => f.Site)   //Include > JOINTURE EAGER
                                 select s;



            FicheSecuriteServices.AddTriParamsToViewBag(ViewBag, sortOrder);
            ViewBag.CurrentSort = sortOrder;

            ViewBag.SearchString = searchString != null ? searchString : "";

            if (!String.IsNullOrEmpty(searchString))
            {
                ficheSecurites = ficheSecurites.Where(f => f.Code.ToUpper().Contains(searchString.ToUpper()));
            }


            ficheSecurites = FicheSecuriteServices.TriFicheSecurites(ficheSecurites, sortOrder);

            int pageSize = 8;

            ViewBag.CurrentHSERole = Session["CurrentHSERole"];
            ViewBag.CurrentGuid = Session["CurrentGuid"];

            return View("~/Views/HSE/FicheSecurite/Index.cshtml", ficheSecurites.ToPagedList(page, pageSize));
        }

        //[Authorize(Roles = "RFC-U-Informatique_ResponsableApplications")]
        //[Authorize]
        // GET: /FicheSecurite/
        //public ActionResult Index2(string sortOrder, string searchString, int page = 1)
        //{


        //    return View("~/Views/HSE/FicheSecurite/Index.cshtml");
        //}



        // GET: /FicheSecurite/Create
        public ActionResult Create()
        {
            //List<Zone> Zones = new List<Zone>();
            //List<Lieu> Lieux = new List<Lieu>();
            //ViewBag.SiteId = new SelectList(db.Sites, "SiteID", "Trigramme");
            //ViewBag.ZoneId = new SelectList(Zones, "ZoneId", "Nom");
            //ViewBag.LieuId = new SelectList(Lieux, "LieuId", "Nom");
            //ViewBag.FicheSecuriteTypeId = new SelectList(db.FicheSecuriteTypes, "FicheSecuriteTypeId", "Nom");
            //ViewBag.DangerId = new SelectList(db.Dangers, "DangerId", "Nom");
            //ViewBag.PlageHoraireId = new SelectList(db.PlageHoraires, "PlageHoraireId", "Nom");

            //FicheSecurite ficheSecurite = new FicheSecurite() { CorpsHumainZone = new CorpsHumainZone() };

            ViewBag.Id = -1;
            
            return View("~/Views/HSE/FicheSecurite/Create.cshtml");
        }



        // GET: /FicheSecurite/Create
        public ActionResult Edit(int ?id)
        {
            ViewBag.Id = id;
            ViewBag.CurrentHSERole = Session["CurrentHSERole"];
            ViewBag.CurrentGuid = Session["CurrentGuid"];


            return View("~/Views/HSE/FicheSecurite/Create.cshtml");
        }


        // POST: /FicheSecurite/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DateTime DateEvenement, Boolean HeureEvenementValide, String HeureEvenement, String CorpsHumainSelectedHidden, [Bind(Include = "FicheSecuriteID,Code,Type,Nom,Prenom,PosteDeTravail,DateCreation,Service,Responsable,ZoneId,LieuId,PersonnesConcernees,Description,CotationFrequence,CotationGravite,CotationVolume,SiteId,FicheSecuriteTypeId,Risque,Age,PlageHoraireId,Temoins,ActionImmediate1,ActionImmediate2,CorpsHumainZone, DangerId")] FicheSecurite ficheSecurite)
        {
            
            TimeSpan ts = new TimeSpan(10, 30, 0);
            //ficheSecurite.DateEvenement = HeureEvenementValide ? ficheSecurite.DateEvenement : 

            if (HeureEvenementValide) { 
                ficheSecurite.DateEvenement =  DateEvenement + TimeSpan.Parse(HeureEvenement+":00");
            }

            ficheSecurite.DateCreation = DateTime.Now;

            //CorpsHumainZone corpsHumainZone = (CorpsHumainZone)db.CorpsHumainZones.SingleOrDefault(c => c.Code == CorpsHumainSelectedHidden);

            var query = from a in db.CorpsHumainZones
                        where a.Code == CorpsHumainSelectedHidden
                        select a;

            CorpsHumainZone corpsHumainZone = query.FirstOrDefault();


            ficheSecurite.CorpsHumainZone = corpsHumainZone;

            var errors = ViewData.ModelState.Where(n => n.Value.Errors.Count > 0).ToList();
            if (ModelState.IsValid)
            {
                db.FicheSecurites.Add(ficheSecurite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<Zone> Zones = new List<Zone>();
            List<Lieu> Lieux = new List<Lieu>();

            String[] roles = Roles.GetRolesForUser();
            //foreach (String NomRole in roles){
            //    Console.WriteLine("Role : " + NomRole);

            //}


            //Site site = db.Sites.Find;

            ViewBag.SiteId = new SelectList(db.Sites, "SiteID", "Trigramme", ficheSecurite.SiteId);
            ViewBag.ZoneId = new SelectList(Zones, "ZoneId", "Nom");
            ViewBag.LieuId = new SelectList(Lieux, "LieuId", "Nom");
            ViewBag.FicheSecuriteTypeId = new SelectList(db.FicheSecuriteTypes, "FicheSecuriteTypeId", "Nom");
            ViewBag.DangerId = new SelectList(db.Dangers, "DangerId", "Nom");
            ViewBag.PlageHoraireId = new SelectList(db.PlageHoraires, "PlageHoraireId", "Nom");

            ViewBag.DateEvenement = ficheSecurite.DateEvenement.Date.ToString("dd/MM/yyyy");
            ViewBag.HeureEvenement = ficheSecurite.DateEvenement.Date.ToString("HH:mm");

            return View("~/Views/HSE/FicheSecurite/Create.cshtml", ficheSecurite);
        }

        // GET: /FicheSecurite/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    FicheSecurite ficheSecurite = db.FicheSecurites.Find(id);
        //    if (ficheSecurite == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    //User.IsInRole("xxx");

        //    ArrayList groups = GroupService.GetAllGroupForUser();
        //    String[] roles = Roles.GetRolesForUser();

        //    ViewBag.SiteId = new SelectList(db.Sites, "SiteID", "Nom", ficheSecurite.SiteId);
        //    var queryZone = from a in db.Zones
        //                    where a.SiteId == ficheSecurite.SiteId
        //                    select a;

        //    ViewBag.ZoneId = new SelectList(queryZone, "ZoneId", "Nom", ficheSecurite.ZoneId);

        //    var queryLieu = from a in db.Lieux
        //                    where a.ZoneId == ficheSecurite.LieuId
        //                    select a;

        //    ViewBag.ZoneId = new SelectList(queryZone, "ZoneId", "Nom", ficheSecurite.ZoneId);
        //    ViewBag.LieuId = new SelectList(queryLieu, "LieuId", "Nom", ficheSecurite.LieuId);
        //    ViewBag.FicheSecuriteTypeId = new SelectList(db.FicheSecuriteTypes, "FicheSecuriteTypeId", "Nom");
        //    ViewBag.DangerId = new SelectList(db.Dangers, "DangerId", "Nom");
        //    ViewBag.PlageHoraireId = new SelectList(db.PlageHoraires, "PlageHoraireId", "Nom");

        //    ViewBag.DateEvenement = ficheSecurite.DateEvenement.Date.ToString("dd/MM/yyyy");
        //    ViewBag.HeureEvenement = ficheSecurite.DateEvenement.Date.ToString("HH:mm");

        //    ViewBag.CriticiteBrute = ficheSecurite.CotationFrequence * ficheSecurite.CotationGravite;

        //    return View("~/Views/HSE/FicheSecurite/Create.cshtml", ficheSecurite);
        //}

        // POST: /FicheSecurite/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Boolean HeureEvenementValide, [Bind(Include = "FicheSecuriteID,Code,Type,Nom,Prenom,PosteDeTravail,Service,Responsable,DateCreation,Zone,Lieu,PersonnesConcernees,Description,CotationFrequence,CotationGravite,CotationVolume,SiteId,FicheSecuriteTypeId,Risque,Age,PlageHoraireId,Temoins, ActionImmediate1, ActionImmediate2,CorpsHumainZone")] FicheSecurite ficheSecurite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ficheSecurite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SiteId = new SelectList(db.Sites, "SiteID", "Nom", ficheSecurite.SiteId);
            ViewBag.ZoneId = new SelectList(db.Zones, "ZoneId", "Nom", ficheSecurite.ZoneId);
            ViewBag.LieuId = new SelectList(db.Lieux, "LieuId", "Nom", ficheSecurite.LieuId);
            ViewBag.FicheSecuriteTypeId = new SelectList(db.FicheSecuriteTypes, "FicheSecuriteTypeId", "Nom");
            ViewBag.DangerId = new SelectList(db.Dangers, "DangerId", "Nom");
            ViewBag.PlageHoraireId = new SelectList(db.PlageHoraires, "PlageHoraireId", "Nom");

            //int CotationFrequence = ficheSecurite.CotationFrequence != null ? ficheSecurite.CotationFrequence : 0;
            //int CotationGravite = ficheSecurite.CotationGravite != null ? ficheSecurite.CotationGravite : 0;

            ViewBag.CriticiteBrute = ficheSecurite.CotationFrequence * ficheSecurite.CotationGravite;

            return View("~/Views/HSE/FicheSecurite/Create.cshtml", ficheSecurite);
        }

        // GET: /FicheSecurite/CreateBackBone
        public ActionResult CreateBackBone()
        {

            FicheSecuriteViewModel FicheSecuriteViewModel = new FicheSecuriteViewModel();
            
            return View("~/Views/HSE/FicheSecurite/Create_BackBone.cshtml");
        }

        // GET: /FicheSecurite/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FicheSecurite ficheSecurite = db.FicheSecurites.Find(id);
            if (ficheSecurite == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/HSE/FicheSecurite/Delete.cshtml", ficheSecurite);
        }

        public ActionResult TestMap()
        {


            return View("~/Views/HSE/FicheSecurite/TestMap.cshtml");
        }

        // POST: /FicheSecurite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FicheSecurite ficheSecurite = db.FicheSecurites.Find(id);
            db.FicheSecurites.Remove(ficheSecurite);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Zones(string SiteId)
        {

            if (SiteId == "" || SiteId == "undefined")
            {
                return Json(new SelectList(new List<Zone>(), "ZoneId", "Nom"));
            }

            int id = Convert.ToInt32(SiteId);


            var query = from a in db.Zones
                        where a.SiteId == id
                        select a;

            return Json(new SelectList(query, "ZoneId", "Nom"));

        }

        [HttpPost]
        public ActionResult Lieux(string ZoneId)
        {

            if (ZoneId == "" || ZoneId == "undefined")
            {
                return Json(new SelectList(new List<Lieu>(), "LieuId", "Nom"));
            }

            int id = Convert.ToInt32(ZoneId);


            var query = from a in db.Lieux
                        where a.ZoneId == id
                        select a;

            return Json(new SelectList(query, "LieuId", "Nom"));

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: /FicheSecurite/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    FicheSecurite ficheSecurite = db.FicheSecurites.Find(id);
        //    if (ficheSecurite == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View("~/Views/HSE/FicheSecurite/Details.cshtml", ficheSecurite);
        //}

        //// GET: /FicheSecurite/Create
        //public ActionResult CreateBis()
        //{
        //    List<Zone> Zones = new List<Zone>();
        //    List<Lieu> Lieux = new List<Lieu>();
        //    ViewBag.SiteId = new SelectList(db.Sites, "SiteID", "Trigramme");
        //    ViewBag.ZoneId = new SelectList(Zones, "ZoneId", "Nom");
        //    ViewBag.LieuId = new SelectList(Lieux, "LieuId", "Nom");
        //    ViewBag.FicheSecuriteTypeId = new SelectList(db.FicheSecuriteTypes, "FicheSecuriteTypeId", "Nom");
        //    ViewBag.DangerId = new SelectList(db.Dangers, "DangerId", "Nom");
        //    ViewBag.PlageHoraireId = new SelectList(db.PlageHoraires, "PlageHoraireId", "Nom");

        //    FicheSecurite ficheSecurite = new FicheSecurite();

        //    return View("~/Views/HSE/FicheSecurite/CreateBis.cshtml", ficheSecurite);
        //}

    }
}
