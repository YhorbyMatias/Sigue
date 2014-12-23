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
    public class tblasesorsController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblasesors
        public ActionResult Index()
        {
            var tblasesors = db.tblasesors.Include(t => t.tblfacultad);
            return View(tblasesors.ToList());
        }

        // GET: tblasesors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblasesor tblasesor = db.tblasesors.Find(id);
            if (tblasesor == null)
            {
                return HttpNotFound();
            }
            return View(tblasesor);
        }

        // GET: tblasesors/Create
        public ActionResult Create()
        {
            ViewBag.FacultadId = new SelectList(db.tblfacultads, "FacultadId", "Facultad");
            return View();
        }

        // POST: tblasesors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsesorId,Nombres,Apellidos,Email,FacultadId,Imagen,Descripcion")] tblasesor tblasesor)
        {
            if (ModelState.IsValid)
            {
                db.tblasesors.Add(tblasesor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacultadId = new SelectList(db.tblfacultads, "FacultadId", "Facultad", tblasesor.FacultadId);
            return View(tblasesor);
        }

        // GET: tblasesors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblasesor tblasesor = db.tblasesors.Find(id);
            if (tblasesor == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultadId = new SelectList(db.tblfacultads, "FacultadId", "Facultad", tblasesor.FacultadId);
            return View(tblasesor);
        }

        // POST: tblasesors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AsesorId,Nombres,Apellidos,Email,FacultadId,Imagen,Descripcion")] tblasesor tblasesor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblasesor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacultadId = new SelectList(db.tblfacultads, "FacultadId", "Facultad", tblasesor.FacultadId);
            return View(tblasesor);
        }

        // GET: tblasesors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblasesor tblasesor = db.tblasesors.Find(id);
            if (tblasesor == null)
            {
                return HttpNotFound();
            }
            return View(tblasesor);
        }

        // POST: tblasesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblasesor tblasesor = db.tblasesors.Find(id);
            db.tblasesors.Remove(tblasesor);
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
