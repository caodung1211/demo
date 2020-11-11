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
    public class loaisController : Controller
    {
        private quanlydocauEntities db = new quanlydocauEntities();

        // GET: loais
        public async Task<ActionResult> Index()
        {
            var loais = db.loais.Include(l => l.sanpham);
            return View(await loais.ToListAsync());
        }

        // GET: loais/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loai loai = await db.loais.FindAsync(id);
            if (loai == null)
            {
                return HttpNotFound();
            }
            return View(loai);
        }

        // GET: loais/Create
        public ActionResult Create()
        {
            ViewBag.IDsp = new SelectList(db.sanphams, "IDsp", "tensp");
            return View();
        }

        // POST: loais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDsp,tensp,congdung")] loai loai)
        {
            if (ModelState.IsValid)
            {
                db.loais.Add(loai);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDsp = new SelectList(db.sanphams, "IDsp", "tensp", loai.IDsp);
            return View(loai);
        }

        // GET: loais/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loai loai = await db.loais.FindAsync(id);
            if (loai == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDsp = new SelectList(db.sanphams, "IDsp", "tensp", loai.IDsp);
            return View(loai);
        }

        // POST: loais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDsp,tensp,congdung")] loai loai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loai).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDsp = new SelectList(db.sanphams, "IDsp", "tensp", loai.IDsp);
            return View(loai);
        }

        // GET: loais/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loai loai = await db.loais.FindAsync(id);
            if (loai == null)
            {
                return HttpNotFound();
            }
            return View(loai);
        }

        // POST: loais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            loai loai = await db.loais.FindAsync(id);
            db.loais.Remove(loai);
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
