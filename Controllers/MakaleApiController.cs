using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using IBlog.Models;

namespace IBlog.Controllers
{
    [EnableCors("*","*","*")]
    public class MakaleApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MakaleApi
        public IQueryable<Makale> GetMakaleler()
        {
            return db.Makaleler;
        }

        // GET: api/MakaleApi/5
        [ResponseType(typeof(Makale))]
        public IHttpActionResult GetMakale(int id, int kategoriId)
        {
            Makale makale = db.Makaleler.Find(id);
            if (makale == null)
            {
                return NotFound();
            }

            return Ok(makale);
        }

        // PUT: api/MakaleApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMakale(int id, Makale makale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != makale.Id)
            {
                return BadRequest();
            }

            db.Entry(makale).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MakaleExists(id))
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

        // POST: api/MakaleApi
        [ResponseType(typeof(Makale))]
        public IHttpActionResult PostMakale(Makale makale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Makaleler.Add(makale);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = makale.Id }, makale);
        }

        // DELETE: api/MakaleApi/5
        [ResponseType(typeof(Makale))]
        public IHttpActionResult DeleteMakale(int id)
        {
            Makale makale = db.Makaleler.Find(id);
            if (makale == null)
            {
                return NotFound();
            }

            db.Makaleler.Remove(makale);
            db.SaveChanges();

            return Ok(makale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MakaleExists(int id)
        {
            return db.Makaleler.Count(e => e.Id == id) > 0;
        }
    }
}