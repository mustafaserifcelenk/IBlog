using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IBlog.ViewModel
{
    public class YorumEklendiViewModel
    {
        public string BasariMesaji { get; set; }
        public int YorumId { get; set; }
        public string YorumIcerigi { get; set; }
        public string Ziyaretci { get; set; }
        public string YazilmaZamani { get; set; }
    }
}