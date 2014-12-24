using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sigue.Models;
using System.Web.Security;

namespace Sigue.Controllers
{
    public class tblestudiantesController : Controller
    {
        private sigue_dbEntities1 db = new sigue_dbEntities1();

        // GET: tblestudiantes
        public ActionResult Index()
        {
            var tblestudiantes = db.tblestudiantes.Include(t => t.tblnacionalidad).Include(t => t.tblfacultad);
            return View(tblestudiantes.ToList());
        }

        // GET: tblestudiantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblestudiante tblestudiante = db.tblestudiantes.Find(id);
            if (tblestudiante == null)
            {
                return HttpNotFound();
            }
            return View(tblestudiante);
        }

        // GET: tblestudiantes/Create
        public ActionResult Create()
        {
            ViewBag.NacionalidadId = new SelectList(db.tblnacionalidads, "NacionalidaId", "Nacionalidad");
            ViewBag.FacultadId = new SelectList(db.tblfacultads, "FacultadId", "Facultad");
         
            return View();
        }

        // POST: tblestudiantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstudianteId,EstudianteCod,Nombres,Apellidos,FechaNacimiento,Genero,NacionalidadId,FacultadId,Direccion,Email,Telefono,Imagen,HojaVida,Perfil")] tblestudiante tblestudiante)
        {
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                db.tblestudiantes.Add(tblestudiante);
                Roles.AddUserToRole(Membership.GetUser().UserName, "Estudiante");
                return RedirectToAction("Index");
            }

            ViewBag.NacionalidadId = new SelectList(db.tblnacionalidads, "NacionalidaId", "Nacionalidad", tblestudiante.NacionalidadId);
            ViewBag.FacultadId = new SelectList(db.tblfacultads, "FacultadId", "Facultad", tblestudiante.FacultadId);
            return View(tblestudiante);
        }

        // GET: tblestudiantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblestudiante tblestudiante = db.tblestudiantes.Find(id);
            if (tblestudiante == null)
            {
                return HttpNotFound();
            }
            ViewBag.NacionalidadId = new SelectList(db.tblnacionalidads, "NacionalidaId", "Nacionalidad", tblestudiante.NacionalidadId);
            ViewBag.FacultadId = new SelectList(db.tblfacultads, "FacultadId", "Facultad", tblestudiante.FacultadId);
            return View(tblestudiante);
        }

        // POST: tblestudiantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstudianteId,EstudianteCod,Nombres,Apellidos,FechaNacimiento,Genero,NacionalidadId,FacultadId,Direccion,Email,Telefono,Imagen,HojaVida,Perfil")] tblestudiante tblestudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblestudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NacionalidadId = new SelectList(db.tblnacionalidads, "NacionalidaId", "Nacionalidad", tblestudiante.NacionalidadId);
            ViewBag.FacultadId = new SelectList(db.tblfacultads, "FacultadId", "Facultad", tblestudiante.FacultadId);
            return View(tblestudiante);
        }

        // GET: tblestudiantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblestudiante tblestudiante = db.tblestudiantes.Find(id);
            if (tblestudiante == null)
            {
                return HttpNotFound();
            }
            return View(tblestudiante);
        }

        // POST: tblestudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblestudiante tblestudiante = db.tblestudiantes.Find(id);
            db.tblestudiantes.Remove(tblestudiante);
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
