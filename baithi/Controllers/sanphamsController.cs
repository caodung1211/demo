using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using baithi.Models;
using System.IO;

namespace baithi.Controllers
{
    public class sanphamsController : Controller
    {
        private quanlydocauEntities db = new quanlydocauEntities();

        // GET: sanphams
        public async Task<ActionResult> Index()
        {
            var sanphams = db.sanphams.ToList();
            return View(sanphams);
        }

        // GET: sanphams/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanpham sanpham = await db.sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // GET: sanphams/Create
        public ActionResult Create()
        {
            ViewBag.IDsp = new SelectList(db.khosps, "IDsp", "tensp");
            ViewBag.IDsp = new SelectList(db.loais, "IDsp", "tensp");
            ViewBag.IDsp = new SelectList(db.nccs, "IDsp", "ncc1");
            return View();
        }

        // POST: sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDsp,tensp,size,loai,hang,soluong,giathanh,anh")] sanpham sanpham, HttpPostedFileBase anh)
        {
            if (anh != null)
            {
                string filename = Path.GetFileName(anh.FileName);
                string url_img = Server.MapPath("~/Images/" + filename);
                anh.SaveAs(url_img);

                sanpham.anh = filename;
            }

            if (ModelState.IsValid)
            {
                db.sanphams.Add(sanpham);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDsp = new SelectList(db.khosps, "IDsp", "tensp", sanpham.IDsp);
            ViewBag.IDsp = new SelectList(db.loais, "IDsp", "tensp", sanpham.IDsp);
            ViewBag.IDsp = new SelectList(db.nccs, "IDsp", "ncc1", sanpham.IDsp);
            return View(sanpham);
        }

        // GET: sanphams/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanpham sanpham = await db.sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDsp = new SelectList(db.khosps, "IDsp", "tensp", sanpham.IDsp);
            ViewBag.IDsp = new SelectList(db.loais, "IDsp", "tensp", sanpham.IDsp);
            ViewBag.IDsp = new SelectList(db.nccs, "IDsp", "ncc1", sanpham.IDsp);
            return View(sanpham);
        }

        // POST: sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDsp,tensp,size,loai,hang,soluong,giathanh,anh")] sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDsp = new SelectList(db.khosps, "IDsp", "tensp", sanpham.IDsp);
            ViewBag.IDsp = new SelectList(db.loais, "IDsp", "tensp", sanpham.IDsp);
            ViewBag.IDsp = new SelectList(db.nccs, "IDsp", "ncc1", sanpham.IDsp);
            return View(sanpham);
        }

        // GET: sanphams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanpham sanpham = await db.sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // POST: sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            sanpham sanpham = await db.sanphams.FindAsync(id);
            db.sanphams.Remove(sanpham);
            await db.SaveChangesAsync();
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
