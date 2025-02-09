using Microsoft.Ajax.Utilities;
using MyProject.Models.Sinif;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static System.Net.Mime.MediaTypeNames;
using Context = MyProject.Models.Sinif.Context;

namespace MyProject.Controllers
{
    [AllowAnonymous]
    public class MPanelController : Controller
    {
        // GET: MPanel

        Context dr = new Context();


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AdminLogin(AdminGiris a)
        {

            if (ModelState.IsValid)

            {
                var deger = dr.AdminGirises.Where(h => h.Durum == true).FirstOrDefault(f => f.EPosta == a.EPosta && f.Sifre == a.Sifre);


                if (deger != null)
                {
                    FormsAuthentication.SetAuthCookie(deger.EPosta, false);
                    Session["EPosta"] = deger.EPosta.ToString();
                    return RedirectToAction("AdminIndex", "Admin");
                }

                else
                {
                    TempData["mesaj"] = "Eksik Veya Hatalı Giriş!!!";
                    return RedirectToAction("Index", "MPanel");
                    // return View();
                }

            }
            TempData["mesaj"] = "Böyle Bir Kayıtlı kullanıcı yok!!!";
            return View();
        }









        [HttpGet]
        public ActionResult SifreResetA()
        {
            return View();
        }

        public ActionResult SifreResetA(AdminGiris k)
        {
            var model = dr.AdminGirises.Where(x => x.EPosta == k.EPosta && x.Durum == true).FirstOrDefault();
            if (model != null)
            {
                Guid rastgele = Guid.NewGuid();
                model.Sifre = rastgele.ToString().Substring(0, 10);
                dr.SaveChanges();

                SmtpClient client = new SmtpClient("mail.webigem.com.tr", 587);
                client.EnableSsl = false;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("info@webigem.com.tr", "Webigem Yazılım A.Ş | Şifre Sıfırlama");
                mail.To.Add(model.EPosta);
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre Değiştirme İsteği";

                // Yeni HTML İçeriği
                mail.Body = $@"
        <html>
        <head>
            <style>
                body {{font-family: 'Arial', sans-serif; background-color: #f4f6f9; margin: 0; padding: 0;}}
                .email-container {{width: 100%; max-width: 700px; margin: 0 auto; background-color: #ffffff; border-radius: 10px; box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);}}
                .email-header {{background-color: #3498db; color: #ffffff; padding: 40px 20px; text-align: center; border-radius: 10px 10px 0 0;}}
                .email-header h1 {{margin: 0; font-size: 32px; font-weight: bold; line-height: 1.2;}}
                .email-body {{padding: 30px 20px; color: #333333; font-size: 16px; line-height: 1.8;}}
                .email-body p {{margin: 10px 0;}}
                .email-body b {{color: #3498db;}}
                .cta-button {{display: inline-block; background-color: #3498db; color: white; padding: 15px 30px; font-size: 16px; text-decoration: none; border-radius: 5px; margin-top: 20px; text-align: center; transition: background-color 0.3s;}}
                .cta-button:hover {{background-color: #2980b9;}}
                .email-footer {{background-color: #f4f6f9; text-align: center; padding: 20px; font-size: 14px; color: #888888; border-radius: 0 0 10px 10px;}}
                .email-footer a {{color: #3498db; text-decoration: none;}}
                .email-footer a:hover {{text-decoration: underline;}}
            </style>
        </head>
        <body>
            <div class='email-container'>
                <div class='email-header'>
                    <h1>Şifre Değiştirme İsteği</h1>
                </div>
                <div class='email-body'>
                    <p>Merhaba Sayın <b>{model.AdSoyad}</b>,</p>
                    <p>Şifre sıfırlama talebiniz başarıyla alındı. Yeni şifreniz aşağıda belirtilmiştir:</p>
                    <p><b>Telefon Numaranız:</b> {model.Telefon}</p>
                    <p><b>E-Posta Adresiniz:</b> {model.EPosta}</p>
                    <p><b>Yeni Şifreniz:</b> <span style='font-weight: bold; font-size: 18px; color: #3498db;'>{model.Sifre}</span></p>
                    <p>Yeni şifreniz ile giriş yaptıktan sonra güvenliğiniz için şifrenizi değiştirmeniz önerilir.</p>
                    <div style='text-align: center;'>
                        <a href='https://webigem.com.tr/MPanel/SifreResetA' class='cta-button'>Şifrenizi Değiştirmek İçin Tıklayın</a>
                    </div>
                </div>
                <div class='email-footer'>
                    <p>Webigem Yazılım A.Ş. | Tüm hakları saklıdır. | <a href='https://webigem.com.tr/'>Webigem</a></p>
                </div>
            </div>
        </body>
        </html>";

                NetworkCredential net = new NetworkCredential("info@webigem.com.tr", "MGankara9697");
                client.Credentials = net;
                client.Send(mail);

                TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";
                return RedirectToAction("Index", "MPanel");
            }

            TempData["sifreyenile"] = "Hata!!! Böyle Bir E Posta Adresi Bulunamadı!!!";
            return View();
        }


        public ActionResult SifreResetAa(AdminGiris k)
        {
            var model = dr.AdminGirises.Where(x => x.EPosta == k.EPosta && x.Durum == true).FirstOrDefault();
            if (model != null)
            {
                Guid rastgele = Guid.NewGuid();
                model.Sifre = rastgele.ToString().Substring(0, 10);
                dr.SaveChanges();

                SmtpClient client = new SmtpClient("mail.webigem.com.tr", 587);
                client.EnableSsl = false;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("info@webigem.com.tr", "Webigem Yazılım A.Ş | Şifre Sıfırlama");
                mail.To.Add(model.EPosta);
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre Değiştirme İstegi";

                // HTML İçeriği
                mail.Body = $@"
<html>
<head>
    <style>
        body {{
            font-family: 'Arial', sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f6f9;
        }}
        .email-container {{
            width: 100%;
            max-width: 700px;
            margin: 0 auto;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
        }}
        .email-header {{
            background-color: #3498db;
            color: #ffffff;
            padding: 40px 20px;
            text-align: center;
            border-radius: 10px 10px 0 0;
        }}
        .email-header h1 {{
            margin: 0;
            font-size: 32px;
            font-weight: bold;
            line-height: 1.2;
        }}
        .email-body {{
            padding: 30px 20px;
            color: #333333;
            font-size: 16px;
            line-height: 1.8;
        }}
        .email-body p {{
            margin: 10px 0;
        }}
        .email-body b {{
            color: #3498db;
        }}
        .cta-button {{
            display: inline-block;
            background-color: #3498db;
            color: white;
            padding: 15px 30px;
            font-size: 16px;
            text-decoration: none;
            border-radius: 5px;
            margin-top: 20px;
            text-align: center;
            transition: background-color 0.3s;
        }}
        .cta-button:hover {{
            background-color: #2980b9;
        }}
        .email-footer {{
            background-color: #f4f6f9;
            text-align: center;
            padding: 20px;
            font-size: 14px;
            color: #888888;
            border-radius: 0 0 10px 10px;
        }}
        .email-footer a {{
            color: #3498db;
            text-decoration: none;
        }}
        .email-footer a:hover {{
            text-decoration: underline;
        }}
    </style>
</head>
<body>
    <div class=""email-container"">
        <!-- Header Section -->
        <div class=""email-header"">
            <h1>Şifre Değiştirme İsteği</h1>
        </div>
        
        <!-- Body Section -->
        <div class=""email-body"">
            <p>Merhaba Sayın <b>{model.AdSoyad}</b>,</p>
            <p>Şifre sıfırlama talebiniz başarıyla alındı. Yeni şifreniz aşağıda belirtilmiştir:</p>
            <p><b>Telefon Numaranız:</b> {model.Telefon}</p>
            <p><b>E-Posta Adresiniz:</b> {model.EPosta}</p>
            <p><b>Yeni Şifreniz:</b> <span style=""font-weight: bold; font-size: 18px; color: #3498db;"">{model.Sifre}</span></p>
            <p>Yeni şifreniz ile giriş yaptıktan sonra güvenliğiniz için şifrenizi değiştirmeniz önerilir.</p>

            <div style=""text-align: center;"">
                <a href=""https://webigem.com.tr/MPanel/SifreResetA"" class=""cta-button"">Şifrenizi Değiştirmek İçin Tıklayın</a>
            </div>
        </div>

        <!-- Footer Section -->
        <div class=""email-footer"">
            <p>Webigem Yazılım A.Ş. | Tüm hakları saklıdır. | <a href=""https://webigem.com.tr/"">Webigem</a></p>
        </div>
    </div>
</body>
</html>
    
";

                NetworkCredential net = new NetworkCredential("info@webigem.com.tr", "MGankara9697");
                client.Credentials = net;
                client.Send(mail);

                TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";
                return RedirectToAction("Index", "MPanel");
            }

            TempData["sifreyenile"] = "Hata!!! Böyle Bir E Posta Adresi Bulunamadı!!!";
            return View();
        }

    }
}
