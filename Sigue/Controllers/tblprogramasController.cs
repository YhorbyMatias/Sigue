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
    public class tblprogramasController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblprogramas
        public ActionResult Index()
        {
            var tblprogramas = db.tblprogramas.Include(t => t.tblfacultad);
            return View(tblprogramas.ToList());
        }

        // GET: tblprogramas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblprograma tblprograma = db.tblprogramas.Find(id);
            if (tblprograma == null)
            {
                return HttpNotFound();
            }
            return View(tblprograma);
        }

        // GET: tblprogramas/Create
        public ActionResult Create()
        {
            ViewBag.FacultadId = new SelectList(db.tblfacultads, "FacultadId", "Facultad");
            return View();
        }

        // POST: tblprogramas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgramaId,FacultadId,Programa")] tblprograma tblprograma)
        {
            if (ModelState.IsValid)
            {
                db.tblprogramas.Add(tblprograma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacultadId = new SelectList(db.tblfacultads, "FacultadId", "Facultad", tblprograma.FacultadId);
            return View(tblprograma);
        }

        // GET: tblprogramas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblprograma tblprograma = db.tblprogramas.Find(id);
            if (tblprograma == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultadId = new SelectList(db.tblfacultads, "FacultadId", "Facultad", tblprograma.FacultadId);
            return View(tblprograma);
        }

        // POST: tblprogramas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgramaId,FacultadId,Programa")] tblprograma tblprograma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblprograma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacultadId = new SelectList(db.tblfacultads, "FacultadId", "Facultad", tblprograma.FacultadId);
            return View(tblprograma);
        }

        // GET: tblprogramas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblprograma tblprograma = db.tblprogramas.Find(id);
            if (tblprograma == null)
            {
                return HttpNotFound();
            }
            return View(tblprograma);
        }

        // POST: tblprogramas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblprograma tblprograma = db.tblprogramas.Find(id);
            db.tblprogramas.Remove(tblprograma);
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
