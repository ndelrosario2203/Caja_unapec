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
    public class FORMA_PAGOController : Controller
    {
        private Caja_UnapecEntities1 db = new Caja_UnapecEntities1();

        // GET: FORMA_PAGO
        public ActionResult Index()
        {
            var fORMA_PAGO = db.FORMA_PAGO.Include(f => f.MODALIDAD_PAGO);
            return View(fORMA_PAGO.ToList());
        }

        // GET: FORMA_PAGO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FORMA_PAGO fORMA_PAGO = db.FORMA_PAGO.Find(id);
            if (fORMA_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(fORMA_PAGO);
        }

        // GET: FORMA_PAGO/Create
        public ActionResult Create()
        {
            ViewBag.IdModalidadPago = new SelectList(db.MODALIDAD_PAGO, "IdModalidadPago", "Nombre");
            return View();
        }

        // POST: FORMA_PAGO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFormaPago,Descripcion,Estado,IdModalidadPago")] FORMA_PAGO fORMA_PAGO)
        {
            if (ModelState.IsValid)
            {
                db.FORMA_PAGO.Add(fORMA_PAGO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdModalidadPago = new SelectList(db.MODALIDAD_PAGO, "IdModalidadPago", "Nombre", fORMA_PAGO.IdModalidadPago);
            return View(fORMA_PAGO);
        }

        // GET: FORMA_PAGO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FORMA_PAGO fORMA_PAGO = db.FORMA_PAGO.Find(id);
            if (fORMA_PAGO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdModalidadPago = new SelectList(db.MODALIDAD_PAGO, "IdModalidadPago", "Nombre", fORMA_PAGO.IdModalidadPago);
            return View(fORMA_PAGO);
        }

        // POST: FORMA_PAGO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFormaPago,Descripcion,Estado,IdModalidadPago")] FORMA_PAGO fORMA_PAGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fORMA_PAGO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdModalidadPago = new SelectList(db.MODALIDAD_PAGO, "IdModalidadPago", "Nombre", fORMA_PAGO.IdModalidadPago);
            return View(fORMA_PAGO);
        }

        // GET: FORMA_PAGO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FORMA_PAGO fORMA_PAGO = db.FORMA_PAGO.Find(id);
            if (fORMA_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(fORMA_PAGO);
        }

        // POST: FORMA_PAGO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FORMA_PAGO fORMA_PAGO = db.FORMA_PAGO.Find(id);
            db.FORMA_PAGO.Remove(fORMA_PAGO);
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
