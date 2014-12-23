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
    public class tblautoaprendizajesController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblautoaprendizajes
        public ActionResult Index()
        {
            var tblautoaprendizajes = db.tblautoaprendizajes.Include(t => t.tblestudiante);
            return View(tblautoaprendizajes.ToList());
        }

        // GET: tblautoaprendizajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblautoaprendizaje tblautoaprendizaje = db.tblautoaprendizajes.Find(id);
            if (tblautoaprendizaje == null)
            {
                return HttpNotFound();
            }
            return View(tblautoaprendizaje);
        }

        // GET: tblautoaprendizajes/Create
        public ActionResult Create()
        {
            ViewBag.Estudianteid = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod");
            return View();
        }

        // POST: tblautoaprendizajes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AutoaprendizajeId,Estudianteid,Institucion,Titulo")] tblautoaprendizaje tblautoaprendizaje)
        {
            if (ModelState.IsValid)
            {
                db.tblautoaprendizajes.Add(tblautoaprendizaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estudianteid = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblautoaprendizaje.Estudianteid);
            return View(tblautoaprendizaje);
        }

        // GET: tblautoaprendizajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblautoaprendizaje tblautoaprendizaje = db.tblautoaprendizajes.Find(id);
            if (tblautoaprendizaje == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estudianteid = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblautoaprendizaje.Estudianteid);
            return View(tblautoaprendizaje);
        }

        // POST: tblautoaprendizajes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AutoaprendizajeId,Estudianteid,Institucion,Titulo")] tblautoaprendizaje tblautoaprendizaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblautoaprendizaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estudianteid = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblautoaprendizaje.Estudianteid);
            return View(tblautoaprendizaje);
        }

        // GET: tblautoaprendizajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblautoaprendizaje tblautoaprendizaje = db.tblautoaprendizajes.Find(id);
            if (tblautoaprendizaje == null)
            {
                return HttpNotFound();
            }
            return View(tblautoaprendizaje);
        }

        // POST: tblautoaprendizajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblautoaprendizaje tblautoaprendizaje = db.tblautoaprendizajes.Find(id);
            db.tblautoaprendizajes.Remove(tblautoaprendizaje);
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
