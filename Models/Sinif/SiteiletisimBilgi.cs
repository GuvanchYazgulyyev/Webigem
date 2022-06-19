using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models.Sinif
{
    public class SiteiletisimBilgi
    {
        [Key]
        public int id { get; set; }
        public string Baslik { get; set; }
        public string EPosta { get; set; }
        public decimal Tel { get; set; }
        public string Face { get; set; }
        public string inst { get; set; }
        public string tweet { get; set; }
        public string Likdl { get; set; }
    }
}