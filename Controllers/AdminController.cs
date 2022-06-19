using MyProject.Models.Sinif;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace MyProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        Context dr = new Context();
        // GET: Admin
        public ActionResult AdminIndex()
        {
            var mail = (string)Session["EPosta"];

            var adsoyad = dr.AdminGirises.Where(x => x.EPosta == mail).Select(k => k.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;



            var is2 = dr.Hizmetlers.Where(k => k.Durum == true).Count().ToString();
            ViewBag.d2 = is2;

            var is3 = dr.HizmetForms.Where(k => k.Durum == true).Count().ToString();
            ViewBag.d3 = is3;


            var is4 = dr.Paketlers.Where(k => k.Durum == true).Count().ToString();
            ViewBag.d4 = is4;

            var is5 = dr.Bloglars.Count().ToString();
            ViewBag.d5 = is5;

            var is6 = dr.Projelers.Count().ToString();
            ViewBag.d6 = is6;

            var is7 = dr.Takims.Count().ToString();
            ViewBag.d7 = is7;

            var is8 = dr.iletisimMesajs.Count().ToString();
            ViewBag.d8 = is8;

            return View();

        }



        //---------------------------------------Paketler
        public ActionResult AdminPaket()
        {
            var deger = dr.Paketlers.Where(x => x.Durum == true).ToList();
            return View(deger);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AdminPEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminPEkle(Paketler p)
        {
            p.Durum = true;
            dr.Paketlers.Add(p);
            dr.SaveChanges();
            return RedirectToAction("AdminPaket");
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult AdminPSil(int id)
        {
            var paketsil = dr.Paketlers.Find(id);
            paketsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("AdminPaket");
        }

        public ActionResult AdminPGetir(int id)
        {
            var bcrgtr = dr.Paketlers.Find(id);
            return View("AdminPGetir", bcrgtr);
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult AdminPGuncelle(Paketler b)
        {
            var a = dr.Paketlers.Find(b.id);
            a.Fiyat = b.Fiyat;
            a.Baslik = b.Baslik;
            a.inidirim = b.inidirim;
            a.Maddeler1 = b.Maddeler1;
       
            dr.SaveChanges();
            return RedirectToAction("AdminPaket");
        }


        // Müşteri Kaydı

        public ActionResult MusteriKaydi()
        {
            var valueee = dr.Musterilers.Where(k => k.Durum == true).ToList();
            return View(valueee);
        }


        // -----------------------------------------Hakkımda Bilgi Kısmı

        public ActionResult AdiminHakYazi()
        {
            var value = dr.HakkimizdaYazis.ToList();
            return View(value);
        }

        public ActionResult AdminHakSil(int id)
        {
            var value = dr.HakkimizdaYazis.Find(id);
            dr.HakkimizdaYazis.Remove(value);
            dr.SaveChanges();
            return RedirectToAction("AdiminHakYazi");
        }

        public ActionResult AdminHakGetir(int id)
        {
            var value = dr.HakkimizdaYazis.Find(id);
            return View("AdminHakGetir", value);
        }

        public ActionResult AdminHakguncelle(HakkimizdaYazi h)
        {


            var value = dr.HakkimizdaYazis.Find(h.id);
            value.Baslik = h.Baslik;
            value.Kisaicerik = h.Kisaicerik;

            value.HakkimizdaAltParametreicerik = h.HakkimizdaAltParametreicerik;
            value.HakkimizdaAltParametreSiraNo = h.HakkimizdaAltParametreSiraNo;
            value.HakkimizdaAltParametreBaslik = h.HakkimizdaAltParametreBaslik;
            dr.SaveChanges();
            return RedirectToAction("AdiminHakYazi");
        }











        ///---------------------------------------------------------------  Blog Sayfası Listele Sil Düzenle
        ///
        public ActionResult AdminBlog()
        {
            //var value = dr.Bloglar.Where(d => d.Durum == true).ToList();
            var value33 = dr.Bloglars.Where(k => k.Durum == true).OrderByDescending(l => l.id).ToList();

            return View(value33);
        }



        ///// Ekle
        ///

        [HttpGet]
        public ActionResult AdminBEkle()
        {
            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        [HttpPost]
        public ActionResult AdminBEkle(Bloglar u, HttpPostedFileBase File)
        {
           
            if (File != null)
            {
                FileInfo fileinfo = new FileInfo(File.FileName);
                WebImage img = new WebImage(File.InputStream);
                string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                //img.Resize(225, 180, false, false);
                string tamyol = "~/Resim/" + uzanti;
                img.Save(Server.MapPath(tamyol));
                u.Resim = "/Resim/" + uzanti;

            }

            if (u.Resim != null)
            {
                u.Resim = u.Resim;
            }
            u.Durum = true;
            dr.Bloglars.Add(u);
            dr.SaveChanges();
            return RedirectToAction("AdminBlog");



        }

        //// Blog Sil
        ///
        public ActionResult AdminBSil(int id)
        {
            var urnsil = dr.Bloglars.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("AdminBlog");
        }


        // Getir

        public ActionResult AdminBGetir(int id)
        {


            var urngetr = dr.Bloglars.Find(id);
            return View("AdminBGetir", urngetr);
        }

        // Güncellle

        public ActionResult UrunGuncelle(Bloglar u)
        {
            if (Request.Files.Count > 0)
            {
                if (u.Resim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Resim/" + dosyaad;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    u.Resim = "/Resim/" + dosyaad;
                }

            }

            var value = dr.Bloglars.Find(u.id);
            u.Durum = true;
            value.Baslik = u.Baslik;
            value.icerik = u.icerik;
            value.Alinti = u.Alinti;
            value.icerik2 = u.icerik2;
            if (u.Resim != null)
            {
                value.Resim = u.Resim;
            }
            value.Tarih = u.Tarih;
            dr.SaveChanges();
            return RedirectToAction("AdminBlog");
        }



        ///// ----------------------------------------------HizmetForm Not Ekle
        ///// 

        ////------------------------------------------------------------
        ///// Arama Yapma Kısmı--------------------------------------------------------------------
        public ActionResult AdminHizFormNot(string p)
        {

            var valueee = from x in dr.HizmetForms.Where(k => k.Durum == true).OrderByDescending(l => l.id) select x;
            if (!string.IsNullOrEmpty(p))
            {
                valueee = valueee.Where(x => x.TelNo.ToString().Contains(p));
            }
            return View(valueee.ToList());



            //var value = dr.HizmetForm.Where(d => d.Durum == true).ToList();
            //return View(value);
        }

        // Form Detay 
        public ActionResult AdminHizFormNotDetay(int id)
        {

            //var deger = dr.Urunler.ToList();
            //return View(deger);
            var deger1 = dr.HizmetForms.Where(x => x.id == id).ToList();
            return View(deger1);
        }
        ///
        ////-------------------------Girilen Notları Göster

        public PartialViewResult AdminHizFormNotGir(int id)
        {
            var YorumDeger = dr.Notlars.Where(x => x.Formid == id).OrderByDescending(k => k.Notid).ToList();
            return PartialView(YorumDeger);

        }

        ////-------------------------Not Gir
        [HttpGet]
        public PartialViewResult AdminHizFormNotYazdir(int id)
        {
            ViewBag.deger = id;
            return PartialView("AdminHizFormNotYazdir");
            //return PartialView();
        }

        [HttpPost]
        public PartialViewResult AdminHizFormNotYazdir(Notlar n, int id)
        {
            if (ModelState.IsValid)
            {

                //var mail = (string)Session["EPosta"];
                n.AdSoyad = (string)Session["EPosta"];
                n.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                n.Formid = id;
                n.Durum = true;
                dr.Notlars.Add(n);
                dr.SaveChanges();
                ViewBag.deger = id;
                ViewBag.kontrol3 = "Notunu İncele";
                ViewBag.Kontrol = "Notunuz Eklenmiştir!";
                return PartialView();
            }
            return PartialView();


            //var adsoyad = dr.AdminGiris.Where(x => x.EPosta == mail).Select(k => k.AdSoyad).FirstOrDefault();
            //ViewBag.adsoyad = deger;

        }

        ////------------------------------------------------------------Hizmet Formu
        ///// Arama Yapma Kısmı--------------------------------------------------------------------
        public ActionResult AdminHizForm(string p)
        {

            var urngtr = from x in dr.HizmetForms.Where(k => k.Durum == true).OrderByDescending(l => l.id) select x;
            if (!string.IsNullOrEmpty(p))
            {
                urngtr = urngtr.Where(x => x.TakipKodu.Contains(p));
            }
            return View(urngtr.ToList());


            //var value = dr.HizmetForm.Where(d => d.Durum == true).ToList();
            //return View(value);
        }




        //////  Sil
        ///// <summary>
        ///// 
        //[Authorize(Roles = "Admin")]
        public ActionResult AdminHFormSil(int id)
        {
            var urnsil = dr.HizmetForms.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("AdminHizForm");
        }


        // Getir

        public ActionResult AdminHiFormGetir(int id)
        {
            //List<SelectListItem> d1 = (from x in dr.Kategori.Where(d => d.Durum == true).ToList()
            //                           select new SelectListItem
            //                           {
            //                               Text = x.KategoriAd,
            //                               Value = x.id.ToString()
            //                           }).ToList();
            //ViewBag.dgr1 = d1;

            List<SelectListItem> d2 = (from x in dr.Hizmetlers.Where(d => d.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.HizmetAd,
                                           Value = x.id.ToString()
                                       }).ToList();
            ViewBag.dgr2 = d2;

            var urngetr = dr.HizmetForms.Find(id);
            return View("AdminHiFormGetir", urngetr);
        }

        // Güncellle
        //[Authorize(Roles = "Admin")]
        public ActionResult AdmHizFormGuncel(HizmetForm u)
        {
            var value = dr.HizmetForms.Find(u.id);
            value.AdSoyad = u.AdSoyad;
            value.EPosta = u.EPosta;
            value.TelNo = u.TelNo;
            value.ProjeBaslik = u.ProjeBaslik;
            //value.Kategoriid = u.Kategoriid;
            value.Hizmetid = u.Hizmetid;
            value.ileti = u.ileti;
            dr.SaveChanges();
            return RedirectToAction("AdminHizForm");
        }



        /////////////////////////////////---------------------------------------------- Hizmetler Ekle Güncelle Sil
        /////

        public ActionResult AdmHizmetler()
        {
            var value33 = dr.Hizmetlers.Where(k => k.Durum == true).OrderByDescending(l => l.id).ToList();

            //var value = dr.Hizmetler.Where(d => d.Durum == true).ToList();
            return View(value33);
        }



        ///// Ekle
        ///

        [HttpGet]
        public ActionResult AdmHizEkle()
        {
            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        [HttpPost]
        public ActionResult AdmHizEkle(Hizmetler u)
        {
            if (Request.Files.Count > 0)
            {
                if (u.iconResim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Resim/" + dosyaad + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    //u.Resim2 = "/Resim/" + dosyaad + uzanti;
                    u.iconResim = "/Resim/" + dosyaad + uzanti;
                }
            }

            if (Request.Files.Count > 0)
            {
                if (u.Resim2 != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[1].FileName);
                    string uzanti = Path.GetExtension(Request.Files[1].FileName);
                    string yol = "~/Resim/" + dosyaad + uzanti;
                    Request.Files[1].SaveAs(Server.MapPath(yol));
                    u.Resim2 = "/Resim/" + dosyaad + uzanti;
                    //u.iconResim = "/Resim/" + dosyaad + uzanti;
                }
            }

            //if (Request.Files.Count > 0)
            //{
            //    if (u.Video != null)
            //    {
            //        string dosyaad = Path.GetFileName(Request.Files[2].FileName);
            //        string uzanti = Path.GetExtension(Request.Files[2].FileName);
            //        string yol = "~/Resim/" + dosyaad + uzanti;
            //        Request.Files[2].SaveAs(Server.MapPath(yol));
            //        u.Video = "/Resim/" + dosyaad + uzanti;
            //        //u.iconResim = "/Resim/" + dosyaad + uzanti;
            //    }
            //}
       



            if (Request.Files.Count > 0)
            {
                if (u.HeaderResim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[2].FileName);
                    string uzanti = Path.GetExtension(Request.Files[2].FileName);
                    string yol = "~/Resim/" + dosyaad + uzanti;
                    Request.Files[2].SaveAs(Server.MapPath(yol));
                    u.HeaderResim = "/Resim/" + dosyaad + uzanti;
                    //u.iconResim = "/Resim/" + dosyaad + uzanti;
                }
            }

            dr.Hizmetlers.Add(u);
            u.Durum = true;
            if (u.iconResim != null)
            {
                u.iconResim = u.iconResim;
            }
            if (u.Resim2 != null)
            {
                u.Resim2 = u.Resim2;
            }
            if (u.HeaderResim != null)
            {
                u.HeaderResim = u.HeaderResim;
            }
            //if (u.Video != null)
            //{
            //    u.Video = u.Video;
            //}
        
            dr.SaveChanges();
            return RedirectToAction("AdmHizmetler");


        }

        ////// Hizmet Sil
        /////
        public ActionResult AdminHizmetSil(int id)
        {
            var urnsil = dr.Hizmetlers.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("AdmHizmetler");
        }


        // Getir

        public ActionResult AdminHizmetGetir(int id)
        {

            var urngetr = dr.Hizmetlers.Find(id);
            return View("AdminHizmetGetir", urngetr);
        }

        //// Güncellle

        public ActionResult AdminHizmetGuncel(Hizmetler u)
        {

            if (Request.Files.Count > 0)
            {
                if (u.iconResim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Resim/" + dosyaad + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    //u.Resim2 = "/Resim/" + dosyaad + uzanti;
                    u.iconResim = "/Resim/" + dosyaad + uzanti;
                }
            }

            if (Request.Files.Count > 0)
            {
                if (u.Resim2 != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[1].FileName);
                    string uzanti = Path.GetExtension(Request.Files[1].FileName);
                    string yol = "~/Resim/" + dosyaad + uzanti;
                    Request.Files[1].SaveAs(Server.MapPath(yol));
                    u.Resim2 = "/Resim/" + dosyaad + uzanti;
                    //u.iconResim = "/Resim/" + dosyaad + uzanti;
                }
            }
      
           

            if (Request.Files.Count > 0)
            {
                if (u.HeaderResim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[2].FileName);
                    string uzanti = Path.GetExtension(Request.Files[2].FileName);
                    string yol = "~/Resim/" + dosyaad + uzanti;
                    Request.Files[2].SaveAs(Server.MapPath(yol));
                    u.HeaderResim = "/Resim/" + dosyaad + uzanti;
                    //u.iconResim = "/Resim/" + dosyaad + uzanti;
                }
            }

            //try
            //{
            //    string strDateTime = System.DateTime.Now.ToString("ddMMyyyyHHMMss");
            //    string finalPath = "\\Resim\\" + strDateTime + u.UploadFile.FileName;
            //    string finalPath2 = "\\Resim\\" + strDateTime + u.UploadFile.FileName;

            //    u.UploadFile.SaveAs(Server.MapPath("~") + finalPath);
            //    u.iconResim = finalPath;
            //    u.Resim2 = finalPath2;
            //    ViewBag.Message = "Başarı İle Kaydedildi";

            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Message = ex.Message.ToString();
            //    return View();
            //}
            var value = dr.Hizmetlers.Find(u.id);
            if (u.iconResim != null)
            {
                value.iconResim = u.iconResim;
            }

            if (u.Resim2 != null)
            {
                value.Resim2 = u.Resim2;
            }
            if (u.HeaderResim != null)
            {
                value.HeaderResim = u.HeaderResim;
            }
            value.HizmetAd = u.HizmetAd;
            value.KisaYazi = u.KisaYazi;
          //  value.UzunBaslik = u.UzunBaslik;
            value.icerik1 = u.icerik1;
          

            dr.SaveChanges();
            return RedirectToAction("AdmHizmetler");

        }
        /////
        ////------------------------------------------------ -----------------------Slider
        /////
        public ActionResult AdminSlider()
        {
            //var value = dr.Bloglar.Where(d => d.Durum == true).ToList();
            var value33 = dr.Sliders.Where(k => k.Durum == true).OrderByDescending(l => l.id).ToList();

            return View(value33);
        }



        ///// Ekle
        ///

        [HttpGet]
        public ActionResult AdminSEkle()
        {

            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        [HttpPost]
        public ActionResult AdminSEkle(Slider u)
        {

            if (Request.Files.Count > 0)
            {
                if (u.Resim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Resim/" + dosyaad;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    u.Resim = "/Resim/" + dosyaad + uzanti;
                }
            }
            u.Durum = true;
            if (u.Resim != null)
            {
                u.Resim = u.Resim;
            }

            dr.Sliders.Add(u);
            dr.SaveChanges();
            return RedirectToAction("AdminSlider");

        }

        ////  Sil
        ///
        public ActionResult AdminSSil(int id)
        {
            var urnsil = dr.Sliders.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("AdminSlider");
        }


        // Getir

        public ActionResult AdminSGetir(int id)
        {

            var urngetr = dr.Sliders.Find(id);
            return View("AdminSGetir", urngetr);
        }

        // Güncellle

        public ActionResult AdminSGuncelle(Slider u)
        {
            if (Request.Files.Count > 0)
            {
                if (u.Resim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Resim/" + dosyaad;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    u.Resim = "/Resim/" + dosyaad + uzanti;
                }
            }

            var value = dr.Sliders.Find(u.id);
            value.Baslik = u.Baslik;
            value.KisaYazi = u.KisaYazi;
            if (u.Resim != null)
            {
                value.Resim = u.Resim;
            }

            dr.SaveChanges();
            return RedirectToAction("AdminSlider");


        }

        ///// 
        //////////-----------------------------------------Neden Biz

        public ActionResult AdminNedenBiz()
        {
            var value33 = dr.NedenBizs.ToList();
            return View(value33);
        }


        // Getir

        public ActionResult AdmNedenBizGtr(int id)
        {

            var urngetr = dr.NedenBizs.Find(id);
            return View("AdmNedenBizGtr", urngetr);
        }

        // Güncellle

        public ActionResult AdmNedenBizGuncel(NedenBiz u)
        {

            var value = dr.NedenBizs.Find(u.id);
            value.Baslik = u.Baslik;
            value.KisaYazi = u.KisaYazi;

            dr.SaveChanges();
            return RedirectToAction("AdminNedenBiz");
        }



        //////
        /////
        ///////--------------------------------------------------Portfoilo
        public ActionResult AdminPortfoil()
        {
            //var value = dr.Bloglar.Where(d => d.Durum == true).ToList();
            var value33 = dr.Projelers.OrderByDescending(l => l.id).ToList();
            return View(value33);
        }



        ///// Ekle
        ///

        [HttpGet]
        public ActionResult AdmPortEkle()
        {

            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        [HttpPost]
        public ActionResult AdmPortEkle(Projeler u)
        {
            if (Request.Files.Count > 0)
            {
                if (u.Resim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Resim/" + dosyaad;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    u.Resim = "/Resim/" + dosyaad;
                }
            }
            if (u.Resim != null)
            {
                u.Resim = u.Resim;
            }

            dr.Projelers.Add(u);
            dr.SaveChanges();
            return RedirectToAction("AdminPortfoil");
        }


        ////  Sil
        ///
        public ActionResult AdmPortSil(int id)
        {
            var urnsil = dr.Projelers.Find(id);
            dr.Projelers.Remove(urnsil);
            dr.SaveChanges();
            return RedirectToAction("AdminPortfoil");
        }


        // Getir

        public ActionResult AdmPortGetr(int id)
        {


            var urngetr = dr.Projelers.Find(id);
            return View("AdmPortGetr", urngetr);
        }

        // Güncellle

        public ActionResult AdmPortGuncell(Projeler u)
        {
            if (Request.Files.Count > 0)
            {
                if (u.Resim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Resim/" + dosyaad;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    u.Resim = "/Resim/" + dosyaad;
                }
            }

            var value = dr.Projelers.Find(u.id);
            value.Baslik = u.Baslik;
            value.Baslik2 = u.Baslik2;
            value.icerik = u.icerik;
            if (u.Resim != null)
            {
                value.Resim = u.Resim;
            }

            value.Tarih = u.Tarih;
            value.MusteriAd = u.MusteriAd;
            value.ProjeTip = u.ProjeTip;
            dr.SaveChanges();
            return RedirectToAction("AdminPortfoil");



        }

        ////////////-----------------------------------------------Takım-----------------
        /////

        public ActionResult AdmTakim()
        {
            //var value = dr.Bloglar.Where(d => d.Durum == true).ToList();
            var value33 = dr.Takims.ToList();

            return View(value33);
        }



        ///// Ekle
        ///

        [HttpGet]
        public ActionResult AdmTakimEkle()
        {

            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        [HttpPost]
        public ActionResult AdmTakimEkle(Takim u)
        {
            if (Request.Files.Count > 0)
            {
                if (u.Resim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Resim/" + dosyaad + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    u.Resim = "/Resim/" + dosyaad + uzanti;
                }
            }

            //if (u.Resim != null)
            //{
            //    u.Resim = u.Resim;
            //}

            dr.Takims.Add(u);
            dr.SaveChanges();
            return RedirectToAction("AdmTakim");


        }

        ////  Sil
        ///
        public ActionResult AdmTakimsil(int id)
        {
            var urnsil = dr.Takims.Find(id);
            dr.Takims.Remove(urnsil);
            dr.SaveChanges();
            return RedirectToAction("AdmTakim");
        }


        // Getir

        public ActionResult AdmTakGetr(int id)
        {


            var urngetr = dr.Takims.Find(id);
            return View("AdmTakGetr", urngetr);
        }

        // Güncellle

        public ActionResult AdmTakGuncel(Takim u)
        {
            if (Request.Files.Count > 0)
            {
                if (u.Resim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Resim/" + dosyaad + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    u.Resim = "/Resim/" + dosyaad + uzanti;
                }
            }

            var value = dr.Takims.Find(u.id);
            value.AdSoyad = u.AdSoyad;
            value.Meslek = u.Meslek;
            if (u.Resim != null)
            {
                value.Resim = u.Resim;
            }

            value.Face = u.Face;
            value.inst = u.inst;
            value.Tweet = u.Tweet;
            dr.SaveChanges();
            return RedirectToAction("AdmTakim");


        }

        //////////////////////------------------------Toplam Yapılan Proje Sayısı (Ana Sayfa)

        public ActionResult AdmtopYapilanp()
        {
            var value33 = dr.YapilanPSayisis.ToList();

            return View(value33);
        }


        // Getir

        public ActionResult AdmYapProjeGetr(int id)
        {


            var urngetr = dr.YapilanPSayisis.Find(id);
            return View("AdmYapProjeGetr", urngetr);
        }

        // Güncellle

        public ActionResult AdmYapProjeGuncelle(YapilanPSayisi u)
        {

            var value = dr.YapilanPSayisis.Find(u.id);
            value.Baslik = u.Baslik;
            value.sayi = u.sayi;
            dr.SaveChanges();
            return RedirectToAction("AdmtopYapilanp");
        }

        /////----------------------------------------------------------------------------------------------------//

        ///////////////-------------------Mutlu Müşteri Yorumları
        /////

        public ActionResult AdmMutMusYorum()
        {
            var value33 = dr.MutluMusYorumus.OrderByDescending(x => x.id).ToList();
            return View(value33);
        }
        ///// Ekle
        ///

        [HttpGet]
        public ActionResult AdmMutMusEkle()
        {

            return View();
        }
        // Veriler geldiginde HttpPost çalışır
        [HttpPost]
        public ActionResult AdmMutMusEkle(MutluMusYorumu u)
        {

            if (Request.Files.Count > 0)
            {
                if (u.Resim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Resim/" + dosyaad;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    u.Resim = "/Resim/" + dosyaad;
                }
            }



            dr.MutluMusYorumus.Add(u);
            if (u.Resim != null)
            {
                u.Resim = u.Resim;
            }
            dr.SaveChanges();
            return RedirectToAction("AdmMutMusYorum");
        }

        ////  Sil
        ///
        public ActionResult AdmMutMusSil(int id)
        {
            var urnsil = dr.MutluMusYorumus.Find(id);
            dr.MutluMusYorumus.Remove(urnsil);
            dr.SaveChanges();
            return RedirectToAction("AdmMutMusYorum");
        }


        // Getir

        public ActionResult AdmMutMusGetr(int id)
        {


            var urngetr = dr.MutluMusYorumus.Find(id);
            return View("AdmMutMusGetr", urngetr);
        }

        // Güncellle

        public ActionResult AdmMutMusGuncelle(MutluMusYorumu u)
        {
            if (Request.Files.Count > 0)
            {
                if (u.Resim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Resim/" + dosyaad;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    u.Resim = "/Resim/" + dosyaad;
                }
            }

            var value = dr.MutluMusYorumus.Find(u.id);
            if (u.Resim != null)
            {
                value.Resim = u.Resim;
            }
            value.BaslikAd = u.BaslikAd;
            value.icerik = u.icerik;
            dr.SaveChanges();
            return RedirectToAction("AdmMutMusYorum");
        }

        /////--------------------------------------------------------Referans Resimler-----------///
        /////

        public ActionResult AdmReferans()
        {
            //var value = dr.Bloglar.Where(d => d.Durum == true).ToList();
            var value33 = dr.Referanslars.ToList();

            return View(value33);
        }

        ////  Sil
        ///
        public ActionResult AdmRefSil(int id)
        {
            var urnsil = dr.Referanslars.Find(id);
            dr.Referanslars.Remove(urnsil);
            dr.SaveChanges();
            return RedirectToAction("AdmReferans");
        }

        ///// Ekle
        ///

        [HttpGet]
        public ActionResult AdmRefEkle()
        {

            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        [HttpPost]
        public ActionResult AdmRefEkle(Referanslar u)
        {
            if (Request.Files.Count > 0)
            {
                if (u.Resim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Resim/" + dosyaad + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    u.Resim = "/Resim/" + dosyaad + uzanti;
                }

            }


            dr.Referanslars.Add(u);

            dr.SaveChanges();
            return RedirectToAction("AdmReferans");



        }


        // Getir

        public ActionResult AdmRefGetr(int id)
        {


            var urngetr = dr.Referanslars.Find(id);
            return View("AdmRefGetr", urngetr);
        }

        // Güncellle

        public ActionResult AdmRefGuncelle(Referanslar u)
        {
            if (Request.Files.Count > 0)
            {
                if (u.Resim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Resim/" + dosyaad + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    u.Resim = "/Resim/" + dosyaad + uzanti;
                }

            }
            var value = dr.Referanslars.Find(u.id);
            if (u.Resim != null)
            {
                value.Resim = u.Resim;
            }

            dr.SaveChanges();
            return RedirectToAction("AdmReferans");
        }



        //}

        /////----------------------------------------------------------------İletişim (Bilgi)-----//////
        /////

        public ActionResult AdmiletsmBilgi()
        {
            var value33 = dr.SiteiletisimBilgis.ToList();

            return View(value33);
        }


        // Getir

        public ActionResult AdmiltGetr(int id)
        {


            var urngetr = dr.SiteiletisimBilgis.Find(id);
            return View("AdmiltGetr", urngetr);
        }

        // Güncellle

        public ActionResult AdmiltGuncelle(SiteiletisimBilgi u)
        {
            var value = dr.SiteiletisimBilgis.Find(u.id);
            value.Baslik = u.Baslik;
            value.EPosta = u.EPosta;
            value.Tel = u.Tel;
            value.Face = u.Face;
            value.inst = u.inst;
            value.tweet = u.tweet;
            value.Likdl = u.Likdl;

            dr.SaveChanges();
            return RedirectToAction("AdmiletsmBilgi");
        }

        /////----------------------------------------------------------------İletişim (Gelen Mesaj)-----//////
        /////

        public ActionResult AdmiletsmGMesaj(string p)
        {
            //var value33 = dr.iletisimMesaj.ToList();

            //return View(value33);
            var urngtr = from x in dr.iletisimMesajs.OrderByDescending(l => l.id) select x;
            if (!string.IsNullOrEmpty(p))
            {
                urngtr = urngtr.Where(x => x.EPosta.Contains(p));
            }
            return View(urngtr.ToList());
        }

        ////  Sil
        ///
        public ActionResult AdmMesjSil(int id)
        {
            var urnsil = dr.iletisimMesajs.Find(id);
            dr.iletisimMesajs.Remove(urnsil);
            dr.SaveChanges();
            return RedirectToAction("AdmiletsmGMesaj");
        }


        // Getir

        public ActionResult AdmMesjGetr(int id)
        {
            var urngetr = dr.iletisimMesajs.Find(id);
            return View("AdmMesjGetr", urngetr);
        }

        // Güncellle

        public ActionResult AdmMesjGuncelle(iletisimMesaj u)
        {
            var value = dr.iletisimMesajs.Find(u.id);
            value.AdSoyad = u.AdSoyad;
            value.EPosta = u.EPosta;
            value.Konu = u.Konu;
            value.Mesaj = u.Mesaj;
       
            dr.SaveChanges();
            return RedirectToAction("AdmiletsmGMesaj");
        }


        /////----------------------------------------------------------------Web Site Tanıtma (Ana Sayfa Kategorilerin Altı)-----//////
        /////

        public ActionResult AdmWebSiTanitma()
        {
            //var value = dr.Bloglar.Where(d => d.Durum == true).ToList();
            var value33 = dr.WebSiteTanitmas.ToList();

            return View(value33);
        }
        // Sil
        public ActionResult AdmWebSiTanitmaSil(int id)
        {
            var deger = dr.WebSiteTanitmas.Find(id);
            deger.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("AdmWebSiTanitma");
        }

        // Ekle
        [HttpGet]
        public ActionResult AdmWebSiTanitmaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdmWebSiTanitmaEkle(WebSiteTanitma u)
        {
            if (Request.Files.Count > 0)
            {
                if (u.Resim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Resim/" + dosyaad + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    u.Resim = "/Resim/" + dosyaad + uzanti;
                }

            }


            var deger = dr.WebSiteTanitmas.Add(u);
            deger.Durum = true;
            dr.SaveChanges();
            return RedirectToAction("AdmWebSiTanitma");
        }

        // Getir

        public ActionResult AdmWebSGetir(int id)
        {


            var urngetr = dr.WebSiteTanitmas.Find(id);
            return View("AdmWebSGetir", urngetr);
        }

        // Güncellle

        public ActionResult AdmWebSGuncelle(WebSiteTanitma u)
        {
            if (Request.Files.Count > 0)
            {
                if (u.Resim != null)
                {
                    string dosyaad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Resim/" + dosyaad;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    u.Resim = "/Resim/" + dosyaad + uzanti;
                }

            }
            var value = dr.WebSiteTanitmas.Find(u.id);
            value.Baslik = u.Baslik;
            value.UzunYazi = u.UzunYazi;
            value.Yazi3 = u.Yazi3;
            if (u.Resim != null)
            {
                value.Resim = u.Resim;
            }


            dr.SaveChanges();
            return RedirectToAction("AdmWebSiTanitma");



        }



        // Proje İlerleme Süreci Ana Sayfa


        public ActionResult AdmProjeCalismaSureci()
        {
            //var value = dr.Bloglar.Where(d => d.Durum == true).ToList();
            var value33 = dr.ProjeilerlemeSurecis.ToList();

            return View(value33);
        }
        // Sil
        public ActionResult AdmProjeCalismaSureciSil(int id)
        {
            var deger = dr.ProjeilerlemeSurecis.Find(id);
            dr.ProjeilerlemeSurecis.Remove(deger);
            dr.SaveChanges();
            return RedirectToAction("AdmProjeCalismaSureci");
        }

        // Ekle
        [HttpGet]
        public ActionResult AdmProjeCalismaSureciEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdmProjeCalismaSureciEkle(ProjeilerlemeSureci u)
        {
  
            var deger = dr.ProjeilerlemeSurecis.Add(u);
            dr.SaveChanges();
            return RedirectToAction("AdmProjeCalismaSureci");
        }

        // Getir

        public ActionResult AdmProjeCalismaSureciGetir(int id)
        {


            var urngetr = dr.ProjeilerlemeSurecis.Find(id);
            return View("AdmProjeCalismaSureciGetir", urngetr);
        }

        // Güncellle

        public ActionResult AdmProjeCalismaSureciGuncelle(ProjeilerlemeSureci u)
        {
            
            var value = dr.ProjeilerlemeSurecis.Find(u.id);
            value.Baslik = u.Baslik;
            value.Sayi = u.Sayi;
            value.AltBaslik = u.AltBaslik;
            dr.SaveChanges();
            return RedirectToAction("AdmProjeCalismaSureci");



        }












        //public ActionResult denem()
        //{
        //    return View();
        //}

        /////
        ///-----------------------------------------------------------------
        ///--------------------------------------------------Kullanıcı Güncelle Ekle Sil [Authorize(Roles ="Admin")]
        ///
        ///-----------
        ///
        public ActionResult Adminkullanici()
        {
            //var value = dr.Bloglar.Where(d => d.Durum == true).ToList();
            var value33 = dr.AdminGirises.Where(k => k.Durum == true).ToList();

            return View(value33);
        }



        ///// Ekle
        ///

        [HttpGet]
        public ActionResult AdminKulEkle()
        {
            List<SelectListItem> d1 = (from x in dr.AdminYetkis.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.YetkiAd,
                                           Value = x.id.ToString()
                                       }).ToList();
            ViewBag.dgr1 = d1;

            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        [HttpPost]
        public ActionResult AdminKulEkle(AdminGiris u)
        {
            //if (ModelState.IsValid)
            //{
            //}
            u.Durum = true;
            dr.AdminGirises.Add(u);
            dr.SaveChanges();
            return RedirectToAction("Adminkullanici");

            //return View();
        }

        ////  Sil
        ///
        public ActionResult AdminKulSil(int id)
        {
            var urnsil = dr.AdminGirises.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("Adminkullanici");
        }


        // Getir

        public ActionResult AdminKulGetr(int id)
        {
            List<SelectListItem> d1 = (from x in dr.AdminYetkis.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.YetkiAd,
                                           Value = x.id.ToString()
                                       }).ToList();
            ViewBag.dgr1 = d1;

            var urngetr = dr.AdminGirises.Find(id);
            return View("AdminKulGetr", urngetr);
        }

        // Güncellle

        public ActionResult AdmKulGuncelle(AdminGiris u)
        {

            var value = dr.AdminGirises.Find(u.id);
            value.AdSoyad = u.AdSoyad;
            value.Telefon = u.Telefon;
            value.EPosta = u.EPosta;
            value.Sifre = u.Sifre;
            value.Rolid = u.Rolid;
            dr.SaveChanges();
            return RedirectToAction("Adminkullanici");
        }




        ///---------------------------------------------------------------  Gizlilik  KVKKK ekle Sil
        ///
        public ActionResult AdminKVKK()
        {
            //var value = dr.Bloglar.Where(d => d.Durum == true).ToList();
            var value33 = dr.KVKKSozlesmesis.ToList();

            return View(value33);
        }



        ///// Ekle
        ///

        [HttpGet]
        public ActionResult AdminKVKKEkle()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        // Veriler geldiginde HttpPost çalışır
        [HttpPost]
        public ActionResult AdminKVKKEkle(KVKKSozlesmesi u)
        {


            dr.KVKKSozlesmesis.Add(u);
            dr.SaveChanges();
            return RedirectToAction("AdminKVKK");
        }


        ////  Sil
        //[Authorize(Roles = "Admin")]
        public ActionResult AdminKVKKSil(int id)
        {
            var urnsil = dr.KVKKSozlesmesis.Find(id);
            dr.KVKKSozlesmesis.Remove(urnsil);
            dr.SaveChanges();
            return RedirectToAction("AdminKVKK");
        }


        // Getir

        public ActionResult AdminKVKKGetr(int id)
        {

            var urngetr = dr.KVKKSozlesmesis.Find(id);
            return View("AdminKVKKGetr", urngetr);
        }

        // Güncellle
        //[Authorize(Roles = "Admin")]
        public ActionResult AdminKVKKGuncelle(KVKKSozlesmesi u)
        {


            var value = dr.KVKKSozlesmesis.Find(u.id);
            value.AltBaslik = u.AltBaslik;
            value.AltBaslik2 = u.AltBaslik2;
            value.icerik = u.icerik;
            dr.SaveChanges();
            return RedirectToAction("AdminKVKK");
        }


        ///---------------------------------------------------------------  SSS ekle Sil
        ///
        public ActionResult AdminSSS()
        {
            //var value = dr.Bloglar.Where(d => d.Durum == true).ToList();
            var value33 = dr.SSSes.ToList();

            return View(value33);
        }



        ///// Ekle
        ///
        [HttpGet]
        public ActionResult AdminSSSEkle()
        {
            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        [HttpPost]
        public ActionResult AdminSSSEkle(SSS u)
        {
            dr.SSSes.Add(u);
            dr.SaveChanges();
            return RedirectToAction("AdminSSS");
        }


        ////  Sil

        public ActionResult AdminSSSSil(int id)
        {
            var urnsil = dr.SSSes.Find(id);
            dr.SSSes.Remove(urnsil);
            dr.SaveChanges();
            return RedirectToAction("AdminSSS");
        }


        // Getir

        public ActionResult AdminSSSGetr(int id)
        {

            var urngetr = dr.SSSes.Find(id);
            return View("AdminSSSGetr", urngetr);
        }

        // Güncellle
        public ActionResult AdminSSSGuncelle(SSS u)
        {


            var value = dr.SSSes.Find(u.id);
            value.Baslik = u.Baslik;
            value.icerik = u.icerik;
            dr.SaveChanges();
            return RedirectToAction("AdminSSS");
        }

        /////
        ///-----------------------------------------------------------------Çıkış (Log Out)
        ///
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "MPanel");
        }


       
    }
}
