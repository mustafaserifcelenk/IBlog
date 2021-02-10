using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IBlog.Models;

namespace IBlog.Areas.admin.Controllers
{
    public class MakalesAdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: admin/Makales
        public ActionResult Index()
        {
            return View(db.Makaleler.OrderByDescending(x => x.OlusturulmaTarihi).ToList());
        }

        // GET: admin/Makales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makaleler.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // GET: admin/Makales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Makales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Makale makale, HttpPostedFileBase Resim)
        {
            //if (ModelState.IsValid)
            //{
            if (Resim != null && Resim.ContentLength > 0)
            {
                var fileName = Path.GetFileName(Resim.FileName);
                var path = Path.Combine(Server.MapPath("~/Resimler"), fileName);
                Resim.SaveAs(path);
                makale.ResimUrl = "/Resimler/" + fileName;
                db.Makaleler.Add(makale);
                makale.OlusturulmaTarihi = DateTime.Now;
                makale.Yazar = "Admin";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //return View(makale);
            //db.Makaleler.Add(makale);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            //}
            return View(makale);
        }

        // GET: admin/Makales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makaleler.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // POST: admin/Makales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KategoriId,Baslik,Icerik,OlusturulmaTarihi,GuncellemeTarihi,ResimUrl,Yazar,OkuyucuSayisi")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                makale.OlusturulmaTarihi = makale.OlusturulmaTarihi;
                makale.GuncellemeTarihi = DateTime.Now;
                db.Entry(makale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(makale);
        }

        // GET: admin/Makales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makaleler.Find(id);
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        // POST: admin/Makales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Makale makale = db.Makaleler.Find(id);
            db.Makaleler.Remove(makale);
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
