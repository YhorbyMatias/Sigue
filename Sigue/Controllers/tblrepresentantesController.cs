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
    public class tblrepresentantesController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblrepresentantes
        public ActionResult Index()
        {
            var tblrepresentantes = db.tblrepresentantes.Include(t => t.tblcentropractica);
            return View(tblrepresentantes.ToList());
        }

        // GET: tblrepresentantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblrepresentante tblrepresentante = db.tblrepresentantes.Find(id);
            if (tblrepresentante == null)
            {
                return HttpNotFound();
            }
            return View(tblrepresentante);
        }

        // GET: tblrepresentantes/Create
        public ActionResult Create()
        {
            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre");
            return View();
        }

        // POST: tblrepresentantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RepresentanteId,Nombres,Email,Cargo,Cedula,CentroPracticaId")] tblrepresentante tblrepresentante)
        {
            if (ModelState.IsValid)
            {
                db.tblrepresentantes.Add(tblrepresentante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre", tblrepresentante.CentroPracticaId);
            return View(tblrepresentante);
        }

        // GET: tblrepresentantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblrepresentante tblrepresentante = db.tblrepresentantes.Find(id);
            if (tblrepresentante == null)
            {
                return HttpNotFound();
            }
            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre", tblrepresentante.CentroPracticaId);
            return View(tblrepresentante);
        }

        // POST: tblrepresentantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RepresentanteId,Nombres,Email,Cargo,Cedula,CentroPracticaId")] tblrepresentante tblrepresentante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblrepresentante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre", tblrepresentante.CentroPracticaId);
            return View(tblrepresentante);
        }

        // GET: tblrepresentantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblrepresentante tblrepresentante = db.tblrepresentantes.Find(id);
            if (tblrepresentante == null)
            {
                return HttpNotFound();
            }
            return View(tblrepresentante);
        }

        // POST: tblrepresentantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblrepresentante tblrepresentante = db.tblrepresentantes.Find(id);
            db.tblrepresentantes.Remove(tblrepresentante);
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
