using MyProject.Models.Sinif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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


            //var deger = dr.AdminGirises.Where(h => h.Durum == true).FirstOrDefault(f => f.EPosta == a.EPosta && f.Sifre == a.Sifre);
            //if (deger != null)
            //{
            //    FormsAuthentication.SetAuthCookie(deger.EPosta, false);
            //    Session["EPosta"] = deger.EPosta.ToString();
            //    return RedirectToAction("AdminIndex", "Admin");
            //}
            //else
            //{
            //    return RedirectToAction("Index", "MPanel");
            //}
        }









        [HttpGet]
        public ActionResult SifreResetA()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SifreResetA(AdminGiris k)
        {

            var model = dr.AdminGirises.Where(x => x.EPosta == k.EPosta && x.Durum == true).FirstOrDefault();
            if (model != null)
            {
                Guid rastgele = Guid.NewGuid();
                model.Sifre = rastgele.ToString().Substring(0, 10);
                dr.SaveChanges();
                SmtpClient client = new SmtpClient("mail.webigem.com", 587);
                client.EnableSsl = false;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("info@webigem.com", "Şifre Sıfırlama");
                mail.To.Add(model.EPosta);
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre Değiştirme İstegi";
                mail.Body = "Merhaba Sayın: <b> " + model.AdSoyad + " </b> <br/> Telefon Numaranız: <b> " + model.Telefon + " </b> <br/> E Posta Adresiniz: <b> " + model.EPosta + "</b> <br/> Yeni Şifreniz: <b> </b>" + model.Sifre;
                NetworkCredential net = new NetworkCredential("info@webigem.com", "MGankara9697");
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
