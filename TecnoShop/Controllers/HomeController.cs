using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TecnoShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace TecnoShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        ShopTeknoContext context = new ShopTeknoContext();


        public IActionResult Login(MusteriKayit model)
        {

            var data = context.MusteriKayits.FirstOrDefault();

            
            return RedirectToAction("Giris");
        }
        public IActionResult Login(SaticiKayit model)
        {

            var data = context.SaticiKayits.FirstOrDefault();

            return RedirectToAction("Giris");
        }

        public IActionResult Index()
        {
            
            List<UrunBilgi> urunBilgileri = context.UrunBilgis.ToList();

            return View(urunBilgileri);
        }


        [HttpPost]
        public IActionResult YorumEkle(string yorum, int urunId)
        {
            var yorumObj = new Yorumlar
            {
                UrunId = urunId,
                Yorum = yorum,
                MusteriId = (int)HttpContext.Session.GetInt32("MusteriId")
            };

            context.Yorumlars.Add(yorumObj);
            context.SaveChanges();

            return RedirectToAction("UrunDetay", new { id = urunId });
        }

        public IActionResult AnasayfaMusteri() {
            List<UrunBilgi> urunBilgileri = context.UrunBilgis.ToList();

            // View'e verileri gönder
            return View(urunBilgileri);
        }
        public IActionResult Giris()
        {
            return View();
        }
        public IActionResult IslemBasarili()
        {
            return View();
        }
        public IActionResult Sepet()
        {
            return View();
        }
        public IActionResult AnasayfaSatici()
        {
            var urunListesi = context.UrunBilgis.ToList();
            return View(urunListesi);
        }
        public IActionResult Buzdolabi()
        {
            // "Buzdolabı" kategorisine ait verileri veritabanından çekilir
            List<UrunBilgi> model = context.UrunBilgis.Where(x => x.Kategori == "Buzdolabı").ToList();

            return View(model);
        }
        public IActionResult CamasirMakinesi()
        {
            // "Çamaşır Makinesi" kategorisine ait verileri veritabanından çekilir
            List<UrunBilgi> model = context.UrunBilgis.Where(x => x.Kategori == "Çamaşır Makinesi").ToList();

            return View(model);
        }
        public IActionResult Firin()
        {
            List<UrunBilgi> model = context.UrunBilgis.Where(x => x.Kategori == "Fırın").ToList();
            return View(model);
        }

        public IActionResult Iletisim()
        {
            return View();
        }
        public IActionResult KahveMakinesi()
        {
            // "Kahve Makinesi" kategorisine ait verileri veritabanından çekilir
            List<UrunBilgi> model = context.UrunBilgis.Where(x => x.Kategori == "Kahve Makinesi").ToList();

            return View("Ocak", model);
        }

        public IActionResult MusteriHizmetleri()
        {
            return View();
        }

        public IActionResult MusteriHizmetleriSatici()
        {
            return View();
        }
        public IActionResult Bilgilerim()
        {
            return View();
        }

        public IActionResult MusteriKayitOl()
        {
            return View();
        }
        public IActionResult Yorumlar()
        {
            var yorumlar = context.Yorumlars
                                  .Include(y => y.Urun) // İlişkili ürün bilgilerini çekmek için Include kullanılır
                                  .ToList();

            return View(yorumlar);
        }

        public IActionResult Ocak()
        {
            List<UrunBilgi> model = context.UrunBilgis.Where(x => x.Kategori == "Ocak").ToList();
            return View(model);
        }
        public IActionResult SiparisBilgileri() { 
            return View();
        }

        public IActionResult Odeme()
        {
            return View();
        }
        public IActionResult SaticiKayitOl()
        {
            return View();
        }
        public IActionResult SaticiUrunDuzenleme()
        {
            var urunListesi = context.UrunBilgis.ToList();
            return View(urunListesi);

        }
        public IActionResult Telefon()
        {
            // "Telefon" kategorisine ait veriler veritabanından çekilir
            List<UrunBilgi> model = context.UrunBilgis.Where(x => x.Kategori == "Telefon").ToList();

            return View(model);
        }
        public IActionResult Televizyon()
        {
            List<UrunBilgi> model = context.UrunBilgis.Where(x => x.Kategori == "Televizyon").ToList();
            return View(model);
        }

        public IActionResult UrunDetay(int id) 
        {
            var product = context.UrunBilgis.FirstOrDefault(x => x.UrunBilgiId == id); // İlgili ürünü tekil olarak çekmek için FirstOrDefault kullanılır.

            if (product == null)
            {
                return NotFound(); 
            }
            var urunBilgiId = Convert.ToInt32(HttpContext.Request.Query["UrunBilgiId"]);


            return View(product); // Ürün bilgilerini içeren view'e ilgili ürünü gönderilir.
        }



        public IActionResult UrunDuzenleme(int urunId)
        {
            var urun = context.UrunBilgis.FirstOrDefault(x => x.UrunBilgiId == urunId);
            if (urun == null)
            {
                return NotFound(); // Ürün bulunamazsa 404 hatası döndürür
            }
            return View(urun);
        }
        public IActionResult UrunEkle()
        {
            return View();
        }


       
        //Urun Ekle Sayfasıdaki işlemler burdan oluyor

        [HttpPost]
        public IActionResult Urun(UrunBilgi urunBilgi, IFormFile Images)
        {
            if (Images != null && Images.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Images.CopyTo(memoryStream);
                    urunBilgi.Resim = memoryStream.ToArray();
                }
            }

            context.UrunBilgis.Add(urunBilgi);
            context.SaveChanges();

            return RedirectToAction("AnasayfaSatici");
        }

        public IActionResult SaticiKayit(SaticiKayit saticiKayit)
        {
            var kullanici = context.SaticiKayits.FirstOrDefault(x => x.KullaniciAdi == saticiKayit.KullaniciAdi);
            if (kullanici != null)
            {

                ModelState.AddModelError("KullaniciAdi", "Bu kullanıcı adı zaten kullanılmaktadır. Lütfen başka bir kullanıcı adı seçiniz.");
                return View("SaticiKayitOl", saticiKayit);
            }
            else
            {
                context.SaticiKayits.Add(saticiKayit);
                context.SaveChanges();
            }


            return RedirectToAction("Giris");
        }


        //Müsteri KayitOl sayfası verileri burdan alınıyor
        public IActionResult MusteriKayit(MusteriKayit musteriKayitBilgi)
        {
            var kullanici = context.MusteriKayits.FirstOrDefault(x => x.KullaniciAdi == musteriKayitBilgi.KullaniciAdi);
            if (kullanici != null)
            {
                ModelState.AddModelError("KullaniciAdi", "Bu kullanıcı adı zaten kullanılmaktadır. Lütfen başka bir kullanıcı adı seçiniz.");
                return View("MusteriKayitOl", musteriKayitBilgi);

            }
            else
            {
                context.MusteriKayits.Add(musteriKayitBilgi);
                context.SaveChanges();
            }


            return RedirectToAction("Giris");
        }

        [HttpPost]
        public IActionResult AnasayfaMusteri(MusteriKayit model)
        {
            var musteri = context.MusteriKayits.FirstOrDefault(m => m.KullaniciAdi == model.KullaniciAdi && m.Sifre == model.Sifre);

            if (musteri != null)
            {
                // KullaniciAdi'ni saklama işlemi
                HttpContext.Session.SetString("KullaniciAdi", musteri.KullaniciAdi);
                HttpContext.Session.SetInt32("MusteriId", musteri.MusteriId);
                HttpContext.Session.SetInt32("Yas", musteri.Yas);
                HttpContext.Session.SetString("Sehir",musteri.Sehir);
                HttpContext.Session.SetString("MusteriMailAdresi", musteri.MusteriMailAdresi);
                HttpContext.Session.SetString("MusteriTelefon", musteri.MusteriTelefon);




                return RedirectToAction("AnasayfaMusteri");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                return View("Giris");
            }
        }
        [HttpPost]
        public IActionResult AnasayfaSatici(SaticiKayit model)
        {
            var satici = context.SaticiKayits.FirstOrDefault(m => m.KullaniciAdi == model.KullaniciAdi && m.Sifre == model.Sifre);

            if (satici != null)
            {
                HttpContext.Session.SetString("KullaniciAdi", satici.KullaniciAdi);
                return RedirectToAction("AnasayfaSatici");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                return View("Giris");
            }
        }

        public IActionResult Sil(int urunId)
        {
            var u = context.UrunBilgis.FirstOrDefault(item => item.UrunBilgiId == urunId); // Belirtilen urunId'ye sahip ürünü bulunur
            if (u != null)
            {
                context.UrunBilgis.Remove(u); // Veriyi sil
                context.SaveChanges(); 
            }

            return RedirectToAction("AnasayfaSatici");
        }

        public IActionResult Guncelle(UrunBilgi urun)
        {
            // İlgili ürünü veritabanından çekilir
            var existingUrun = context.UrunBilgis.FirstOrDefault(x => x.UrunBilgiId == urun.UrunBilgiId);

            if (existingUrun != null)
            {
                // Güncelleme işlemleri
                existingUrun.Kategori = urun.Kategori;
                existingUrun.Markası = urun.Markası;
                existingUrun.UrunKodu = urun.UrunKodu;
                existingUrun.Fiyat = urun.Fiyat;
                existingUrun.AcıklamaDetay = urun.AcıklamaDetay;
                existingUrun.GarantiSuresi = urun.GarantiSuresi;
                existingUrun.TeknikOzellikler = urun.TeknikOzellikler;
                existingUrun.Stok = urun.Stok;
                existingUrun.KargoBilgisi = urun.KargoBilgisi;
                existingUrun.IadeBilgisi = urun.IadeBilgisi;
                

                // Veritabanına güncelleme işlemini uygulanır
                context.SaveChanges(); 

                return RedirectToAction("AnasayfaSatici");
            }

            return NotFound(); // Ürün bulunamazsa 404 hatası döndürülür
        }


        [HttpPost]
        public IActionResult OdemeBil(OdemeBilgisi odemeBilgisi)
        {
            context.OdemeBilgisis.Add(odemeBilgisi);
            context.SaveChanges();

            return RedirectToAction("IslemBasarili");
        }

        [HttpPost]
        public IActionResult SiparisBil(SiparisBilgileri siparisBilgileri)
        {
            
            context.SiparisBilgileris.Add(siparisBilgileri);
            context.SaveChanges();

            return RedirectToAction("Odeme");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}