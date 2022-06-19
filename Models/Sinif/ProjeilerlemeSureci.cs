using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models.Sinif
{
    public class ProjeilerlemeSureci
    {
        [Key]
        public int id { get; set; }
        public int Sayi { get; set; }
        public string Baslik { get; set; }
        public string AltBaslik { get; set; }
    }
}