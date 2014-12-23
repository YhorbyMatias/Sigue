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
    public class tblEstudianteEstudiosController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblEstudianteEstudios
        public ActionResult Index()
        {
            var tblEstudianteEstudios = db.tblEstudianteEstudios.Include(t => t.tblestudiante);
            return View(tblEstudianteEstudios.ToList());
        }

        // GET: tblEstudianteEstudios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEstudianteEstudio tblEstudianteEstudio = db.tblEstudianteEstudios.Find(id);
            if (tblEstudianteEstudio == null)
            {
                return HttpNotFound();
            }
            return View(tblEstudianteEstudio);
        }

        // GET: tblEstudianteEstudios/Create
        public ActionResult Create()
        {
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod");
            return View();
        }

        // POST: tblEstudianteEstudios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstudiosId,EstudianteId,Institucion,Titulo")] tblEstudianteEstudio tblEstudianteEstudio)
        {
            if (ModelState.IsValid)
            {
                db.tblEstudianteEstudios.Add(tblEstudianteEstudio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblEstudianteEstudio.EstudianteId);
            return View(tblEstudianteEstudio);
        }

        // GET: tblEstudianteEstudios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEstudianteEstudio tblEstudianteEstudio = db.tblEstudianteEstudios.Find(id);
            if (tblEstudianteEstudio == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblEstudianteEstudio.EstudianteId);
            return View(tblEstudianteEstudio);
        }

        // POST: tblEstudianteEstudios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstudiosId,EstudianteId,Institucion,Titulo")] tblEstudianteEstudio tblEstudianteEstudio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEstudianteEstudio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblEstudianteEstudio.EstudianteId);
            return View(tblEstudianteEstudio);
        }

        // GET: tblEstudianteEstudios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEstudianteEstudio tblEstudianteEstudio = db.tblEstudianteEstudios.Find(id);
            if (tblEstudianteEstudio == null)
            {
                return HttpNotFound();
            }
            return View(tblEstudianteEstudio);
        }

        // POST: tblEstudianteEstudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEstudianteEstudio tblEstudianteEstudio = db.tblEstudianteEstudios.Find(id);
            db.tblEstudianteEstudios.Remove(tblEstudianteEstudio);
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
