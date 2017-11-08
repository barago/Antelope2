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
    public class ZoneController : ApiController
    {
        private AntelopeEntities db = new AntelopeEntities();

        // GET: api/Zones
        public IQueryable<Zone> GetZones()
        {
            return db.Zones;
        }

        public HttpResponseMessage GetZonesBySiteId(int id)
        {

            var queryZone = from a in db.Zones
                            where a.SiteId == id
                            orderby a.ZoneType.Rang
                            select a;
            List<Zone> AllZone = queryZone.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, AllZone);
        }


        // GET: api/Zones/5
        [ResponseType(typeof(Zone))]
        public IHttpActionResult GetZone(int id)
        {
            Zone zone = db.Zones.Find(id);
            if (zone == null)
            {
                return NotFound();
            }

            return Ok(zone);
        }

        // PUT: api/Zones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZone(int id, Zone zone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zone.ZoneID)
            {
                return BadRequest();
            }

            db.Entry(zone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZoneExists(id))
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

        // POST: api/Zones
        [ResponseType(typeof(Zone))]
        public IHttpActionResult PostZone(Zone zone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zones.Add(zone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = zone.ZoneID }, zone);
        }

        // DELETE: api/Zones/5
        [ResponseType(typeof(Zone))]
        public IHttpActionResult DeleteZone(int id)
        {
            Zone zone = db.Zones.Find(id);
            if (zone == null)
            {
                return NotFound();
            }

            db.Zones.Remove(zone);
            db.SaveChanges();

            return Ok(zone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZoneExists(int id)
        {
            return db.Zones.Count(e => e.ZoneID == id) > 0;
        }
    }
}