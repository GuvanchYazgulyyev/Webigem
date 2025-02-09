using MyProject.Models.Sinif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using MyProject.Models;

namespace MyProject.Heplers
{
    public class MailHelper
    {//465
        public static void SendMail(HizmetFormGonder model)
        {
            using (var client = new SmtpClient("mail.webigem.com.tr", 587))
            {
                client.EnableSsl = false;
                client.Credentials = new NetworkCredential("info@webigem.com.tr", "MGankara9697");

                // Timeout süresini artırmak
                client.Timeout = 30000; // 30 saniye (isteğe bağlı, ihtiyaca göre ayar yapabilirsiniz)

                var mail = new MailMessage
                {
                    From = new MailAddress("info@webigem.com.tr", "Webigem Yazılım A.Ş"),
                    Subject = model.ProjeBaslik,
                    IsBodyHtml = true,
                    Body = $@"
<html>
<head>
    <style>
        body {{
            font-family: 'Arial', sans-serif;
            background-color: #f7f7f7;
            margin: 0;
            padding: 0;
        }}
        .email-container {{
            width: 100%;
            max-width: 650px;
            margin: 0 auto;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
        }}
        .email-header {{
            background-color: #4b7bec;
            color: white;
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
            color: #4b7bec;
        }}
        .divider {{
            border-top: 2px solid #f0f0f0;
            margin: 20px 0;
        }}
        .cta-link {{
            display: inline-block;
            background-color: #4b7bec;
            color: white;
            padding: 12px 25px;
            font-size: 16px;
            text-decoration: none;
            border-radius: 5px;
            margin-top: 20px;
            text-align: center;
            transition: all 0.3s ease;
        }}
        .cta-link:hover {{
            background-color: #3658d6;
        }}
        .email-footer {{
            background-color: #f7f7f7;
            text-align: center;
            padding: 20px;
            font-size: 14px;
            color: #888888;
            border-radius: 0 0 10px 10px;
        }}
        .email-footer a {{
            color: #4b7bec;
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
            <h1>{model.ProjeBaslik}</h1>
        </div>
        
        <!-- Body Section -->
        <div class=""email-body"">
            <p><b>Ad Soyad:</b> {model.AdSoyad}</p>
            <p><b>Telefon:</b> {model.TelNo}</p>
            <p><b>E-Posta:</b> {model.EPosta}</p>
            <p><b>Takip Kodu:</b> {model.TakipKodu}</p>
            <p><b>Mesaj:</b></p>
            <p>{model.Ileti}</p>
            
            <!-- Divider -->
            <div class=""divider""></div>
            
            <!-- CTA Link (Call to Action) -->
            <a href=""https://webigem.com.tr/"" class=""cta-link"">Daha Fazla Bilgi İçin Web Sayfamızı Ziyaret Edin</a>
        </div>
        
        <!-- Footer Section -->
        <div class=""email-footer"">
            <p>Webigem Yazılım A.Ş. | Tüm hakları saklıdır. | <a href=""https://webigem.com.tr/Default/Hakkimizda"">Webigem</a></p>
        </div>
    </div>
</body>
</html>

  "

                };

                // E-postayı alıcılarına eklemek
                mail.To.Add(model.EPosta);
                mail.To.Add("info@webigem.com.tr");

                try
                {
                    // E-postayı gönderme
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    // Hata ayıklamak için
                    Console.WriteLine("Mail gönderimi sırasında bir hata oluştu: " + ex.Message);
                }
            }
        }

    }



}