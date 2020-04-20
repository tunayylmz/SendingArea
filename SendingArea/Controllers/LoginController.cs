using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using SendingArea.Models;

namespace SendingArea.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Giris()
        {
            return View();
        }
        [HttpGet]
        public void Logout()
        {
            Session.Abandon();
            Response.Redirect(Request.UrlReferrer.ToString());
            //return View();
        }

        [HttpPost]
        public ActionResult Giris(string email, string password)
        {

            Models.Musteri musteriGirisBilgisi = new Models.Musteri();
            musteriGirisBilgisi.E_Posta = email;
            musteriGirisBilgisi.Sifre = password;
            bool girdi = musteriGirisBilgisi.Kullanıcı_Girisi();
            if (girdi)
            {
                TempData["mesaj"] = null ;
                Session["is_login"] = "girildi";
                Session["E_Posta"] = musteriGirisBilgisi.E_Posta;
                if (musteriGirisBilgisi.Bireysel_Kurumsal.ToString() == "Kurumsal")
                {
                    Session["Name"] = musteriGirisBilgisi.kurumsal_musteri.Firma_Adi;
                }
                else {
                    Session["Name"] = musteriGirisBilgisi.bireysel_musteri.Ad_Soyad;
                }
                Response.Redirect("~/Home/Index");
            }
            else
            {
                TempData["mesaj"] = "Bilgileri kontrol ediniz";
                this.Session["is_login"] = "girilmedi";
            }
            return View();
            
        }
        public ActionResult SifreDegisikligi()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MusteriKaydi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriKaydi(string username, long phone, long tc, string email, string password)
        {
            Models.Musteri musteri = new Models.Musteri();
            //musteri.bireysel_musteri.Ad_Soyad = username;
            //musteri.Cep_Tel = phone;
            //musteri.TC_No = tc;
            //musteri.E_Posta = email;
            //musteri.sifre = password;
            //musteri.MusteriKaydiOlusturma();
            return View();
        }
        [HttpGet]
        public ActionResult FirmaKaydi()
        {

            return View();
        }
        [HttpPost]
        public ActionResult FirmaKaydi(string taxPlate, string registerNewspaper, string companyName, string authorizedName, long companyNumber, string companyEmail, string invoiceAddress, long taxNo, string taxOffice, string password)
        {
            SendingArea.Models.DataConverter pdf = new SendingArea.Models.DataConverter();

            Models.TasiyiciFirma firma = new Models.TasiyiciFirma();

            firma.Sirket_Adi = companyName;
            firma.Yetkili_AdSoyad = authorizedName;
            firma.Telefon_No = companyNumber;
            firma.Firma_Mail = companyEmail;
            firma.Fatura_Adresi = invoiceAddress;
            firma.Vergi_No = taxNo;
            firma.Vergi_Dairesi = taxOffice;
            firma.sifre = password;
            firma.FirmaKaydiOlusturma();
            return View();
        }

    }
}