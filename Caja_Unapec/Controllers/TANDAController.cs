using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Caja_Unapec;

namespace Caja_Unapec.Controllers
{
    public class TANDAController : Controller
    {
        private Caja_UnapecEntities db = new Caja_UnapecEntities();

        // GET: TANDA
        public ActionResult Index()
        {
            return View(db.TANDAs.ToList());
        }

        // GET: TANDA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TANDA tANDA = db.TANDAs.Find(id);
            if (tANDA == null)
            {
                return HttpNotFound();
            }
            return View(tANDA);
        }

        // GET: TANDA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TANDA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTanda,Nombre,Estado")] TANDA tANDA)
        {
            if (ModelState.IsValid)
            {
                db.TANDAs.Add(tANDA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tANDA);
        }

        // GET: TANDA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TANDA tANDA = db.TANDAs.Find(id);
            if (tANDA == null)
            {
                return HttpNotFound();
            }
            return View(tANDA);
        }

        // POST: TANDA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTanda,Nombre,Estado")] TANDA tANDA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tANDA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tANDA);
        }

        // GET: TANDA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TANDA tANDA = db.TANDAs.Find(id);
            if (tANDA == null)
            {
                return HttpNotFound();
            }
            return View(tANDA);
        }

        // POST: TANDA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TANDA tANDA = db.TANDAs.Find(id);
            db.TANDAs.Remove(tANDA);
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
