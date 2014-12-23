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
    public class tblAsesor_estudianteController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblAsesor_estudiante
        public ActionResult Index()
        {
            var tblAsesor_estudiante = db.tblAsesor_estudiante.Include(t => t.tblasesor).Include(t => t.tblestudiante);
            return View(tblAsesor_estudiante.ToList());
        }

        // GET: tblAsesor_estudiante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAsesor_estudiante tblAsesor_estudiante = db.tblAsesor_estudiante.Find(id);
            if (tblAsesor_estudiante == null)
            {
                return HttpNotFound();
            }
            return View(tblAsesor_estudiante);
        }

        // GET: tblAsesor_estudiante/Create
        public ActionResult Create()
        {
            ViewBag.AsesorId = new SelectList(db.tblasesors, "AsesorId", "Nombres");
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod");
            return View();
        }

        // POST: tblAsesor_estudiante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RelacionAEId,EstudianteId,AsesorId,Fecha,Observacion")] tblAsesor_estudiante tblAsesor_estudiante)
        {
            if (ModelState.IsValid)
            {
                db.tblAsesor_estudiante.Add(tblAsesor_estudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AsesorId = new SelectList(db.tblasesors, "AsesorId", "Nombres", tblAsesor_estudiante.AsesorId);
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblAsesor_estudiante.EstudianteId);
            return View(tblAsesor_estudiante);
        }

        // GET: tblAsesor_estudiante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAsesor_estudiante tblAsesor_estudiante = db.tblAsesor_estudiante.Find(id);
            if (tblAsesor_estudiante == null)
            {
                return HttpNotFound();
            }
            ViewBag.AsesorId = new SelectList(db.tblasesors, "AsesorId", "Nombres", tblAsesor_estudiante.AsesorId);
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblAsesor_estudiante.EstudianteId);
            return View(tblAsesor_estudiante);
        }

        // POST: tblAsesor_estudiante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RelacionAEId,EstudianteId,AsesorId,Fecha,Observacion")] tblAsesor_estudiante tblAsesor_estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAsesor_estudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AsesorId = new SelectList(db.tblasesors, "AsesorId", "Nombres", tblAsesor_estudiante.AsesorId);
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblAsesor_estudiante.EstudianteId);
            return View(tblAsesor_estudiante);
        }

        // GET: tblAsesor_estudiante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAsesor_estudiante tblAsesor_estudiante = db.tblAsesor_estudiante.Find(id);
            if (tblAsesor_estudiante == null)
            {
                return HttpNotFound();
            }
            return View(tblAsesor_estudiante);
        }

        // POST: tblAsesor_estudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAsesor_estudiante tblAsesor_estudiante = db.tblAsesor_estudiante.Find(id);
            db.tblAsesor_estudiante.Remove(tblAsesor_estudiante);
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
