using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;

namespace SendingArea.Controllers
{
    public class HomeController : Controller
    {
        public Models.TasiyiciFirma aktifFirma = new Models.TasiyiciFirma();
        
        public ActionResult PartialViewSample(string email, string password)
        {
            Models.Musteri musteriGirisBilgisi = new Models.Musteri();
            musteriGirisBilgisi.E_Posta = email;
            musteriGirisBilgisi.sifre = password;
            Models.SistemeGiris sistemeGiris = new Models.SistemeGiris();
            bool girdi = sistemeGiris.SistemeGirisIslemi();
            if (girdi)
            {
                FirmaKaydi();
            }
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PopupLogin()
        {
            return View();
        }
        [HttpGet]
        public ActionResult FirmaKaydi()
        {

            return View();
        }
        [HttpPost]
        public ActionResult FirmaKaydi(string taxPlate, string registerNewspaper, string companyName, string authorizedName, long companyNumber,string companyEmail, string invoiceAddress, long taxNo, string taxOffice, string password)
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
        [HttpGet]
        public ActionResult MusteriKaydi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriKaydi(string username,long phone, long tc, string email, string password)
        {
            Models.Musteri musteri = new Models.Musteri();
            musteri.Ad_Soyad = username;
            musteri.Cep_Tel = phone;
            musteri.TC_No = tc;
            musteri.E_Posta = email;
            musteri.sifre = password;
            musteri.MusteriKaydiOlusturma();
            return View();
        }
        public ActionResult Password()
        {
            return View();
        }
        public ActionResult Confirmation()
        {
            return View();
        }
        public ActionResult Payment()
        {
            return View();
        }
        public ActionResult AdminPanel()
        {
            return View();
        }
        public ActionResult Orders()
        {
            return View();
        }
        public ActionResult Companies()
        {
            return View();
        }
        public ActionResult TasiyiciFirmalar()
        {
            return View();
        }
        public ActionResult CanceledOrders()
        {
            return View();
        }
        public ActionResult ActivePasifCompanies()
        {
            return View();
        }
        public ActionResult CompaniesPanel()
        {
            return View();
        }

        public ActionResult PaymentInformation()
        {
            return View();
        }
        public ActionResult MyProfile()
        {
            return View();
        }
        public ActionResult ProfileSettings()
        {
            return View();
        }
        public ActionResult StoreClosure()
        {
            return View();
        }
        public ActionResult DenemeJquery()
        {
            return View();
        }
        public ActionResult LoginPopup()
        {
            return View();
        }
        [HttpGet]
        public ActionResult FirmaPersonelKayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FirmaPersonelKayit(string name,long phone,long tc, string email,string plaque,string brand,string model,long date,long capacity,long weight)
        {
            Models.FirmaPersonelKayit personelKayit = new Models.FirmaPersonelKayit();
            personelKayit.Firma_Kayit_Id = aktifFirma.Id;
            personelKayit.Ad_Soyad = name;
            personelKayit.Cep_Tel = phone;
            personelKayit.TC_No = tc;
            personelKayit.E_Posta = email;
            personelKayit.Motor_Plaka = plaque;
            personelKayit.Motor_Marka = brand;
            personelKayit.Motor_Model = model;
            personelKayit.Motor_Model_Yili = date;
            personelKayit.Motor_Tasima_Hacim = capacity;
            personelKayit.Motor_Tasima_Agirlik = weight;
            personelKayit.FirmaPersonelKaydiOlusturma();
            return View();
        }
    }
}