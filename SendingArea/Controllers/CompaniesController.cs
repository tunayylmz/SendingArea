using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SendingArea.Controllers
{
    public class CompaniesController : Controller
    {
        public Models.TasiyiciFirma aktifFirma = new Models.TasiyiciFirma();
        // GET: Companies
        public ActionResult FirmaAnasayfa()
        {
            return View();
        }
        public ActionResult Siparisler()
        {
            return View();
        }
        public ActionResult IptalEdilenSiparisler()
        {
            return View();
        }
        public ActionResult Musteriler()
        {
            return View();
        }
        public ActionResult AktifPasifCalısanlar()
        {
            return View();
        }
        [HttpGet]
        public ActionResult FirmaPersonelKayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FirmaPersonelKayit(string name, long phone, long tc, string email, string plaque, string brand, string model, long date, long capacity, long weight)
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