using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baithi.Models;

namespace baithi.Controllers
{
    public class HomeController : Controller
    {
        private quanlydocauEntities db = new quanlydocauEntities();
        public ActionResult Index()
        {
            var sanphams = db.sanphams.ToList();
            return View(sanphams);
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