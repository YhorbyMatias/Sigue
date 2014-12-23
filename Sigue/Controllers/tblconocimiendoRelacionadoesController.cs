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
    public class tblconocimiendoRelacionadoesController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblconocimiendoRelacionadoes
        public ActionResult Index()
        {
            var tblconocimiendoRelacionadoes = db.tblconocimiendoRelacionadoes.Include(t => t.tblestudiante);
            return View(tblconocimiendoRelacionadoes.ToList());
        }

        // GET: tblconocimiendoRelacionadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblconocimiendoRelacionado tblconocimiendoRelacionado = db.tblconocimiendoRelacionadoes.Find(id);
            if (tblconocimiendoRelacionado == null)
            {
                return HttpNotFound();
            }
            return View(tblconocimiendoRelacionado);
        }

        // GET: tblconocimiendoRelacionadoes/Create
        public ActionResult Create()
        {
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod");
            return View();
        }

        // POST: tblconocimiendoRelacionadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConocimientoId,EstudianteId,Requerido,Disponible,Brecha,Acciones")] tblconocimiendoRelacionado tblconocimiendoRelacionado)
        {
            if (ModelState.IsValid)
            {
                db.tblconocimiendoRelacionadoes.Add(tblconocimiendoRelacionado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblconocimiendoRelacionado.EstudianteId);
            return View(tblconocimiendoRelacionado);
        }

        // GET: tblconocimiendoRelacionadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblconocimiendoRelacionado tblconocimiendoRelacionado = db.tblconocimiendoRelacionadoes.Find(id);
            if (tblconocimiendoRelacionado == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblconocimiendoRelacionado.EstudianteId);
            return View(tblconocimiendoRelacionado);
        }

        // POST: tblconocimiendoRelacionadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConocimientoId,EstudianteId,Requerido,Disponible,Brecha,Acciones")] tblconocimiendoRelacionado tblconocimiendoRelacionado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblconocimiendoRelacionado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstudianteId = new SelectList(db.tblestudiantes, "EstudianteId", "EstudianteCod", tblconocimiendoRelacionado.EstudianteId);
            return View(tblconocimiendoRelacionado);
        }

        // GET: tblconocimiendoRelacionadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblconocimiendoRelacionado tblconocimiendoRelacionado = db.tblconocimiendoRelacionadoes.Find(id);
            if (tblconocimiendoRelacionado == null)
            {
                return HttpNotFound();
            }
            return View(tblconocimiendoRelacionado);
        }

        // POST: tblconocimiendoRelacionadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblconocimiendoRelacionado tblconocimiendoRelacionado = db.tblconocimiendoRelacionadoes.Find(id);
            db.tblconocimiendoRelacionadoes.Remove(tblconocimiendoRelacionado);
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
