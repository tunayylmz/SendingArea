using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult MyAccount()
        {
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
    }
}