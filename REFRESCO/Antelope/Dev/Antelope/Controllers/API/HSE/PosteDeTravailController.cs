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
    public class PosteDeTravailController : ApiController
    {
        private AntelopeEntities db = new AntelopeEntities();

        // GET api/PosteDeTravail
        public IQueryable<PosteDeTravail> GetPosteDeTravails()
        {
            return db.PosteDeTravails;
        }

        public HttpResponseMessage GetPosteDeTravailsByZoneId(int id)
        {

            var queryPosteDeTravail = from a in db.PosteDeTravails
                            where a.ZoneId == id
                            orderby a.Rang
                            select a;
            List<PosteDeTravail> AllPosteDeTravail = queryPosteDeTravail.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, AllPosteDeTravail);
        }

        // GET api/PosteDeTravail/5
        [ResponseType(typeof(PosteDeTravail))]
        public IHttpActionResult GetPosteDeTravail(int id)
        {
            PosteDeTravail postedetravail = db.PosteDeTravails.Find(id);
            if (postedetravail == null)
            {
                return NotFound();
            }

            return Ok(postedetravail);
        }

        // PUT api/PosteDeTravail/5
        public IHttpActionResult PutPosteDeTravail(int id, PosteDeTravail postedetravail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postedetravail.PosteDeTravailId)
            {
                return BadRequest();
            }

            db.Entry(postedetravail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosteDeTravailExists(id))
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

        // POST api/PosteDeTravail
        [ResponseType(typeof(PosteDeTravail))]
        public IHttpActionResult PostPosteDeTravail(PosteDeTravail postedetravail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PosteDeTravails.Add(postedetravail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = postedetravail.PosteDeTravailId }, postedetravail);
        }

        // DELETE api/PosteDeTravail/5
        [ResponseType(typeof(PosteDeTravail))]
        public IHttpActionResult DeletePosteDeTravail(int id)
        {
            PosteDeTravail postedetravail = db.PosteDeTravails.Find(id);
            if (postedetravail == null)
            {
                return NotFound();
            }

            db.PosteDeTravails.Remove(postedetravail);
            db.SaveChanges();

            return Ok(postedetravail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PosteDeTravailExists(int id)
        {
            return db.PosteDeTravails.Count(e => e.PosteDeTravailId == id) > 0;
        }
    }
}