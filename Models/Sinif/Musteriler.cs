using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models.Sinif
{
    public class Musteriler
    {
        [Key]
        public int id { get; set; }
        public string MusteriAdSoyad { get; set; }
        public string EPosta { get; set; }
        public string Adres { get; set; }
        public decimal Telefon { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public bool Durum { get; set; }
        public virtual ICollection<Sparisler> Sparisler { get; set; }
    }
}