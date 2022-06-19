using FluentValidation;
using MyProject.Models.Sinif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.FluentValidation
{
    public class FormSendValidation : AbstractValidator<HizmetForm>
    {
        public FormSendValidation()
        {
            RuleFor(k => k.AdSoyad).NotEmpty().WithMessage("Ad Soyad Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.AdSoyad).MinimumLength(5).WithMessage("Ad Soyad Alanı Min 5 Karakter Olmalıdır!!!");
            RuleFor(k => k.AdSoyad).MaximumLength(30).WithMessage("Ad Soyad Alanı Max 30 Karakter Olmalıdır!!!");

            RuleFor(k => k.EPosta).NotEmpty().WithMessage("E Posta Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.EPosta).MinimumLength(5).WithMessage("E Posta Alanı Min 5 Karakter Olmalıdır!!!");
            RuleFor(k => k.EPosta).MaximumLength(30).WithMessage("E Posta Alanı Max 50 Karakter Olmalıdır!!!");

            RuleFor(k => k.TelNo).NotEmpty().WithMessage("Tel No Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.TelNo).MinimumLength(13).WithMessage("Tel No Alanı Min 13 Karakter Olmalıdır!!!");
            RuleFor(k => k.TelNo).MaximumLength(16).WithMessage("Tel No Alanı Max 16 Karakter Olmalıdır!!!");

            RuleFor(k => k.TakipKodu).NotEmpty().WithMessage("Takip Kodu Alanı Boş Bırakılmaz!!!");


            RuleFor(k => k.ProjeBaslik).NotEmpty().WithMessage("Proje Başlık Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.ProjeBaslik).MinimumLength(10).WithMessage("Proje Başlık Alanı Min 10 Karakter Olmalıdır!!!");
            RuleFor(k => k.ProjeBaslik).MaximumLength(100).WithMessage("Proje Başlık Alanı Max 100 Karakter Olmalıdır!!!");

            RuleFor(k => k.ileti).NotEmpty().WithMessage("Mesaj Alanı Boş Bırakılmaz!!!");
            RuleFor(k => k.ileti).MinimumLength(50).WithMessage("Mesaj Alanı Min 50 Karakter Olmalıdır!!!");
            RuleFor(k => k.ileti).MaximumLength(1000).WithMessage("Mesaj Alanı Max 1000 Karakter Olmalıdır!!!");



        }
    }
}