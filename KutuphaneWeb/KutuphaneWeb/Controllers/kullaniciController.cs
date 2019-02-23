using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KutuphaneWeb.Models;
namespace KutuphaneWeb.Controllers
{
    public class kullaniciController : Controller
    {
        KutuphaneDBContext ctx = new KutuphaneDBContext();
        // GET: kullanici

        public ActionResult giris()
        {
            if (HttpContext.User.Identity.Name != "")
            { return RedirectToAction("kitaplar", "home"); }
            return View();
        }

        [HttpPost]
        public ActionResult giris_yap(Uye u)
        {
            
            string kAdi = ValidateUser(u.Email,u.Sifre);
            if (!string.IsNullOrEmpty(kAdi))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, u.Email, DateTime.Now, DateTime.Now.AddMinutes(15), true, kAdi, FormsAuthentication.FormsCookiePath);
                HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName);

                if (ticket.IsPersistent)
                {
                    ck.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(ck);

                FormsAuthentication.RedirectFromLoginPage(u.Email, true);
                return RedirectToAction("kitaplar", "home");
            }


            return RedirectToAction("giris");
        }

        [Authorize(Roles = "Uye,Admin")]
        public ActionResult cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("kitaplar", "home");
        }

        [Authorize(Roles = "Uye,Admin")]
        public ActionResult alinan_kitaplar()
        {
            Uye uye = ctx.Uyes.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name);

            var data = ctx.OduncKitaps.Where(x => x.GeriAlindiMi == false && x.UyeID == uye.ID).ToList();

            return View(data);
        }

        [Authorize(Roles = "Uye,Admin")]
        public ActionResult gecmis_listesi()
        {
            Uye uye = ctx.Uyes.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name);
            var data = ctx.OduncKitaps.Where(x => x.GeriAlindiMi == true && x.UyeID == uye.ID).ToList();

            return View(data);
        }

        string ValidateUser(string ka, string pwd)
        {
            Uye u = ctx.Uyes.FirstOrDefault(x => x.Email == ka && x.Sifre == pwd);

            if (u != null)
                return u.Email;
            else
                return "";
        }
    }
}