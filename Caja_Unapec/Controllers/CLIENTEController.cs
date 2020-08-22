using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Caja_Unapec;

namespace Caja_Unapec.Controllers
{
    public class CLIENTEController : Controller
    {
        private Caja_UnapecEntities1 db = new Caja_UnapecEntities1();

        // GET: CLIENTE
        [Authorize(Roles = "Administrador,Consulta")]
        public ActionResult Index(string Criterio = null)
        {
            var cLIENTEs = db.CLIENTEs.Include(c => c.CARRERA).Include(c => c.TIPO_PERSONA);
            return View(db.CLIENTEs.Where(p => Criterio == null ||
            p.Nombre.Contains(Criterio)));
        }

        // GET: CLIENTE/Details/5
        [Authorize(Roles = "Administrador,Consulta")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTEs.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // GET: CLIENTE/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.IdCarrera = new SelectList(db.CARRERAs, "IdCarrera", "Nombre");
            ViewBag.IdTipoPersona = new SelectList(db.TIPO_PERSONA, "IdTipoPersona", "Nombre");
            return View();
        }

        // POST: CLIENTE/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCliente,Nombre,Estado,IdTipoPersona,IdCarrera")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.CLIENTEs.Add(cLIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCarrera = new SelectList(db.CARRERAs, "IdCarrera", "Nombre", cLIENTE.IdCarrera);
            ViewBag.IdTipoPersona = new SelectList(db.TIPO_PERSONA, "IdTipoPersona", "Nombre", cLIENTE.IdTipoPersona);
            return View(cLIENTE);
        }

        // GET: CLIENTE/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTEs.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCarrera = new SelectList(db.CARRERAs, "IdCarrera", "Nombre", cLIENTE.IdCarrera);
            ViewBag.IdTipoPersona = new SelectList(db.TIPO_PERSONA, "IdTipoPersona", "Nombre", cLIENTE.IdTipoPersona);
            return View(cLIENTE);
        }

        // POST: CLIENTE/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCliente,Nombre,Estado,IdTipoPersona,IdCarrera")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCarrera = new SelectList(db.CARRERAs, "IdCarrera", "Nombre", cLIENTE.IdCarrera);
            ViewBag.IdTipoPersona = new SelectList(db.TIPO_PERSONA, "IdTipoPersona", "Nombre", cLIENTE.IdTipoPersona);
            return View(cLIENTE);
        }

        // GET: CLIENTE/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTEs.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // POST: CLIENTE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIENTE cLIENTE = db.CLIENTEs.Find(id);
            db.CLIENTEs.Remove(cLIENTE);
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
        //Exportar a excel
        public ActionResult exportaExcel()
        {
           
            string filename = "prueba.csv";
            string filepath = @"C:\temp\" + filename;
            StreamWriter sw = new StreamWriter(filepath);
            sw.WriteLine("ID del cliente,Nombre del cliente,Estado"); //Encabezado 
            foreach (var i in db.CLIENTEs.ToList())
            {
                sw.WriteLine(i.IdCliente.ToString() + "," + i.Nombre.ToString() + "," + i.IdCarrera.ToString());
            }
            sw.Close();

            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = false,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
        }

    }
}
