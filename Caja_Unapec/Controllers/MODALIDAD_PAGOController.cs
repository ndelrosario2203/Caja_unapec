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
    public class MODALIDAD_PAGOController : Controller
    {
        private Caja_UnapecEntities1 db = new Caja_UnapecEntities1();

        // GET: MODALIDAD_PAGO
        public ActionResult Index()
        {
            return View(db.MODALIDAD_PAGO.ToList());
        }

        // GET: MODALIDAD_PAGO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODALIDAD_PAGO mODALIDAD_PAGO = db.MODALIDAD_PAGO.Find(id);
            if (mODALIDAD_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(mODALIDAD_PAGO);
        }

        // GET: MODALIDAD_PAGO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MODALIDAD_PAGO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdModalidadPago,Nombre,Estado")] MODALIDAD_PAGO mODALIDAD_PAGO)
        {
            if (ModelState.IsValid)
            {
                db.MODALIDAD_PAGO.Add(mODALIDAD_PAGO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mODALIDAD_PAGO);
        }

        // GET: MODALIDAD_PAGO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODALIDAD_PAGO mODALIDAD_PAGO = db.MODALIDAD_PAGO.Find(id);
            if (mODALIDAD_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(mODALIDAD_PAGO);
        }

        // POST: MODALIDAD_PAGO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdModalidadPago,Nombre,Estado")] MODALIDAD_PAGO mODALIDAD_PAGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mODALIDAD_PAGO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mODALIDAD_PAGO);
        }

        // GET: MODALIDAD_PAGO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODALIDAD_PAGO mODALIDAD_PAGO = db.MODALIDAD_PAGO.Find(id);
            if (mODALIDAD_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(mODALIDAD_PAGO);
        }

        // POST: MODALIDAD_PAGO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MODALIDAD_PAGO mODALIDAD_PAGO = db.MODALIDAD_PAGO.Find(id);
            db.MODALIDAD_PAGO.Remove(mODALIDAD_PAGO);
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
