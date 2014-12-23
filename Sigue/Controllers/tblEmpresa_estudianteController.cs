using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sigue.Models;

namespace Sigue.Controllers
{
    public class tblEmpresa_estudianteController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblEmpresa_estudiante
        public ActionResult Index()
        {
            var tblEmpresa_estudiante = db.tblEmpresa_estudiante.Include(t => t.tblcentropractica).Include(t => t.tblestudiante);
            return View(tblEmpresa_estudiante.ToList());
        }

        // GET: tblEmpresa_estudiante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpresa_estudiante tblEmpresa_estudiante = db.tblEmpresa_estudiante.Find(id);
            if (tblEmpresa_estudiante == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpresa_estudiante);
        }

        // GET: tblEmpresa_estudiante/Create
        public ActionResult Create()
        {
            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre");
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod");
            return View();
        }

        // POST: tblEmpresa_estudiante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RelacionEEId,EstudianteId,CentroPracticaId,Fecha,Observacion")] tblEmpresa_estudiante tblEmpresa_estudiante)
        {
            if (ModelState.IsValid)
            {
                db.tblEmpresa_estudiante.Add(tblEmpresa_estudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre", tblEmpresa_estudiante.CentroPracticaId);
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblEmpresa_estudiante.EstudianteId);
            return View(tblEmpresa_estudiante);
        }

        // GET: tblEmpresa_estudiante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpresa_estudiante tblEmpresa_estudiante = db.tblEmpresa_estudiante.Find(id);
            if (tblEmpresa_estudiante == null)
            {
                return HttpNotFound();
            }
            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre", tblEmpresa_estudiante.CentroPracticaId);
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblEmpresa_estudiante.EstudianteId);
            return View(tblEmpresa_estudiante);
        }

        // POST: tblEmpresa_estudiante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RelacionEEId,EstudianteId,CentroPracticaId,Fecha,Observacion")] tblEmpresa_estudiante tblEmpresa_estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmpresa_estudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre", tblEmpresa_estudiante.CentroPracticaId);
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblEmpresa_estudiante.EstudianteId);
            return View(tblEmpresa_estudiante);
        }

        // GET: tblEmpresa_estudiante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpresa_estudiante tblEmpresa_estudiante = db.tblEmpresa_estudiante.Find(id);
            if (tblEmpresa_estudiante == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpresa_estudiante);
        }

        // POST: tblEmpresa_estudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmpresa_estudiante tblEmpresa_estudiante = db.tblEmpresa_estudiante.Find(id);
            db.tblEmpresa_estudiante.Remove(tblEmpresa_estudiante);
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
