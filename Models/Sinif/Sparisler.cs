using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models.Sinif
{
    public class Sparisler
    {
        [Key]
        public int id { get; set; }
        public string SparisNo { get; set; }
        public int Paketid { get; set; }
        public int Musteriid { get; set; }
        public DateTime Tarih { get; set; }
        public bool Durum { get; set; }

        public virtual Musteriler Musteriler { get; set; }
        public virtual Paketler Paketler { get; set; }
    }
}