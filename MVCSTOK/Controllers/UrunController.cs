using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOK.Models.Entity;

namespace MVCSTOK.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun

        mvcstokEntities db = new mvcstokEntities();

        public ActionResult Index()
        {
            var degerler = db.urunler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            
            List<SelectListItem> degerler = (from i in db.kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORİAD,
                                                 Value = i.KATEGORİID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }
        [HttpPost]

        public ActionResult UrunEkle(urunler p1)
        {
            var ktg = db.kategoriler.Where(m => m.KATEGORİID == p1.kategoriler.KATEGORİID).FirstOrDefault();
            p1.kategoriler = ktg;
                
            db.urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SİL(int id)
        {
            var urun = db.urunler.Find(id);
            //kategoriler içerisinde id den gelen veriyi bul
            db.urunler.Remove(urun);
            //kategoriden gelen değeri sil
            db.SaveChanges();
            //değişiklikleri kaydet
            return RedirectToAction("Index");
            //kategorilerin indexine yönlendir
        }


        public ActionResult UrunGetir(int id)
        {
            var urun = db.urunler.Find(id);

            List<SelectListItem> degerler = (from i in db.kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORİAD,
                                                 Value = i.KATEGORİID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("UrunGetir", urun);

        }

        public ActionResult Güncelle(urunler p) //kategorilerden bir değer türettik
        {
            var urun = db.urunler.Find(p.URUNID);

            urun.URUNID = p.URUNID;
            urun.URUNAD = p.URUNAD;
            // urun.URUNKATEGORİ = p.URUNKATEGORİ;
            var ktg = db.kategoriler.Where(m => m.KATEGORİID == p.kategoriler.KATEGORİID).FirstOrDefault();
           urun.URUNKATEGORİ = ktg.KATEGORİID;
            urun.FİYAT = p.FİYAT;
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;

            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}