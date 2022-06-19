using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Models.Sinif
{
    public class Bloglar
    {
        [Key]
        public int id { get; set; }
        public string Baslik { get; set; }
        [AllowHtml]
        public string icerik { get; set; }
        [AllowHtml]
        public string Alinti { get; set; }
        public string icerik2 { get; set; }
        public string Resim { get; set; }
        public string Tarih { get; set; }
        public bool Durum { get; set; }
        //public HttpPostedFileBase UploadFile { get; set; }

    }
}