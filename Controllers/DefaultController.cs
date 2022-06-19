using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
using MyProject.Models.Sinif;

namespace MyProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        Context dr = new Context();

        private MailGonder email;
        // GET: Default
        [Route("/")]
        public ActionResult Index()
        {
            return View();
        }

        // Referanslar

        public PartialViewResult Referanslar()
        {
            var valuess = dr.Referanslars.ToList();
            return PartialView(valuess);
        }


        // Ana Sayfa Projler

        public PartialViewResult ProjelerPart()
        {
            var valuess = dr.Projelers.ToList();
            return PartialView(valuess);
        }


        // Projeler Kısmı
        public ActionResult Projeler()
        {
            var deger = dr.Projelers.OrderByDescending(k => k.id).ToList();
            return View(deger);
        }




        // Ana Hizmet
        [Route("Hizmetler/{id}/{ara3}")]
        public PartialViewResult AnaHizmet()
        {
            var value2 = dr.Hizmetlers.Where(k => k.Durum == true).ToList();
            return PartialView(value2);
        }

        // Proje Çalışma Süreci

        public PartialViewResult ProjeCalismaSureci()
        {
            var value2 = dr.ProjeilerlemeSurecis.ToList();
            return PartialView(value2);
        }

        // Toplam calısma Proje Sayısı

        public PartialViewResult TammlananPSayisi()
        {
            var deger = dr.YapilanPSayisis.ToList();
            return PartialView(deger);
        }


        // Toplam calısma Proje Sayısı 2

        public PartialViewResult TammlananPSayisi2()
        {
            var deger = dr.YapilanPSayisis.ToList();
            return PartialView(deger);
        }


        // Hakkımızda Partial2

        public PartialViewResult HakkimizdaPart()
        {
            var deger = dr.HakkimizdaYazis.ToList();
            return PartialView(deger);
        }


        // Hakkımızda Partial1 En Üst

        public PartialViewResult HakkimizdaPart1()
        {
            var deger = dr.HakkimizdaYazis.ToList();
            return PartialView(deger);
        }

        // Hakkımızda Footer 

        public PartialViewResult HakkimizdaFooter()
        {
            var deger = dr.HakkimizdaYazis.ToList();
            return PartialView(deger);
        }




        // Mutlu Muster Yorumu

        public PartialViewResult MMusteriYorumu()
        {
            var degerler = dr.MutluMusYorumus.ToList();
            return PartialView(degerler);
        }

        //Ana Sayfa Bloklar
        [Route("Hizmetler/{id}/{ara4}")]
        public PartialViewResult OneCikanBlok1()
        {
            var value = dr.Bloglars.Where(k => k.Durum == true).OrderByDescending(k=>k.id).Take(3).ToList();
            return PartialView(value);
        }

        // Hakkımızda

        public ActionResult Hakkimizda()
        {
            var deger = dr.HakkimizdaYazis.ToList();
            return View(deger);
        }

        // İletisim Kişimin Site Üzerinden attıgı mesajı gösterir
        [HttpGet]
        public ActionResult iletisim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult iletisim(iletisimMesaj m)
        {
            if (ModelState.IsValid)
            {
                dr.iletisimMesajs.Add(m);
                dr.SaveChanges();
                //ViewBag.Kontrol = "Mesajınız Başarılı Bir Şekilde Gönderilmiştir!";
                //return View();
                TempData["iletisimmesaj"] = "";
                return RedirectToAction("Index", "Default");
            }
            else
            {
                ViewBag.Kontrol = "Mesajınızı Göndeririken hata oluştu!!!!";
                return View();
            }
        }

        // İletişim Yazı
        public PartialViewResult iletisimBilgi()
        {
            var deger = dr.SiteiletisimBilgis.ToList();
            return PartialView(deger);
        }


        // İletişim Yazı Footer
        public PartialViewResult iletisimBilgiFooter()
        {
            var deger = dr.SiteiletisimBilgis.ToList();
            return PartialView(deger);
        }


        // İletişim Yazı Header
        public PartialViewResult iletisimBilgiHeader()
        {
            var deger = dr.SiteiletisimBilgis.ToList();
            return PartialView(deger);
        }





        // Takım

        public ActionResult BizimTakim()
        {
            var degerler = dr.Takims.ToList();
            return View(degerler);
        }

        //SSS
        public ActionResult SSS()
        {
            var valueee = dr.SSSes.ToList();
            return View(valueee);
        }

        // KVKK Sozleşmesi

        public ActionResult KVKK()
        {
            var degerler = dr.KVKKSozlesmesis.ToList();
            return View(degerler);
        }

        // Bloglar

        public ActionResult Bloglar()
        {
            var degerler = dr.Bloglars.Where(k => k.Durum == true).OrderByDescending(l => l.id).ToList();
            return View(degerler);
        }

        // Blog DEtay SAyfasının Partial Kısmı
        public PartialViewResult BlogArsivPartial()
        {
            var deger = dr.Bloglars.Where(k => k.Durum == true).OrderByDescending(l => l.id).ToList();
            return PartialView(deger);
        }

        // Blog DEtay SAyfasının Partial Kısmı
        public PartialViewResult PopulerBlogPartial()
        {
            var deger = dr.Bloglars.Where(k => k.Durum == true).OrderByDescending(l => l.id).ToList();
            return PartialView(deger);
        }

        // Blog Detay
        [Route("Hizmetler/{id}/{ara}")]
        public ActionResult BlogDetay(int id)
        {
            var abc = dr.Bloglars.Where(k => k.id == id).ToList();
            return View(abc);
        }
        // Tum Hizmetler

        public ActionResult TumHizmetler()
        {
            var degerlerr = dr.Hizmetlers.Where(k => k.Durum == true).OrderByDescending(l => l.id).ToList();
            return View(degerlerr);
        }

        // Hizmet Detay
        [Route("Hizmetler/{id}/{ara2}")]
        public ActionResult HizmetDetay(int id)
        {
            var degr4 = dr.Hizmetlers.Where(k => k.id == id).ToList();
            return View(degr4);
        }
        // Hizmet Detay Sayfasindaki Partial
        public PartialViewResult DigerHizmetler()
        {
            var derger = dr.Hizmetlers.Where(k => k.Durum == true).OrderByDescending(u => u.id).ToList();
            return PartialView(derger);
        }




        // Mail Yolu
        public DefaultController()
        {
            email = new MailGonder();
        }


        // Form Sayfası

        [HttpGet]
        public ActionResult FormSayfasi()

        {
            List<SelectListItem> d2 = (from x in dr.Hizmetlers.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.HizmetAd,
                                           Value = x.id.ToString()
                                       }).ToList();
            ViewBag.dgr2 = d2;

            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F", "G", "H", "V", "Q", "W", "Z" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakterler.Length);
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkod = kod;
            return View();

        }

        // Veriler geldiginde HttpPost çalışır  ------------------------- Tekrar  Göz atılması gerekiyor
        [HttpPost]
        public ActionResult FormSayfasi(HizmetForm h)
        {
            if (ModelState.IsValid)
            {
                if (h != null)
                {

                    h.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                    h.Durum = true;
                    dr.HizmetForms.Add(h);
                    dr.SaveChanges();
                    SmtpClient client = new SmtpClient("mail.webigem.com", 587);
                    client.EnableSsl = false;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("info@webigem.com", "Webigem Yazılım Şirketi A.Ş. Müşteri Talep Oluşturma");
                    mail.To.Add(h.EPosta);
                    mail.To.Add("info@webigem.com");
                    mail.IsBodyHtml = true;
                    mail.Subject = h.ProjeBaslik;
                   // mail.Body = "Merhaba Sayın: <b> " + h.AdSoyad + " </b> <br/> Telefon Numaranız: <b> " + h.TelNo + " </b> <br/> E Posta Adresiniz: <b> " + model.EPosta + "</b> <br/> E Posta Adresiniz: <b> </b>" + model.Sifre;
                    mail.Body = "<div style=background: #00d747;>Adınız Soyadınız: <b>" + h.AdSoyad + "</b> <br/>  Tel No:   <b> " + h.TelNo + "</b> <br/>  Proje Başlığı:   <b> " + h.ProjeBaslik + "</b> <br/> E-Posta: <b> "  + h.EPosta +  " <br/> </b> Takip Kodu: <b> " + h.TakipKodu + " <br/> </b> Kişinin Talepleri: <p> " + h.ileti + " <br/> </p> </div>";

                    NetworkCredential net = new NetworkCredential("info@webigem.com", "MGankara9697");
                    client.Credentials = net;
                    client.Send(mail);
                    ViewBag.Kontrol = "Başarı İle Mail Gönderildi";
                    TempData["formgonder"] = "";
                    return RedirectToAction("Index", "Default");
                }
            }
            else
            {
                return View();
            }
            return View();

        }


        // Paketler
        public ActionResult Paketler()
        {
            var degerlerr = dr.Paketlers.Where(k => k.Durum == true).OrderByDescending(l => l.id).ToList();
            return View(degerlerr);
        }

    }
}