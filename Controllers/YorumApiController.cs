using IBlog.Models;
using Newtonsoft.Json;
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
    public class YorumApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<Yorum> GetYorumlar()
        {
            return db.Yorumlar;
        }
        public class Deneme
        {
            public int Id { get; set; }
            public string YorumIcerigi { get; set; }
            public string GonderenAdi { get; set; }
            public DateTime? Tarih { get; set; }
            public int MakaleId { get; set; }
        }

        [ResponseType(typeof(Yorum))]
        public IHttpActionResult GetYorum(int id)
        {
            Yorum yorum = db.Yorumlar.Find(id);
            //Deneme deneme = new Deneme
            //{
            //    Id = yorum.Id,
            //    YorumIcerigi = yorum.YorumIcerigi,
            //    GonderenAdi = yorum.GonderenAdi,
            //    Tarih = yorum.Tarih,
            //    MakaleId = yorum.MakaleId
            //};
           
            if (yorum == null)
            {
                return NotFound();
            }

            return Json(yorum);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutYorum(int id, Yorum yorum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != yorum.Id)
            {
                return BadRequest();
            }

            db.Entry(yorum).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YorumExists(id))
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

        [ResponseType(typeof(Yorum))]
        public IHttpActionResult PostYorum(Yorum yorum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Yorumlar.Add(yorum);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = yorum.Id }, yorum);
        }

        // DELETE: api/YorumApi/5
        [ResponseType(typeof(Yorum))]
        public IHttpActionResult DeleteYorum(int id)
        {
            Yorum yorum = db.Yorumlar.Find(id);
            if (yorum == null)
            {
                return NotFound();
            }

            db.Yorumlar.Remove(yorum);
            db.SaveChanges();

            return Ok(yorum);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool YorumExists(int id)
        {
            return db.Yorumlar.Count(e => e.Id == id) > 0;
        }
    }
}
