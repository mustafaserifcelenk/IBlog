using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IBlog.ViewModel
{
    public class YorumEkleViewModel
    {
        [Required(ErrorMessage = "Önce bir yorum yazmalısınız.")]
        [MaxLength(1000, ErrorMessage = "Yorumunuz {1} karakteri geçemez.")]
        public string YorumIcerigi { get; set; }

        public int MakaleId { get; set; }
    }
}