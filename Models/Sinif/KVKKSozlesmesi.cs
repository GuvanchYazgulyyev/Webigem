using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Models.Sinif
{
    public class KVKKSozlesmesi
    {
        [Key]
        public int id { get; set; }
        public string AltBaslik { get; set; }
        public string AltBaslik2 { get; set; }
        [AllowHtml]
        public string icerik { get; set; }
    }
}