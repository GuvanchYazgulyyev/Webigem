using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models.Sinif
{
    public class Notlar
    {
        [Key]
        public int Notid { get; set; }
        public string AdSoyad { get; set; }
        public string icerik { get; set; }
        public int Formid { get; set; }
        public DateTime Tarih { get; set; }
        public bool Durum { get; set; }

        public virtual HizmetForm HizmetForm { get; set; }
    }
}