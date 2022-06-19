using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Models.Sinif
{
    public class Hizmetler
    {
        [Key]
        public int id { get; set; }
        public string iconResim { get; set; }
        public string HizmetAd { get; set; }
        public string KisaYazi { get; set; }

        public string Resim2 { get; set; }

       
        public string HeaderResim { get; set; }
        public string UzunBaslik { get; set; }
        [AllowHtml]
        public string icerik1 { get; set; }
        public string icerik2 { get; set; }

        //[DataType(DataType.Upload)]
        public string Video { get; set; }
        public bool Durum { get; set; }
        public virtual ICollection<HizmetForm> HizmetForm { get; set; }

    }
}