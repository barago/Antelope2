using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;

namespace Antelope.Controllers.API.HSE
{
    public class LieuController : ApiController
    {
        private AntelopeEntities db = new AntelopeEntities();

        // GET: api/Lieu
        public IQueryable<Lieu> GetLieux()
        {
            return db.Lieux;
        }

        public HttpResponseMessage GetLieuxByZoneId(int id)
        {

            var queryLieu = from a in db.Lieux
                            where a.ZoneId == id
                            orderby a.Rang
                            select a;
            List<Lieu> AllLieu = queryLieu.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, AllLieu);
        }

        // GET: api/Lieu/5
        [ResponseType(typeof(Lieu))]
        public IHttpActionResult GetLieu(int id)
        {
            Lieu lieu = db.Lieux.Find(id);
            if (lieu == null)
            {
                return NotFound();
            }

            return Ok(lieu);
        }

        // PUT: api/Lieu/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLieu(int id, Lieu lieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lieu.LieuID)
            {
                return BadRequest();
            }

            db.Entry(lieu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LieuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Lieu
        [ResponseType(typeof(Lieu))]
        public IHttpActionResult PostLieu(Lieu lieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lieux.Add(lieu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lieu.LieuID }, lieu);
        }

        // DELETE: api/Lieu/5
        [ResponseType(typeof(Lieu))]
        public IHttpActionResult DeleteLieu(int id)
        {
            Lieu lieu = db.Lieux.Find(id);
            if (lieu == null)
            {
                return NotFound();
            }

            db.Lieux.Remove(lieu);
            db.SaveChanges();

            return Ok(lieu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LieuExists(int id)
        {
            return db.Lieux.Count(e => e.LieuID == id) > 0;
        }
    }
}