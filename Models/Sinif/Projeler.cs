using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models.Sinif
{
    public class Projeler
    {
        [Key]
        public int id { get; set; }
        public string Baslik { get; set; }
        public string Baslik2 { get; set; }
        public string icerik { get; set; }
        public string Resim { get; set; }
        public string Tarih { get; set; }
        public string MusteriAd { get; set; }
        public string ProjeTip { get; set; }
        //public HttpPostedFileBase UploadFile { get; set; }

    }
}