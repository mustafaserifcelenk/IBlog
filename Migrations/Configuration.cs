namespace IBlog.Migrations
{
    using IBlog.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IBlog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IBlog.Models.ApplicationDbContext context)
        {
            var kullaniciEmail = "ornek@gmail.com";

            if (!context.Users.Any(x => x.UserName == kullaniciEmail))
            {
                var kullanici = new ApplicationUser()
                {
                    UserName = kullaniciEmail,
                    Email = kullaniciEmail,
                    EmailConfirmed = true
                };
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new ApplicationUserManager(userStore);
                userManager.Create(kullanici, "Ankara1.");

            }
            if (!context.Kategoriler.Any())
            {
                context.Kategoriler.Add(new Kategori
                {
                    KategoriAd = "Kişisel Gelişim"
                });
                context.Kategoriler.Add(new Kategori
                {
                    KategoriAd = "Sağlık"
                });
                context.Kategoriler.Add(new Kategori
                {
                    KategoriAd = "Felsefe"
                });
                context.Kategoriler.Add(new Kategori
                {
                    KategoriAd = "Bilim-Teknoloji"
                });
                context.Kategoriler.Add(new Kategori
                {
                    KategoriAd = "Yaşam"
                });
            }
            if (!context.Makaleler.Any())
            {
                context.Makaleler.Add(new Makale
                {
                    Baslik = "Her sabah 7'te nasıl kalkılır?",
                    Icerik = "Alarm kur.",
                    OlusturulmaTarihi = new DateTime(2020, 06, 08),
                    ResimUrl = "Alarm.webp",
                    Yazar = "Mustafa Şerif Çelenk",
                    OkuyucuSayisi = 100,
                    KategoriId = 1
                });

                context.Makaleler.Add(new Makale
                {
                    Baslik = "Keyifli Yemek Yapmanın Yolları",
                    Icerik = "Denenmiş, ekonomik, nefis ve pratik yemek tarifleri, püf noktaları, videolar, güldürürken yediren ve öğreten içerikler...",
                    OlusturulmaTarihi = new DateTime(2020, 04, 13),
                    ResimUrl = "Yemek.jpg",
                    Yazar = "Berrak Göksu",
                    OkuyucuSayisi = 200,
                    KategoriId = 5
                });

                context.Makaleler.Add(new Makale
                {
                    Baslik = "Online Ticaret",
                    Icerik = "Her malın bir alıcısı vardır...",
                    OlusturulmaTarihi = new DateTime(2020, 10, 07),
                    ResimUrl = "eticaret.jpg",
                    Yazar = "Tuğba Duruştay",
                    OkuyucuSayisi = 200,
                    KategoriId = 4,
                    Yorumlar = new List<Yorum>()
                    {
                        new Yorum{
                        YorumIcerigi = "Çok güzel.",
                        Tarih = new DateTime(2020, 12, 05),
                        GonderenAdi = "Socrates"
                        }
                    }
                    //Yorumlar.Add(new Yorum()
                    //{
                    //    YorumIcerigi = "Çok güzel.",
                    //Tarih = new DateTime(2020, 12, 05),
                    //GonderenAdi = "Socrates"
                    //})
                });

            }
            if (!context.Yorumlar.Any())
            {
                context.Yorumlar.Add(new Yorum
                {
                    YorumIcerigi = "Çok güzel.",
                    Tarih = new DateTime(2020, 12, 05),
                    GonderenAdi = "Socrates",

                });
            }
        }
    }
}
