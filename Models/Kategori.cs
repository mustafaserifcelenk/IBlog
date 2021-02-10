using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IBlog.Models
{
    [Table("Kategoriler")]
    public class Kategori
    {
        public Kategori()
        {
            Makaleler = new HashSet<Makale>();
        }
        public int Id { get; set; }
        public int MakaleId { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz.")]
        [Display(Name = "Kategori Adı")]
        public string KategoriAd { get; set; }
        public ICollection<Makale> Makaleler { get; set; }
    }
}