using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class HizmetFormGonder
    {

            [Required(ErrorMessage = "Ad Soyad zorunludur!")]
            public string AdSoyad { get; set; }

            [Required(ErrorMessage = "E-Posta zorunludur!")]
            [EmailAddress(ErrorMessage = "Geçerli bir E-Posta giriniz!")]
            public string EPosta { get; set; }

            [Required(ErrorMessage = "Telefon numarası zorunludur!")]
            public string TelNo { get; set; }

            [Required(ErrorMessage = "Proje başlığı zorunludur!")]
            public string ProjeBaslik { get; set; }

            [Required(ErrorMessage = "Mesaj alanı boş bırakılamaz!")]
            public string Ileti { get; set; }

            public string TakipKodu { get; set; }
            public int HizmetId { get; set; }
            public DateTime Tarih { get; set; } = DateTime.Now;
            public bool Durum { get; set; } = true;
    }
}