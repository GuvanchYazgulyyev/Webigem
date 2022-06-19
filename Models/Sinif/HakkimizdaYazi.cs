using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models.Sinif
{
    public class HakkimizdaYazi
    {
        [Key]
        public int id { get; set; }
        public string Baslik { get; set; }
        //public string Resim { get; set; }
        public string Kisaicerik { get; set; }
        public string HakkimizdaAltParametreBaslik { get; set; }
        public string HakkimizdaAltParametreSiraNo { get; set; }
        public string HakkimizdaAltParametreicerik { get; set; }
    }
}