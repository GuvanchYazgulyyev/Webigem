using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models.Sinif
{
    public class YapilanPSayisi
    {
        [Key]
        public int id { get; set; }
        public string Baslik { get; set; }
        public int? sayi { get; set; }
    }
}