using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demoo.Models;

namespace demoo.Controllers
{
    public class HomeController : Controller
    {
        private quanlyEntities db = new quanlyEntities();
        public ActionResult Index()
        {
            var product = db.thongtinmathangs.ToList();
            return View(product);
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