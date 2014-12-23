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
    public class tblvacantesController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblvacantes
        public ActionResult Index()
        {
            var tblvacantes = db.tblvacantes.Include(t => t.tblcentropractica);
            return View(tblvacantes.ToList());
        }

        // GET: tblvacantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblvacante tblvacante = db.tblvacantes.Find(id);
            if (tblvacante == null)
            {
                return HttpNotFound();
            }
            return View(tblvacante);
        }

        // GET: tblvacantes/Create
        public ActionResult Create()
        {
            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre");
            return View();
        }

        // POST: tblvacantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VacanteId,CentroPracticaId,Cargo,Departamento,Salario,Ubicacion,ResumenCargo,Funciones,Requisitos,AntecedentesAcademicos,Experiencia,Habilidades,FechaPublicacion,FechaCierre")] tblvacante tblvacante)
        {
            if (ModelState.IsValid)
            {
                db.tblvacantes.Add(tblvacante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre", tblvacante.CentroPracticaId);
            return View(tblvacante);
        }

        // GET: tblvacantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblvacante tblvacante = db.tblvacantes.Find(id);
            if (tblvacante == null)
            {
                return HttpNotFound();
            }
            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre", tblvacante.CentroPracticaId);
            return View(tblvacante);
        }

        // POST: tblvacantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VacanteId,CentroPracticaId,Cargo,Departamento,Salario,Ubicacion,ResumenCargo,Funciones,Requisitos,AntecedentesAcademicos,Experiencia,Habilidades,FechaPublicacion,FechaCierre")] tblvacante tblvacante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblvacante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre", tblvacante.CentroPracticaId);
            return View(tblvacante);
        }

        // GET: tblvacantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblvacante tblvacante = db.tblvacantes.Find(id);
            if (tblvacante == null)
            {
                return HttpNotFound();
            }
            return View(tblvacante);
        }

        // POST: tblvacantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblvacante tblvacante = db.tblvacantes.Find(id);
            db.tblvacantes.Remove(tblvacante);
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
