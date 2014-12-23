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
    public class tblcentropracticasController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblcentropracticas
        public ActionResult Index()
        {
            return View(db.tblcentropracticas.ToList());
        }

        // GET: tblcentropracticas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblcentropractica tblcentropractica = db.tblcentropracticas.Find(id);
            if (tblcentropractica == null)
            {
                return HttpNotFound();
            }
            return View(tblcentropractica);
        }

        // GET: tblcentropracticas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblcentropracticas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CentroPracticaId,Nombre,RazonSocial,Nit,Direccion,Ciudad,Telefono,Actividad")] tblcentropractica tblcentropractica)
        {
            if (ModelState.IsValid)
            {
                db.tblcentropracticas.Add(tblcentropractica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblcentropractica);
        }

        // GET: tblcentropracticas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblcentropractica tblcentropractica = db.tblcentropracticas.Find(id);
            if (tblcentropractica == null)
            {
                return HttpNotFound();
            }
            return View(tblcentropractica);
        }

        // POST: tblcentropracticas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CentroPracticaId,Nombre,RazonSocial,Nit,Direccion,Ciudad,Telefono,Actividad")] tblcentropractica tblcentropractica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblcentropractica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblcentropractica);
        }

        // GET: tblcentropracticas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblcentropractica tblcentropractica = db.tblcentropracticas.Find(id);
            if (tblcentropractica == null)
            {
                return HttpNotFound();
            }
            return View(tblcentropractica);
        }

        // POST: tblcentropracticas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblcentropractica tblcentropractica = db.tblcentropracticas.Find(id);
            db.tblcentropracticas.Remove(tblcentropractica);
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
