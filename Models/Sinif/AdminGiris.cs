using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models.Sinif
{
    public class AdminGiris
    {
        [Key]
        public int id { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public string EPosta { get; set; }
        public string Sifre { get; set; }
        public int Rolid { get; set; }
        public bool Durum { get; set; }
        public virtual AdminYetki AdminYetki { get; set; }
    }
}