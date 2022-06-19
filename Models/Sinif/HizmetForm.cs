using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models.Sinif
{
    public class HizmetForm
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Ad Soyan Zorunlu!!!")]
        public string AdSoyad { get; set; }

        [Required(ErrorMessage = "E Posta Zorunlu!!!")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Geçerli E Posta Giriniz!")]

        public string EPosta { get; set; }

        [Required(ErrorMessage = "Tel No Zorunlu!!!")]
        //public int TelNo { get; set; }
        public string TelNo { get; set; }

        public string TakipKodu { get; set; }
        [Required(ErrorMessage = "Proje başlığı Zorunlu!!!")]
        public string ProjeBaslik { get; set; }

        public int Hizmetid { get; set; }
        public DateTime Tarih { get; set; }


        [Required(ErrorMessage = "Mesajınız Zorunludur!!!")]

        public string ileti { get; set; }
        public bool Durum { get; set; }
        public virtual Hizmetler Hizmetler { get; set; }
        public virtual ICollection<Notlar> Notlar { get; set; }
    }
}