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
    public class tblresponsablesController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblresponsables
        public ActionResult Index()
        {
            var tblresponsables = db.tblresponsables.Include(t => t.tblcentropractica);
            return View(tblresponsables.ToList());
        }

        // GET: tblresponsables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblresponsable tblresponsable = db.tblresponsables.Find(id);
            if (tblresponsable == null)
            {
                return HttpNotFound();
            }
            return View(tblresponsable);
        }

        // GET: tblresponsables/Create
        public ActionResult Create()
        {
            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre");
            return View();
        }

        // POST: tblresponsables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResponsableId,Nombres,Telefono,Email,CentroPracticaId")] tblresponsable tblresponsable)
        {
            if (ModelState.IsValid)
            {
                db.tblresponsables.Add(tblresponsable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre", tblresponsable.CentroPracticaId);
            return View(tblresponsable);
        }

        // GET: tblresponsables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblresponsable tblresponsable = db.tblresponsables.Find(id);
            if (tblresponsable == null)
            {
                return HttpNotFound();
            }
            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre", tblresponsable.CentroPracticaId);
            return View(tblresponsable);
        }

        // POST: tblresponsables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResponsableId,Nombres,Telefono,Email,CentroPracticaId")] tblresponsable tblresponsable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblresponsable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CentroPracticaId = new SelectList(db.tblcentropracticas, "CentroPracticaId", "Nombre", tblresponsable.CentroPracticaId);
            return View(tblresponsable);
        }

        // GET: tblresponsables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblresponsable tblresponsable = db.tblresponsables.Find(id);
            if (tblresponsable == null)
            {
                return HttpNotFound();
            }
            return View(tblresponsable);
        }

        // POST: tblresponsables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblresponsable tblresponsable = db.tblresponsables.Find(id);
            db.tblresponsables.Remove(tblresponsable);
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
