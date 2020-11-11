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

namespace baithi.Controllers
{
    public class khospsController : Controller
    {
        private quanlydocauEntities db = new quanlydocauEntities();

        // GET: khosps
        public async Task<ActionResult> Index()
        {
            var khosps = db.khosps.Include(k => k.sanpham);
            return View(await khosps.ToListAsync());
        }

        // GET: khosps/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            khosp khosp = await db.khosps.FindAsync(id);
            if (khosp == null)
            {
                return HttpNotFound();
            }
            return View(khosp);
        }

        // GET: khosps/Create
        public ActionResult Create()
        {
            ViewBag.IDsp = new SelectList(db.sanphams, "IDsp", "tensp");
            return View();
        }

        // POST: khosps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDsp,tensp,soluong")] khosp khosp)
        {
            if (ModelState.IsValid)
            {
                db.khosps.Add(khosp);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDsp = new SelectList(db.sanphams, "IDsp", "tensp", khosp.IDsp);
            return View(khosp);
        }

        // GET: khosps/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            khosp khosp = await db.khosps.FindAsync(id);
            if (khosp == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDsp = new SelectList(db.sanphams, "IDsp", "tensp", khosp.IDsp);
            return View(khosp);
        }

        // POST: khosps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDsp,tensp,soluong")] khosp khosp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khosp).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDsp = new SelectList(db.sanphams, "IDsp", "tensp", khosp.IDsp);
            return View(khosp);
        }

        // GET: khosps/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            khosp khosp = await db.khosps.FindAsync(id);
            if (khosp == null)
            {
                return HttpNotFound();
            }
            return View(khosp);
        }

        // POST: khosps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            khosp khosp = await db.khosps.FindAsync(id);
            db.khosps.Remove(khosp);
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
