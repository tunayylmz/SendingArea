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
        
        public ActionResult Index()
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