using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MediRec.Models;

namespace MediRec.Controllers
{
    
    public class ImmunizationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Immunizations
        public ActionResult Index()
        {
            var immunizations = db.Immunizations.Include(i => i.Vaccines);
            return View(immunizations.ToList());
        }

        // GET: Immunizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Immunizations immunizations = db.Immunizations.Find(id);
            if (immunizations == null)
            {
                return HttpNotFound();
            }
            return View(immunizations);
        }

        // GET: Immunizations/Create
        public ActionResult Create()
        {
            ViewBag.VaccineId = new SelectList(db.Vaccines, "VaccineId", "Name");
            return View();
        }

        // POST: Immunizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImmunizationId,VaccineId,DateGiven,AdministratedBy,NextDoesDate,UserId")] Immunizations immunizations)
        {
            if (ModelState.IsValid)
            {
                db.Immunizations.Add(immunizations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VaccineId = new SelectList(db.Vaccines, "VaccineId", "Name", immunizations.VaccineId);
            return View(immunizations);
        }

        // GET: Immunizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Immunizations immunizations = db.Immunizations.Find(id);
            if (immunizations == null)
            {
                return HttpNotFound();
            }
            ViewBag.VaccineId = new SelectList(db.Vaccines, "VaccineId", "Name", immunizations.VaccineId);
            return View(immunizations);
        }

        // POST: Immunizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImmunizationId,VaccineId,DateGiven,AdministratedBy,NextDoesDate,UserId")] Immunizations immunizations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(immunizations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VaccineId = new SelectList(db.Vaccines, "VaccineId", "Name", immunizations.VaccineId);
            return View(immunizations);
        }

        // GET: Immunizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Immunizations immunizations = db.Immunizations.Find(id);
            if (immunizations == null)
            {
                return HttpNotFound();
            }
            return View(immunizations);
        }

        // POST: Immunizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Immunizations immunizations = db.Immunizations.Find(id);
            db.Immunizations.Remove(immunizations);
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
