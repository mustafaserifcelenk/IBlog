using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IBlog.Models
{
    [Table("Makaleler")]
    public class Makale
    {
        public Makale()
        {
            Kategoriler = new HashSet<Kategori>();
            Yorumlar = new HashSet<Yorum>();
        }
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "Kategori")]
        public int KategoriId { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "En fazla 150 karakter girebilirsiniz.")]
        [Display(Name = "Başlık Adı")]
        public string Baslik { get; set; }
        [Required]
        [Display(Name = "İçerik")]
        public string Icerik { get; set; }

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime? OlusturulmaTarihi { get; set; }

        [Display(Name = "Güncelleme Tarihi")]
        public DateTime? GuncellemeTarihi { get; set; }

        [Required]
        [Display(Name = "Resim")]
        public string ResimUrl { get; set; }
        public string Yazar { get; set; }

        [Display(Name = "Okuyucu Sayısı")]
        public int OkuyucuSayisi { get; set; }
        public int Like { get; set; }
        public ICollection<Kategori> Kategoriler { get; set; }
        public ICollection<Yorum> Yorumlar { get; set; }
    }
}