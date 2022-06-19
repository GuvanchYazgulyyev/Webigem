using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models.Sinif
{
    public class SSS
    {
        [Key]
        public int id { get; set; }
        public string Baslik { get; set; }
        public string icerik { get; set; }
    }
}