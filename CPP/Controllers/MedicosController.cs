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
using PagedList;

namespace CPP.Controllers
{
    public class MedicosController : Controller
    {
        private ModeloContexto db = new ModeloContexto();

        // GET: Medicos
        public ActionResult Index(String sort, string search, int? page)
        {
            ViewBag.MedicoSort = String.IsNullOrEmpty(sort) ? "medicoId_desc" : string.Empty;
            ViewBag.NombreSort = sort == "Nombre" ? "Nombre_desc" : "Nombre";
            ViewBag.ApellidosSort = sort == "Apellidos" ? "Apellidos_desc" : "Apellidos";
            ViewBag.EspecialidadSort = sort == "Especialidad" ? "Especialidad_desc" : "Especialidad";
            ViewBag.CodigoMinsaSort = sort == "CodigoMinsa" ? "CodigoMinsa_desc" : "CodigoMinsa";
            
            ViewBag.CurrentSort = sort;
            ViewBag.CurrentSearch = search;

            IQueryable<Medico> medico = db.Medicos;

            if (!string.IsNullOrEmpty(search))
            {
                medico = medico.Where(m => m.nombre.Contains(search) || m.apellido.Contains(search) || m.especialidad.Contains(search) || m.codigoMinsa.Contains(search));
            }

            switch (sort)
            {
                case "medicoId_desc":
                    medico = medico.OrderByDescending(m => m.medicoId);
                    break;
                case "Nombre":
                    medico = medico.OrderBy(m => m.nombre);
                    break;

                case "Nombre_desc":
                    medico = medico.OrderByDescending(m => m.nombre);
                    break;

                case "Apellido":
                    medico = medico.OrderBy(m => m.apellido);
                    break;

                case "Apellido_desc":
                    medico = medico.OrderByDescending(m => m.apellido);
                    break;

                case "Especialidad":
                    medico = medico.OrderBy(m => m.especialidad);
                    break;

                case "Especialidad_desc":
                    medico = medico.OrderByDescending(m => m.especialidad);
                    break;

                case "CodigoMinsa":
                    medico = medico.OrderBy(m => m.codigoMinsa);
                    break;

                case "CodigoMinsa_desc":
                    medico = medico.OrderByDescending(m => m.codigoMinsa);
                    break;

                default:
                    medico = medico.OrderBy(c => c.nombre);
                    break;

            }

            int pageSize = 10;
            int pageNumber = page ?? 1;

            return View(medico.ToPagedList(pageNumber, pageSize));
            

            var medicos = db.Medicos.Include(f => f.medicoId );
            return View(db.Medicos.ToList());
        }

        // GET: Medicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: Medicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "medicoId,nombre,apellido,especialidad,codigoMinsa")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medico);
        }

        // GET: Medicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "medicoId,nombre,apellido,especialidad,codigoMinsa")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medico);
        }

        // GET: Medicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = db.Medicos.Find(id);
            db.Medicos.Remove(medico);
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
