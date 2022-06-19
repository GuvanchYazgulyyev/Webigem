using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models.Sinif
{
    public class Takim
    {
        [Key]
        public int id { get; set; }
        public string AdSoyad { get; set; }
        public string Meslek { get; set; }
        public string Resim { get; set; }
        public string Face { get; set; }
        public string Tweet { get; set; }
        public string inst { get; set; }
        //public HttpPostedFileBase UploadFile { get; set; }

    }
}