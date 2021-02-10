using IBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IBlog.Areas.admin.Controllers
{
    public class YorumlarAdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: admin/YorumlarAdmin
        public ActionResult Index()
        {
            return View(db.Yorumlar.OrderByDescending(x => x.Tarih).ToList());
        }
        public ActionResult Sil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.Yorumlar.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }
        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public ActionResult Sil(int id)
        {
            Yorum yorum = db.Yorumlar.Find(id);
            db.Yorumlar.Remove(yorum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detaylar(int? id)
        {
            Yorum yorum = db.Yorumlar.Find(id);
            return View(yorum);
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