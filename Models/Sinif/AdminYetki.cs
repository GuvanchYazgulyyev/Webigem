using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models.Sinif
{
    public class AdminYetki
    {
        [Key]
        public int id { get; set; }
        public string YetkiAd { get; set; }
        public virtual ICollection<AdminGiris> AdminGiris { get; set; }
    }
}