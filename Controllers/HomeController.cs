using IBlog.Models;
using IBlog.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IBlog.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Makaleler.ToList());
        }

        public ActionResult Kategori()
        {
            return View();
        }

        public ActionResult BlogDetay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makale makale = db.Makaleler.Find(id);
            foreach (var item in db.Yorumlar.Where(x => x.MakaleId == id))
            {
                makale.Yorumlar.Add(item);
            }
            if (makale == null)
            {
                return HttpNotFound();
            }
            return View(makale);
        }

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult YorumEkle(YorumEkleViewModel vm)
        {
            if (ModelState.IsValid)
            {

                Yorum yorum = new Yorum()
                {
                    MakaleId = vm.MakaleId,
                    YorumIcerigi = vm.YorumIcerigi,
                    ApplicationUserId = User.Identity.GetUserId(),
                    Tarih = DateTime.Now
                };
                db.Yorumlar.Add(yorum);
                db.SaveChanges();

                YorumEklendiViewModel sonuc = new YorumEklendiViewModel()
                {
                    BasariMesaji = "Yorumunuz başarıyla eklendi.",
                    Ziyaretci = User.Identity.GetUserName(),
                    YorumIcerigi = yorum.YorumIcerigi,
                    YorumId = yorum.Id,
                    YazilmaZamani = yorum.Tarih.Value.ToShortDateString()
                };
                return Json(sonuc);
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { HataMesaji = "Yorumunuzu kontrol ederek tekrar göndermeyi deneyin." });
        }
    }
}