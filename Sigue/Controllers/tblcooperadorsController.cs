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
    public class tblcooperadorsController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblcooperadors
        public ActionResult Index()
        {
            var tblcooperadors = db.tblcooperadors.Include(t => t.tblcentropractica);
            return View(tblcooperadors.ToList());
        }

        // GET: tblcooperadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblcooperador tblcooperador = db.tblcooperadors.Find(id);
            if (tblcooperador == null)
            {
                return HttpNotFound();
            }
            return View(tblcooperador);
        }

        // GET: tblcooperadors/Create
        public ActionResult Create()
        {
            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre");
            return View();
        }

        // POST: tblcooperadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CooperadorId,Nombres,Telefono,Email,FuncionesPracticas,CentroPracticaId")] tblcooperador tblcooperador)
        {
            if (ModelState.IsValid)
            {
                db.tblcooperadors.Add(tblcooperador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre", tblcooperador.CentroPracticaId);
            return View(tblcooperador);
        }

        // GET: tblcooperadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblcooperador tblcooperador = db.tblcooperadors.Find(id);
            if (tblcooperador == null)
            {
                return HttpNotFound();
            }
            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre", tblcooperador.CentroPracticaId);
            return View(tblcooperador);
        }

        // POST: tblcooperadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CooperadorId,Nombres,Telefono,Email,FuncionesPracticas,CentroPracticaId")] tblcooperador tblcooperador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblcooperador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre", tblcooperador.CentroPracticaId);
            return View(tblcooperador);
        }

        // GET: tblcooperadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblcooperador tblcooperador = db.tblcooperadors.Find(id);
            if (tblcooperador == null)
            {
                return HttpNotFound();
            }
            return View(tblcooperador);
        }

        // POST: tblcooperadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblcooperador tblcooperador = db.tblcooperadors.Find(id);
            db.tblcooperadors.Remove(tblcooperador);
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
