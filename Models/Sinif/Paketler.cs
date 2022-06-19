using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Models.Sinif
{
    public class Paketler
    {
        [Key]
        public int id { get; set; }
        public decimal Fiyat { get; set; }
        public int inidirim { get; set; }
        public string Baslik { get; set; }
        [AllowHtml]
        public string Maddeler1 { get; set; }
        public string Maddeler2 { get; set; }
        public string Maddeler3 { get; set; }
        public string Maddeler4 { get; set; }
        public string Maddeler6 { get; set; }
        public string Maddeler7 { get; set; }
        public string Maddeler8 { get; set; }
        public bool Durum { get; set; }
        public virtual ICollection<Sparisler> Sparisler { get; set; }
    }
}