using IBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IBlog.ViewModel
{
    public class MakaleYorumViewModel
    {
        public string ApplicationUserId { get; set; }
        public string Baslik { get; set; }
        public DateTime? BlogOlusturulmaZamani { get; set; }
        public string ResimUrl { get; set; }
        public string Icerik { get; set; }
        public string YorumIcerigi { get; set; }
        public DateTime? YorumOlusturulmaZamani { get; set; }
        public virtual ApplicationUser Ziyaretci { get; set; }
    }
}