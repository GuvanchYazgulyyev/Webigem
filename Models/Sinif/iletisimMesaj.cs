using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models.Sinif
{
    public class iletisimMesaj
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Ad Soyan Zorunlu!!!")]
        public string AdSoyad { get; set; }

        [Required(ErrorMessage = "E Posta Zorunlu!!!")]
        public string EPosta { get; set; }

        [Required(ErrorMessage = "Konu Zorunlu!!!")]
        public string Konu { get; set; }

        [Required(ErrorMessage = "Mesaj Detay Zorunlu!!!")]
        public string Mesaj { get; set; }
    }
}