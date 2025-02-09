using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using MyProject.Heplers;
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
            var value = dr.Bloglars.Where(k => k.Durum == true).OrderByDescending(k => k.id).Take(3).ToList();
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
            // Hizmetler listesini doldur
            List<SelectListItem> d2 = (from x in dr.Hizmetlers.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.HizmetAd,
                                           Value = x.id.ToString()
                                       }).ToList();
            ViewBag.dgr2 = d2 ?? new List<SelectListItem>(); // Null kontrolü

            // Takip kodu oluştur
            ViewBag.takipkod = GenerateTakipKodu.KodUret() ?? "DEFAULT_CODE"; // Null kontrolü

            return View();
        }

        // Veriler geldiginde HttpPost çalışır  ------------------------- Tekrar  Göz atılması gerekiyor
        [HttpPost]
        public ActionResult FormSayfasi(HizmetFormGonder model)
        {
            if (ModelState.IsValid)
            {
                HizmetForm form = new HizmetForm
                {
                    Tarih = DateTime.Now,
                    Durum = true,
                    AdSoyad = model.AdSoyad,
                    EPosta = model.EPosta,
                    TelNo = model.TelNo,
                    TakipKodu = model.TakipKodu,
                    ProjeBaslik = model.ProjeBaslik,
                    Hizmetid = model.HizmetId,
                    ileti = model.Ileti
                };

                dr.HizmetForms.Add(form);
                dr.SaveChanges();
                MailHelper.SendMail(model);
                TempData["formgonder"] = "";
                return RedirectToAction("Index", "Default");
            }
            else
            {
                // Model geçerli değilse, ViewBag değerlerini tekrar ayarla
                List<SelectListItem> d2 = (from x in dr.Hizmetlers.Where(l => l.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.HizmetAd,
                                               Value = x.id.ToString()
                                           }).ToList();
                ViewBag.dgr2 = d2 ?? new List<SelectListItem>(); // Null kontrolü

                ViewBag.takipkod = GenerateTakipKodu.KodUret() ?? "DEFAULT_CODE"; // Null kontrolü

                // HizmetFormGonder modelini HizmetForm modeline dönüştür
                HizmetForm hizmetFormModel = new HizmetForm
                {
                    AdSoyad = model.AdSoyad,
                    EPosta = model.EPosta,
                    TelNo = model.TelNo,
                    TakipKodu = model.TakipKodu,
                    ProjeBaslik = model.ProjeBaslik,
                    Hizmetid = model.HizmetId,
                    ileti = model.Ileti
                };
                TempData["SuccessMessage"] = "";
                return View(hizmetFormModel); // HizmetForm modelini view'a gönder
            }
        }



        // Paketler
        public ActionResult Paketler()
        {
            var degerlerr = dr.Paketlers.Where(k => k.Durum == true).OrderByDescending(l => l.id).ToList();
            return View(degerlerr);
        }

    }
}