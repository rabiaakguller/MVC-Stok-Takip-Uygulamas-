using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOK.Models.Entity;

namespace MVCSTOK.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        mvcstokEntities db = new mvcstokEntities();
        public ActionResult Index()
        {
            var degerler = db.musteriler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]

        public ActionResult YeniMusteri(musteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.musteriler.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult SİL(int id)
        {
            var musteri = db.musteriler.Find(id);
            //kategoriler içerisinde id den gelen veriyi bul
            db.musteriler.Remove(musteri);
            //kategoriden gelen değeri sil
            db.SaveChanges();
            //değişiklikleri kaydet
            return RedirectToAction("Index");
            //kategorilerin indexine yönlendir
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.musteriler.Find(id);
            //id den gelen değeri buluyor
            return View("MusteriGetir", mus);

        }

        public ActionResult Güncelle(musteriler p1) //kategorilerden bir değer türettik
        {
            var musteri = db.musteriler.Find(p1.MUSTERİID);
            musteri.MUSTERİAD = p1.MUSTERİAD;
            musteri.MUSTERİSOYAD = p1.MUSTERİSOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}