using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CPP.Contexto;
using CPP.Models;

namespace CPP.Controllers
{
    public class FacturasController : Controller
    {
        private ModeloContexto db = new ModeloContexto();

        // GET: Facturas
        public ActionResult Index()
        {
            var facturas = db.Facturas.Include(f => f.Medicos).Include(f => f.Pacientes).Include(f => f.Servicios);
            return View(facturas.ToList());
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            ViewBag.medicoId = new SelectList(db.Medicos, "medicoId", "nombre");
            ViewBag.pacienteId = new SelectList(db.Pacientes, "pacienteId", "nombre");
            ViewBag.servicioId = new SelectList(db.Servicios, "servicioId", "servicioId");
            return View();
        }

        // POST: Facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "facturaId,pacienteId,medicoId,servicioId,descripcion,total")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Facturas.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.medicoId = new SelectList(db.Medicos, "medicoId", "nombre", factura.medicoId);
            ViewBag.pacienteId = new SelectList(db.Pacientes, "pacienteId", "nombre", factura.pacienteId);
            ViewBag.servicioId = new SelectList(db.Servicios, "servicioId", "servicioId", factura.servicioId);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.medicoId = new SelectList(db.Medicos, "medicoId", "nombre", factura.medicoId);
            ViewBag.pacienteId = new SelectList(db.Pacientes, "pacienteId", "nombre", factura.pacienteId);
            ViewBag.servicioId = new SelectList(db.Servicios, "servicioId", "servicioId", factura.servicioId);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "facturaId,pacienteId,medicoId,servicioId,descripcion,total")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.medicoId = new SelectList(db.Medicos, "medicoId", "nombre", factura.medicoId);
            ViewBag.pacienteId = new SelectList(db.Pacientes, "pacienteId", "nombre", factura.pacienteId);
            ViewBag.servicioId = new SelectList(db.Servicios, "servicioId", "servicioId", factura.servicioId);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Facturas.Find(id);
            db.Facturas.Remove(factura);
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
