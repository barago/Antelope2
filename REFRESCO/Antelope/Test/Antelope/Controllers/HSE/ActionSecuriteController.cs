using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;

namespace Antelope.Controllers.HSE
{
    public class ActionSecuriteController : Controller
    {
        private AntelopeEntities db = new AntelopeEntities();

        // GET: /ActionSecurite/
        public ActionResult Index()
        {
            var actionsecurites = db.ActionSecurites.Include(a => a.FicheSecurite);
            return View(actionsecurites.ToList());
        }

        // GET: /ActionSecurite/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActionSecurite actionsecurite = db.ActionSecurites.Find(id);
            if (actionsecurite == null)
            {
                return HttpNotFound();
            }
            return View(actionsecurite);
        }

        // GET: /ActionSecurite/Create
        public ActionResult Create()
        {
            ViewBag.FicheSecuriteId = new SelectList(db.FicheSecurites, "FicheSecuriteID", "Code");
            return View();
        }

        // POST: /ActionSecurite/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ActionSecuriteId,FicheSecuriteId,Code,Description,FaitPar")] ActionSecurite actionsecurite)
        {
            if (ModelState.IsValid)
            {
                db.ActionSecurites.Add(actionsecurite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FicheSecuriteId = new SelectList(db.FicheSecurites, "FicheSecuriteID", "Code", actionsecurite.FicheSecuriteId);
            return View(actionsecurite);
        }

        // GET: /ActionSecurite/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActionSecurite actionsecurite = db.ActionSecurites.Find(id);
            if (actionsecurite == null)
            {
                return HttpNotFound();
            }
            ViewBag.FicheSecuriteId = new SelectList(db.FicheSecurites, "FicheSecuriteID", "Code", actionsecurite.FicheSecuriteId);
            return View(actionsecurite);
        }

        // POST: /ActionSecurite/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ActionSecuriteId,FicheSecuriteId,Code,Description,FaitPar")] ActionSecurite actionsecurite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actionsecurite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FicheSecuriteId = new SelectList(db.FicheSecurites, "FicheSecuriteID", "Code", actionsecurite.FicheSecuriteId);
            return View(actionsecurite);
        }

        // GET: /ActionSecurite/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActionSecurite actionsecurite = db.ActionSecurites.Find(id);
            if (actionsecurite == null)
            {
                return HttpNotFound();
            }
            return View(actionsecurite);
        }

        // POST: /ActionSecurite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActionSecurite actionsecurite = db.ActionSecurites.Find(id);
            db.ActionSecurites.Remove(actionsecurite);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
