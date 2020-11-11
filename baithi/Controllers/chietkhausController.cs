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
    public class chietkhausController : Controller
    {
        private quanlydocauEntities db = new quanlydocauEntities();

        // GET: chietkhaus
        public async Task<ActionResult> Index()
        {
            return View(await db.chietkhaus.ToListAsync());
        }

        // GET: chietkhaus/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chietkhau chietkhau = await db.chietkhaus.FindAsync(id);
            if (chietkhau == null)
            {
                return HttpNotFound();
            }
            return View(chietkhau);
        }

        // GET: chietkhaus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: chietkhaus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDchietkhau,soluong,chietkhauphantram")] chietkhau chietkhau)
        {
            if (ModelState.IsValid)
            {
                db.chietkhaus.Add(chietkhau);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(chietkhau);
        }

        // GET: chietkhaus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chietkhau chietkhau = await db.chietkhaus.FindAsync(id);
            if (chietkhau == null)
            {
                return HttpNotFound();
            }
            return View(chietkhau);
        }

        // POST: chietkhaus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDchietkhau,soluong,chietkhauphantram")] chietkhau chietkhau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chietkhau).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(chietkhau);
        }

        // GET: chietkhaus/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chietkhau chietkhau = await db.chietkhaus.FindAsync(id);
            if (chietkhau == null)
            {
                return HttpNotFound();
            }
            return View(chietkhau);
        }

        // POST: chietkhaus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            chietkhau chietkhau = await db.chietkhaus.FindAsync(id);
            db.chietkhaus.Remove(chietkhau);
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
