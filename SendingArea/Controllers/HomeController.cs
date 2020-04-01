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
        public ActionResult FirmaKaydi(string companyName, string authorizedName, int companyNumber,string companyEmail, string invoiceAddress, int taxNo, string taxOffice, string password)
        {
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
        public ActionResult MusteriKaydi(string username, string tc, string email, string password)
        {
            Models.CourierCompany company = new Models.CourierCompany();
            company.Name = username;
            company.Phone = tc;
            company.Address = email;
            company.TaxNo = password;
            company.TaxOffice = "TunayYilmaz";
            company.WriteClass();
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
        public ActionResult Customers()
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
    }
}