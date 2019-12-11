using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalWEB2.Models;

namespace FinalWEB2.Controllers
{
    public class VISITASController : Controller
    {
        private WEBFINAL2Entities db = new WEBFINAL2Entities();

        // GET: VISITAS
        public ActionResult Index()
        {
            var vISITA = db.VISITA.Include(v => v.CONTACTOS);
            return View(vISITA.ToList());
        }

        // GET: VISITAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISITA vISITA = db.VISITA.Find(id);
            if (vISITA == null)
            {
                return HttpNotFound();
            }
            return View(vISITA);
        }

        // GET: VISITAS/Create
        public ActionResult Create()
        {
            ViewBag.ContactoDeVisita = new SelectList(db.CONTACTOS, "ID", "CEDULA");
            return View();
        }

        // POST: VISITAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ContactoDeVisita,NombreCompleto,Motivo,Fecha,HoraEntrada,HoraSalida")] VISITA vISITA)
        {
            if (ModelState.IsValid)
            {
                db.VISITA.Add(vISITA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactoDeVisita = new SelectList(db.CONTACTOS, "ID", "CEDULA", vISITA.ContactoDeVisita);
            return View(vISITA);
        }

        // GET: VISITAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISITA vISITA = db.VISITA.Find(id);
            if (vISITA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactoDeVisita = new SelectList(db.CONTACTOS, "ID", "CEDULA", vISITA.ContactoDeVisita);
            return View(vISITA);
        }

        // POST: VISITAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ContactoDeVisita,NombreCompleto,Motivo,Fecha,HoraEntrada,HoraSalida")] VISITA vISITA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vISITA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactoDeVisita = new SelectList(db.CONTACTOS, "ID", "CEDULA", vISITA.ContactoDeVisita);
            return View(vISITA);
        }

        // GET: VISITAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISITA vISITA = db.VISITA.Find(id);
            if (vISITA == null)
            {
                return HttpNotFound();
            }
            return View(vISITA);
        }

        // POST: VISITAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VISITA vISITA = db.VISITA.Find(id);
            db.VISITA.Remove(vISITA);
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
