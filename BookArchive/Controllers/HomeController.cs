using BookArchive.Models;
using BookArchive.Models.Managers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookArchive.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // Anasayfa kitapları listeleniyor
        public ActionResult Index()
        {
            List<Kitap> kitaplar = db.Kitaplar.ToList();
            return View(kitaplar);
        }
        //**

        //Yeni kitap ekleniyor
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Kitap kitap)
        {
            db.Kitaplar.Add(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //**

        //Kayıtlı kitap siliniyor
        public ActionResult Delete(int id)
        {
            Kitap kitap = db.Kitaplar.Find(id);
            db.Kitaplar.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //**

        //Kayıtlı kitap güncelleniyor
        public ActionResult Update(int id)
        {
            Kitap kitap = db.Kitaplar.Find(id);
            return View(kitap);
        }

        [HttpPost]
        public ActionResult Update(Kitap k)
        {
            Kitap kitap = (from u in db.Kitaplar where u.ID == k.ID select u).FirstOrDefault();
            kitap.KitapAdi = k.KitapAdi;
            kitap.Yazar.YazarAd = k.Yazar.YazarAd;
            kitap.Yazar.YazarSoyad = k.Yazar.YazarSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //**
    }
}