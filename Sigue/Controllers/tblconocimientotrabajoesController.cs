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
    public class tblconocimientotrabajoesController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblconocimientotrabajoes
        public ActionResult Index()
        {
            var tblconocimientotrabajoes = db.tblconocimientotrabajoes.Include(t => t.tblestudiante);
            return View(tblconocimientotrabajoes.ToList());
        }

        // GET: tblconocimientotrabajoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblconocimientotrabajo tblconocimientotrabajo = db.tblconocimientotrabajoes.Find(id);
            if (tblconocimientotrabajo == null)
            {
                return HttpNotFound();
            }
            return View(tblconocimientotrabajo);
        }

        // GET: tblconocimientotrabajoes/Create
        public ActionResult Create()
        {
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod");
            return View();
        }

        // POST: tblconocimientotrabajoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrabajoId,EstudianteId,Gerencia,Organizacional,Relacional,Tic")] tblconocimientotrabajo tblconocimientotrabajo)
        {
            if (ModelState.IsValid)
            {
                db.tblconocimientotrabajoes.Add(tblconocimientotrabajo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblconocimientotrabajo.EstudianteId);
            return View(tblconocimientotrabajo);
        }

        // GET: tblconocimientotrabajoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblconocimientotrabajo tblconocimientotrabajo = db.tblconocimientotrabajoes.Find(id);
            if (tblconocimientotrabajo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblconocimientotrabajo.EstudianteId);
            return View(tblconocimientotrabajo);
        }

        // POST: tblconocimientotrabajoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrabajoId,EstudianteId,Gerencia,Organizacional,Relacional,Tic")] tblconocimientotrabajo tblconocimientotrabajo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblconocimientotrabajo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblconocimientotrabajo.EstudianteId);
            return View(tblconocimientotrabajo);
        }

        // GET: tblconocimientotrabajoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblconocimientotrabajo tblconocimientotrabajo = db.tblconocimientotrabajoes.Find(id);
            if (tblconocimientotrabajo == null)
            {
                return HttpNotFound();
            }
            return View(tblconocimientotrabajo);
        }

        // POST: tblconocimientotrabajoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblconocimientotrabajo tblconocimientotrabajo = db.tblconocimientotrabajoes.Find(id);
            db.tblconocimientotrabajoes.Remove(tblconocimientotrabajo);
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
