using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOK.Models.Entity;

namespace MVCSTOK.Controllers
{
    public class KategoriController : Controller
    {
     
        mvcstokEntities db = new mvcstokEntities();

        //Entity klasörünün içinde bulunan modelimizdbi tanıtıtk.
        // db mvcstokentities sınıfından ürettiğimiz nesnemiz.
        //mvcstokentities bizim modelimizi tutuyor.
        //Modelimizin içinde de tablolarımız var.
        //tablolara ulaşmak için db nesnesine ihtiyacımız var.

        public ActionResult Index()
        {
            var degerler = db.kategoriler.ToList();

            //db nesnemizin içinde bulunan kategorileri bana listele.

            return View(degerler);
        }

        [HttpGet]
        public ActionResult Yenikategori()
        {
            return View();
        }//Herhangi bir işlem yapılmazsa sadece geriye döndürme işlemi yaptır.


        [HttpPost]

        public ActionResult Yenikategori(kategoriler p1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniKategori");
            }


            db.kategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult SİL(int id)
        {
            var kategori = db.kategoriler.Find(id);
            //kategoriler içerisinde id den gelen veriyi bul
            db.kategoriler.Remove(kategori);
            //kategoriden gelen değeri sil
            db.SaveChanges();
            //değişiklikleri kaydet
            return RedirectToAction("Index");
            //kategorilerin indexine yönlendir
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.kategoriler.Find(id);
            //id den gelen değeri buluyor
            return View("KategoriGetir", ktgr);

        }

        public ActionResult Güncelle(kategoriler p1) //kategorilerden bir değer türettik
        {
            var ktgr = db.kategoriler.Find(p1.KATEGORİID);
            ktgr.KATEGORİAD = p1.KATEGORİAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}