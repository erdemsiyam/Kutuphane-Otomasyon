using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneWeb.Models;

namespace KutuphaneWeb.Controllers
{
    public class homeController : Controller
    {
        KutuphaneDBContext ctx = new KutuphaneDBContext();

        // GET: home
        public ActionResult kitaplar()
        {
            var data = ctx.Kitaps.ToList();

            return View(data);
        }

        public ActionResult kitap_detay(Guid id)
        {

            Kitap kitap = ctx.Kitaps.FirstOrDefault(x => x.ID == id);

            if (kitap.Aktif == false)
            {
                OduncKitap ok = ctx.OduncKitaps.Where(x => x.KitapID == kitap.ID).OrderByDescending(x=>x.BaslangicTarih).FirstOrDefault();
                int kalan_gun = (int)(ok.BitisTarih - DateTime.Now).TotalDays;
                if (kalan_gun >= 0)
                    ViewBag.kalanGun = kalan_gun.ToString() + " Gün Sonra Geri Gelecek";
                else
                {
                    ViewBag.kalanGun = (kalan_gun * (-1)).ToString() + " Gün İadesi Gecikti.";
                }
            }

            return View(kitap);
        }


        
        public PartialViewResult _ilkKezKitapGetir()
        {
            var data = ctx.Kitaps.ToList();
            return PartialView("_kitapListeleWidget", data);
        }

        [HttpPost]
        public PartialViewResult _aramaKitapListele(string ara)
        {
            var data = ctx.Kitaps.Where(x => x.Adi.Contains(ara) || x.Yazar.Adi.Contains(ara)).ToList();
            
            return PartialView("_kitapListeleWidget",data);
        }

        [HttpPost]
        public PartialViewResult _filtreleSiralaKitapListele(int ara1, int ara2)
        {
            var data = ctx.Kitaps;

            if (ara1 == 0 && ara2 == 0)
            {
                return PartialView("_kitapListeleWidget", data.ToList());
            }


            if (ara1 == 1 && ara2 == 1)
            {
                return PartialView("_kitapListeleWidget", ctx.Kitaps.OrderByDescending(x => x.OkunmaSayisi).ToList());
            }
            else if (ara1 == 1 && ara2 == 2)
            {
                return PartialView("_kitapListeleWidget", ctx.Kitaps.OrderByDescending(x => x.AlimTarihi).ToList());
            }
            else if (ara1 == 2 && ara2 == 1)
            {
                return PartialView("_kitapListeleWidget", ctx.Kitaps.Where(x=> x.Aktif == true).OrderByDescending(x=>x.OkunmaSayisi).ToList());
            }
            else if (ara1 == 2 && ara2 == 2)
            {
                return PartialView("_kitapListeleWidget", ctx.Kitaps.Where(x => x.Aktif == true).OrderByDescending(x => x.AlimTarihi).ToList());
            }
            else if (ara1 == 3 && ara2 == 1)
            {
                return PartialView("_kitapListeleWidget", ctx.Kitaps.Where(x => x.Aktif == false).OrderByDescending(x => x.OkunmaSayisi).ToList());
            }
            else if (ara1 == 3 && ara2 == 2)
            {
                return PartialView("_kitapListeleWidget", ctx.Kitaps.Where(x => x.Aktif == false).OrderByDescending(x => x.AlimTarihi).ToList());
            }


            return PartialView("_kitapListeleWidget", data.ToList());
            /*
            if (ara1 == 2)
            {
                data.Where(x => x.Aktif == true);
            }
            else if (ara1 == 3)
            {
                data.Where(x => x.Aktif == false);
            }

            if (ara2 == 1)
            {
                data.OrderByDescending(x => x.OkunmaSayisi);
            }
            else if (ara2 == 2)
            {
                data.OrderByDescending(x => x.AlimTarihi);
            }

            return PartialView("_kitapListeleWidget", data.ToList());
            */
        }
    }
}