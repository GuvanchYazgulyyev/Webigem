using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MyProject.Models
{
    public class MailGonder
    {
        public void Mail(string EPosta, string ProjeBaslik, string AdSoyad, string TelNo, string TakipKodu, string ileti)
        {
            SmtpClient client = new SmtpClient();
            MailAddress to = new MailAddress("info@webigem.com");
            MailAddress from = new MailAddress(EPosta, "info@webigem.com");//bizim mail adresi

            MailMessage msg = new MailMessage(from, to);
            msg.IsBodyHtml = true;
            msg.Subject = ProjeBaslik;
            msg.Body = "<div style=background: #00d747;>Adınız Soyadınız: " + AdSoyad + " <br/>  Gönderen Kişinin Tel No:   <h3> " + TelNo + " <br/> </h3>Gönderen Kişinin Takip Kodu: <h3> " + TakipKodu + " <br/> </ h3 > Kişinin Talepleri   <p> " + ileti + " <br/> </p> </div>";
            //msg.Body += "<p> Adınız Soyadınız: " + AdSoyad + "</p>"; //burada başında gönderen kişinin mail adresi geliyor
            //msg.Body += "Gönderen Mail Adresi " + to + " "; //burada başında gönderen kişinin mail adresi geliyor

            //msg.Body += "Gönderen Kişinin Tel No    <h3> " + TelNo + " </h3>";
            //msg.Body += "Gönderen Kişinin Takip Kodu   <h3> " + TakipKodu + " </h3>";
            ////msg.Body += "Gönderen Kişinin Hizmet Kategorisi   <h4> " + Kategoriid + " </h4>";
            ////msg.Body += "Gönderen Kişinin Talep Ettigi Hizmeti   <h4> " + Hizmetid + " </h4>";
            ////msg.Body += "Gönderinin Tarihi   <h4> " + Tarih + " </h4>";
            //msg.Body += "Kişinin Talepleri   <p> " + ileti + " </p> </div>";
            msg.CC.Add(EPosta);//herkes görür
            NetworkCredential info = new NetworkCredential("info@webigem.com", "MGankara9697");
            client.Port = 587;
            client.Host = "mail.webigem.com";
            client.EnableSsl = true;
            client.Credentials = info;
            client.Send(msg);
        }
    }
}