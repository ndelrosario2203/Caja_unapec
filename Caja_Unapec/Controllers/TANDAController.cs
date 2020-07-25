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
        private Caja_UnapecEntities1 db = new Caja_UnapecEntities1();

        // GET: TANDA
        [Authorize(Roles = "Administrador,Consulta")]
        public ActionResult Index()
        {
            return View(db.TANDAs.ToList());
        }

        // GET: TANDA/Details/5
        [Authorize(Roles = "Administrador,Consulta")]
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
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TANDA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
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
        [Authorize(Roles = "Administrador")]
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
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
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
        [Authorize(Roles = "Administrador")]
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
