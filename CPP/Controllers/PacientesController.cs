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
    public class PacientesController : Controller
    {
        private ModeloContexto db = new ModeloContexto();

        // GET: Pacientes
        public ActionResult Index()
        {
            var pacientes = db.Pacientes.Include(p => p.Departamentos).Include(p => p.EstadosCiviles).Include(p => p.Municipios).Include(p => p.OcupacionesPaciente).Include(p => p.Sexo).Include(p => p.TiposdeSangre);
            return View(pacientes.ToList());
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            ViewBag.idDepartamento = new SelectList(db.Departamentos, "departamentoId", "nombre");
            ViewBag.idEstadoCivil = new SelectList(db.EstadosCiviles, "estadoCivilId", "nombre");
            ViewBag.idMunicipio = new SelectList(db.Municipios, "municipioId", "nombre");
            ViewBag.idOcupacion = new SelectList(db.OcupacionesPaciente, "ocupacionId", "nombre");
            ViewBag.idSexo = new SelectList(db.Sexo, "sexoId", "nombre");
            ViewBag.idTipoSangre = new SelectList(db.TiposdeSangre, "tipoSangreId", "nombre");
            return View();
        }

        // POST: Pacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pacienteId,nombre,apellido,fechaNac,idSexo,cedula,idOcupacion,telefono,idEstadoCivil,idDepartamento,idMunicipio,idTipoSangre,domicilio,observaciones")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Pacientes.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDepartamento = new SelectList(db.Departamentos, "departamentoId", "nombre", paciente.idDepartamento);
            ViewBag.idEstadoCivil = new SelectList(db.EstadosCiviles, "estadoCivilId", "nombre", paciente.idEstadoCivil);
            ViewBag.idMunicipio = new SelectList(db.Municipios, "municipioId", "nombre", paciente.idMunicipio);
            ViewBag.idOcupacion = new SelectList(db.OcupacionesPaciente, "ocupacionId", "nombre", paciente.idOcupacion);
            ViewBag.idSexo = new SelectList(db.Sexo, "sexoId", "nombre", paciente.idSexo);
            ViewBag.idTipoSangre = new SelectList(db.TiposdeSangre, "tipoSangreId", "nombre", paciente.idTipoSangre);
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDepartamento = new SelectList(db.Departamentos, "departamentoId", "nombre", paciente.idDepartamento);
            ViewBag.idEstadoCivil = new SelectList(db.EstadosCiviles, "estadoCivilId", "nombre", paciente.idEstadoCivil);
            ViewBag.idMunicipio = new SelectList(db.Municipios, "municipioId", "nombre", paciente.idMunicipio);
            ViewBag.idOcupacion = new SelectList(db.OcupacionesPaciente, "ocupacionId", "nombre", paciente.idOcupacion);
            ViewBag.idSexo = new SelectList(db.Sexo, "sexoId", "nombre", paciente.idSexo);
            ViewBag.idTipoSangre = new SelectList(db.TiposdeSangre, "tipoSangreId", "nombre", paciente.idTipoSangre);
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pacienteId,nombre,apellido,fechaNac,idSexo,cedula,idOcupacion,telefono,idEstadoCivil,idDepartamento,idMunicipio,idTipoSangre,domicilio,observaciones")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDepartamento = new SelectList(db.Departamentos, "departamentoId", "nombre", paciente.idDepartamento);
            ViewBag.idEstadoCivil = new SelectList(db.EstadosCiviles, "estadoCivilId", "nombre", paciente.idEstadoCivil);
            ViewBag.idMunicipio = new SelectList(db.Municipios, "municipioId", "nombre", paciente.idMunicipio);
            ViewBag.idOcupacion = new SelectList(db.OcupacionesPaciente, "ocupacionId", "nombre", paciente.idOcupacion);
            ViewBag.idSexo = new SelectList(db.Sexo, "sexoId", "nombre", paciente.idSexo);
            ViewBag.idTipoSangre = new SelectList(db.TiposdeSangre, "tipoSangreId", "nombre", paciente.idTipoSangre);
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Pacientes.Find(id);
            db.Pacientes.Remove(paciente);
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
