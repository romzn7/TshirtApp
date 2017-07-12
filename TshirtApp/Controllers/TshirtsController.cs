using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TshirtApp.Models;

namespace TshirtApp.Controllers
{
    public class TshirtsController : Controller
    {
        private TshirtAppDb db = new TshirtAppDb();

        // GET: Tshirts
        public ActionResult Index()
        {
            var tshirts = db.Tshirts.Include(t => t.Brand);
            return View(tshirts.ToList());
        }

        // GET: Tshirts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tshirts tshirts = db.Tshirts.Find(id);
            if (tshirts == null)
            {
                return HttpNotFound();
            }
            return View(tshirts);
        }

        // GET: Tshirts/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name");
            return View();
        }

        // POST: Tshirts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TshirtName,Color,Price,Rating,BrandId")] Tshirts tshirts)
        {
            if (ModelState.IsValid)
            {
                db.Tshirts.Add(tshirts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", tshirts.BrandId);
            return View(tshirts);
        }

        // GET: Tshirts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tshirts tshirts = db.Tshirts.Find(id);
            if (tshirts == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", tshirts.BrandId);
            return View(tshirts);
        }

        // POST: Tshirts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TshirtName,Color,Price,Rating,BrandId")] Tshirts tshirts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tshirts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", tshirts.BrandId);
            return View(tshirts);
        }

        // GET: Tshirts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tshirts tshirts = db.Tshirts.Find(id);
            if (tshirts == null)
            {
                return HttpNotFound();
            }
            return View(tshirts);
        }

        // POST: Tshirts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tshirts tshirts = db.Tshirts.Find(id);
            db.Tshirts.Remove(tshirts);
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
