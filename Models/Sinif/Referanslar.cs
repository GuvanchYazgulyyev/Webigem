using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models.Sinif
{
    public class Referanslar
    {
        [Key]
        public int id { get; set; }
        public string Resim { get; set; }
        //public HttpPostedFileBase UploadFile { get; set; }

    }
}