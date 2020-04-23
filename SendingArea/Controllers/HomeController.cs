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

        
    }
}