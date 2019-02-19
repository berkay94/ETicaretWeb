using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaretWeb.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Net;

namespace ETicaretWeb.Controllers
{
    public class SepetController : Controller
    {
        ETicaretWebEntities db = new ETicaretWebEntities();
        // GET: Sepet
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var sepets = db.Sepet.Where(a => a.RefAspNetUserId == userId).Include(s => s.Urunler);
            return View(sepets.ToList());
        }

        public ActionResult SepeteEkle(int? adet,int id)
        {
            string userId = User.Identity.GetUserId();
            Sepet s = db.Sepet.FirstOrDefault(a => a.RefAspNetUserId == userId && a.RefUrunId == id);
            Urunler u = db.Urunler.Find(id);

            if(s==null)
            {
                Sepet yeniurun = new Sepet()
                {
                    RefAspNetUserId = userId,
                    RefUrunId=id,
                    Adet=adet ?? 1,
                    Tutar=(adet ?? 1) * u.UrunFiyat
                };
                db.Sepet.Add(yeniurun);
            }
            else
            {
                s.Adet = s.Adet + (adet ?? 1);
                s.Tutar = s.Adet * u.UrunFiyat;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult SepetGuncelle(int? adet, int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Sepet sepet = db.Sepet.Find(id);
            if(sepet==null)
            {
                return HttpNotFound();
            }

            Urunler urun = db.Urunler.Find(sepet.RefUrunId);
            sepet.Adet = adet ?? 1;
            sepet.Tutar = sepet.Adet * urun.UrunFiyat;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            Sepet sepet = db.Sepet.Find(id);
            db.Sepet.Remove(sepet);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}