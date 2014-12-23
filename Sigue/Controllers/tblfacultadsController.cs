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
    public class tblfacultadsController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblfacultads
        public ActionResult Index()
        {
            return View(db.tblfacultads.ToList());
        }

        // GET: tblfacultads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblfacultad tblfacultad = db.tblfacultads.Find(id);
            if (tblfacultad == null)
            {
                return HttpNotFound();
            }
            return View(tblfacultad);
        }

        // GET: tblfacultads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblfacultads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacultadId,Facultad")] tblfacultad tblfacultad)
        {
            if (ModelState.IsValid)
            {
                db.tblfacultads.Add(tblfacultad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblfacultad);
        }

        // GET: tblfacultads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblfacultad tblfacultad = db.tblfacultads.Find(id);
            if (tblfacultad == null)
            {
                return HttpNotFound();
            }
            return View(tblfacultad);
        }

        // POST: tblfacultads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacultadId,Facultad")] tblfacultad tblfacultad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblfacultad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblfacultad);
        }

        // GET: tblfacultads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblfacultad tblfacultad = db.tblfacultads.Find(id);
            if (tblfacultad == null)
            {
                return HttpNotFound();
            }
            return View(tblfacultad);
        }

        // POST: tblfacultads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblfacultad tblfacultad = db.tblfacultads.Find(id);
            db.tblfacultads.Remove(tblfacultad);
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
