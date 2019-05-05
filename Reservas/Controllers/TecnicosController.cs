using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reservas.Models;

namespace Reservas.Controllers
{
    public class TecnicosController : Controller
    {
        private ReservasDB db = new ReservasDB();

        // GET: Tecnicos
        public ActionResult Index()
        {
            return View(db.Tecnicos.ToList());
        }

        // GET: Tecnicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnicos tecnicos = db.Tecnicos.Find(id);
            if (tecnicos == null)
            {
                return HttpNotFound();
            }
            return View(tecnicos);
        }

        // GET: Tecnicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tecnicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Cidade,Fotografia")] Tecnicos tecnicos)
        {
            if (ModelState.IsValid)
            {
                db.Tecnicos.Add(tecnicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tecnicos);
        }

        // GET: Tecnicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnicos tecnicos = db.Tecnicos.Find(id);
            if (tecnicos == null)
            {
                return HttpNotFound();
            }
            return View(tecnicos);
        }

        // POST: Tecnicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Cidade,Fotografia")] Tecnicos tecnicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tecnicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tecnicos);
        }

        // GET: Tecnicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnicos tecnicos = db.Tecnicos.Find(id);
            if (tecnicos == null)
            {
                return HttpNotFound();
            }
            return View(tecnicos);
        }

        // POST: Tecnicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tecnicos tecnicos = db.Tecnicos.Find(id);
            db.Tecnicos.Remove(tecnicos);
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
