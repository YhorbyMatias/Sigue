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
    public class tblestudianteotrosconocimientoesController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblestudianteotrosconocimientoes
        public ActionResult Index()
        {
            var tblestudianteotrosconocimientoes = db.tblestudianteotrosconocimientoes.Include(t => t.tblestudiante);
            return View(tblestudianteotrosconocimientoes.ToList());
        }

        // GET: tblestudianteotrosconocimientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblestudianteotrosconocimiento tblestudianteotrosconocimiento = db.tblestudianteotrosconocimientoes.Find(id);
            if (tblestudianteotrosconocimiento == null)
            {
                return HttpNotFound();
            }
            return View(tblestudianteotrosconocimiento);
        }

        // GET: tblestudianteotrosconocimientoes/Create
        public ActionResult Create()
        {
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod");
            return View();
        }

        // POST: tblestudianteotrosconocimientoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConocimientoId,EstudianteId,ProyectoPresente,ProyectoFuturo,ProyectoPasado")] tblestudianteotrosconocimiento tblestudianteotrosconocimiento)
        {
            if (ModelState.IsValid)
            {
                db.tblestudianteotrosconocimientoes.Add(tblestudianteotrosconocimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblestudianteotrosconocimiento.EstudianteId);
            return View(tblestudianteotrosconocimiento);
        }

        // GET: tblestudianteotrosconocimientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblestudianteotrosconocimiento tblestudianteotrosconocimiento = db.tblestudianteotrosconocimientoes.Find(id);
            if (tblestudianteotrosconocimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblestudianteotrosconocimiento.EstudianteId);
            return View(tblestudianteotrosconocimiento);
        }

        // POST: tblestudianteotrosconocimientoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConocimientoId,EstudianteId,ProyectoPresente,ProyectoFuturo,ProyectoPasado")] tblestudianteotrosconocimiento tblestudianteotrosconocimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblestudianteotrosconocimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblestudianteotrosconocimiento.EstudianteId);
            return View(tblestudianteotrosconocimiento);
        }

        // GET: tblestudianteotrosconocimientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblestudianteotrosconocimiento tblestudianteotrosconocimiento = db.tblestudianteotrosconocimientoes.Find(id);
            if (tblestudianteotrosconocimiento == null)
            {
                return HttpNotFound();
            }
            return View(tblestudianteotrosconocimiento);
        }

        // POST: tblestudianteotrosconocimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblestudianteotrosconocimiento tblestudianteotrosconocimiento = db.tblestudianteotrosconocimientoes.Find(id);
            db.tblestudianteotrosconocimientoes.Remove(tblestudianteotrosconocimiento);
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
