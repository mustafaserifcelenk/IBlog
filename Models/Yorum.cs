using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IBlog.Models
{
    [Table("Yorumlar")]
    public class Yorum
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(3000, ErrorMessage = "En fazla 3000 karakter girebilirsiniz.")]
        [Display(Name = "Yorum İçeriği")]
        public string YorumIcerigi { get; set; }
        public string ApplicationUserId { get; set; }

        [Display(Name = "Gönderen Adı")]
        public string GonderenAdi { get; set; }
        public DateTime? Tarih { get; set; }
        public int MakaleId { get; set; }
        [JsonIgnore]
        public virtual Makale Makale { get; set; }
        public virtual ApplicationUser Ziyaretci { get; set; }
    }
}