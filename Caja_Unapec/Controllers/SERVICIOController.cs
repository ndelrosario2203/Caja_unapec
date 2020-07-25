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
    public class SERVICIOController : Controller
    {
        private Caja_UnapecEntities1 db = new Caja_UnapecEntities1();

        // GET: SERVICIO
        [Authorize(Roles = "Administrador,Consulta")]
        public ActionResult Index()
        {
            return View(db.SERVICIOs.ToList());
        }

        // GET: SERVICIO/Details/5
        [Authorize(Roles = "Administrador,Consulta")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIOs.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(sERVICIO);
        }

        // GET: SERVICIO/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SERVICIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdServicio,Descripcion,Estado")] SERVICIO sERVICIO)
        {
            if (ModelState.IsValid)
            {
                db.SERVICIOs.Add(sERVICIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sERVICIO);
        }

        // GET: SERVICIO/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIOs.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(sERVICIO);
        }

        // POST: SERVICIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdServicio,Descripcion,Estado")] SERVICIO sERVICIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sERVICIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sERVICIO);
        }

        // GET: SERVICIO/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICIO sERVICIO = db.SERVICIOs.Find(id);
            if (sERVICIO == null)
            {
                return HttpNotFound();
            }
            return View(sERVICIO);
        }

        // POST: SERVICIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SERVICIO sERVICIO = db.SERVICIOs.Find(id);
            db.SERVICIOs.Remove(sERVICIO);
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
