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
    public class EMPLEADOController : Controller
    {
        private Caja_UnapecEntities1 db = new Caja_UnapecEntities1();

        // GET: EMPLEADO
        public ActionResult Index(string Criterio = null)
        {
            return View(db.EMPLEADOes.Where(p => Criterio == null || 
            p.Nombre.Contains(Criterio) ||
            p.Cedula.Contains(Criterio)));
        }

        // GET: EMPLEADO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADOes.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // GET: EMPLEADO/Create
        public ActionResult Create()
        {
            ViewBag.IdTanda = new SelectList(db.TANDAs, "IdTanda", "Nombre");
            return View();
        }

        // POST: EMPLEADO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpleado,Nombre,Cedula,Fecha_Ingreso,Estado,IdTanda")] EMPLEADO eMPLEADO)
        {
            if (!validaCedula(eMPLEADO.Cedula)) {
                    ModelState.AddModelError("Cedula", "Cédula inválida.");
            }
            if (ModelState.IsValid)
            {
                db.EMPLEADOes.Add(eMPLEADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTanda = new SelectList(db.TANDAs, "IdTanda", "Nombre", eMPLEADO.IdTanda);
            return View(eMPLEADO);
        }

        // GET: EMPLEADO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADOes.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTanda = new SelectList(db.TANDAs, "IdTanda", "Nombre", eMPLEADO.IdTanda);
            return View(eMPLEADO);
        }

        // POST: EMPLEADO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpleado,Nombre,Cedula,Fecha_Ingreso,Estado,IdTanda")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLEADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTanda = new SelectList(db.TANDAs, "IdTanda", "Nombre", eMPLEADO.IdTanda);
            return View(eMPLEADO);
        }

        // GET: EMPLEADO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADOes.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // POST: EMPLEADO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLEADO eMPLEADO = db.EMPLEADOes.Find(id);
            db.EMPLEADOes.Remove(eMPLEADO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public static bool validaCedula(string pCedula)
        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return true;
            else
                return false;
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
