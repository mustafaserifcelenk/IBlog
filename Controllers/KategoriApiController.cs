using IBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace IBlog.Controllers
{
    public class KategoriApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<Kategori> GetKategoriler()
        {
            return db.Kategoriler;
        }

        [ResponseType(typeof(Kategori))]
        public IHttpActionResult GetKategori(int id)
        {
            Kategori kategori = db.Kategoriler.Find(id);
            if (kategori == null)
            {
                return NotFound();
            }

            return Ok(kategori);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutKategori(int id, Kategori kategori)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kategori.Id)
            {
                return BadRequest();
            }

            db.Entry(kategori).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategoriExists(id))
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

        [ResponseType(typeof(Kategori))]
        public IHttpActionResult PostKategori(Kategori kategori)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kategoriler.Add(kategori);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kategori.Id }, kategori);
        }

        // DELETE: api/KategoriApi/5
        [ResponseType(typeof(Kategori))]
        public IHttpActionResult DeleteKategori(int id)
        {
            Kategori kategori = db.Kategoriler.Find(id);
            if (kategori == null)
            {
                return NotFound();
            }

            db.Kategoriler.Remove(kategori);
            db.SaveChanges();

            return Ok(kategori);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KategoriExists(int id)
        {
            return db.Kategoriler.Count(e => e.Id == id) > 0;
        }

    }
}
