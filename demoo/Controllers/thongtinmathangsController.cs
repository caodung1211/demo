using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using demoo.Models;

namespace demoo.Controllers
{
    public class thongtinmathangsController : Controller
    {
        private quanlyEntities db = new quanlyEntities();

        // GET: thongtinmathangs
        public ActionResult Index()
        {
            return View(db.thongtinmathangs.ToList());
        }

        // GET: thongtinmathangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thongtinmathang thongtinmathang = db.thongtinmathangs.Find(id);
            if (thongtinmathang == null)
            {
                return HttpNotFound();
            }
            return View(thongtinmathang);
        }

        // GET: thongtinmathangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: thongtinmathangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mamh,tenmh,theloai,nhacc,giaban,gianhap,soluong,url_image")] thongtinmathang thongtinmathang, HttpPostedFileBase url_image)
        {
            if (url_image != null)
            {
                string filename = Path.GetFileName(url_image.FileName);
                string url_img = Server.MapPath("~/Images/" + filename);
                url_image.SaveAs(url_img);

                thongtinmathang.url_image = filename;
            }
            if (ModelState.IsValid)
            {
                db.thongtinmathangs.Add(thongtinmathang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thongtinmathang);
        }

        // GET: thongtinmathangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thongtinmathang thongtinmathang = db.thongtinmathangs.Find(id);
            if (thongtinmathang == null)
            {
                return HttpNotFound();
            }
            return View(thongtinmathang);
        }

        // POST: thongtinmathangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mamh,tenmh,theloai,nhacc,giaban,gianhap,soluong,url_image")] thongtinmathang thongtinmathang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongtinmathang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thongtinmathang);
        }

        // GET: thongtinmathangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thongtinmathang thongtinmathang = db.thongtinmathangs.Find(id);
            if (thongtinmathang == null)
            {
                return HttpNotFound();
            }
            return View(thongtinmathang);
        }

        // POST: thongtinmathangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            thongtinmathang thongtinmathang = db.thongtinmathangs.Find(id);
            db.thongtinmathangs.Remove(thongtinmathang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
