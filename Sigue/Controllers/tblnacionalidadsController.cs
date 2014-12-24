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
    public class tblnacionalidadsController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblnacionalidads
        public ActionResult Index()
        {
            return View(db.tblnacionalidads.ToList());
        }

        // GET: tblnacionalidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblnacionalidad tblnacionalidad = db.tblnacionalidads.Find(id);
            if (tblnacionalidad == null)
            {
                return HttpNotFound();
            }
            return View(tblnacionalidad);
        }

        // GET: tblnacionalidads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblnacionalidads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NacionalidaId,Nacionalidad")] tblnacionalidad tblnacionalidad)
        {
            if (ModelState.IsValid)
            {
                db.tblnacionalidads.Add(tblnacionalidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblnacionalidad);
        }

        // GET: tblnacionalidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblnacionalidad tblnacionalidad = db.tblnacionalidads.Find(id);
            if (tblnacionalidad == null)
            {
                return HttpNotFound();
            }
            return View(tblnacionalidad);
        }

        // POST: tblnacionalidads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NacionalidaId,Nacionalidad")] tblnacionalidad tblnacionalidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblnacionalidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblnacionalidad);
        }

        // GET: tblnacionalidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblnacionalidad tblnacionalidad = db.tblnacionalidads.Find(id);
            if (tblnacionalidad == null)
            {
                return HttpNotFound();
            }
            return View(tblnacionalidad);
        }

        // POST: tblnacionalidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblnacionalidad tblnacionalidad = db.tblnacionalidads.Find(id);
            db.tblnacionalidads.Remove(tblnacionalidad);
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
