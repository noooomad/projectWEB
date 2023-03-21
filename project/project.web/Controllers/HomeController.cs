using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Burgers()
        {
            return View();
        }

        public ActionResult Alcogoli()
        {
            return View();
        }

        public ActionResult Deserti()
        {
            return View();
        }

        public ActionResult Pasta()
        {
            return View();
        }

        public ActionResult Pizza()
        {
            return View();
        }

        public ActionResult Reg()
        {
            return View();
        }

        public ActionResult Rolli()
        {
            return View();
        }

        public ActionResult Salat()
        {
            return View();
        }

        public ActionResult Supi()
        {
            return View();
        }

        public ActionResult Vegan()
        {
            return View();
        }

        public ActionResult Voiti()
        {
            return View();
        }

        public ActionResult Zakiski()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}