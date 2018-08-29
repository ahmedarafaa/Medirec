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
    public class MedicalDevicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedicalDevices
        public ActionResult Index()
        {
            return View(db.MedicalDevices.ToList());
        }

        // GET: MedicalDevices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalDevices medicalDevices = db.MedicalDevices.Find(id);
            if (medicalDevices == null)
            {
                return HttpNotFound();
            }
            return View(medicalDevices);
        }

        // GET: MedicalDevices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalDevices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicalDevicesId,Name,UserId")] MedicalDevices medicalDevices)
        {
            if (ModelState.IsValid)
            {
                db.MedicalDevices.Add(medicalDevices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicalDevices);
        }

        // GET: MedicalDevices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalDevices medicalDevices = db.MedicalDevices.Find(id);
            if (medicalDevices == null)
            {
                return HttpNotFound();
            }
            return View(medicalDevices);
        }

        // POST: MedicalDevices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicalDevicesId,Name,UserId")] MedicalDevices medicalDevices)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalDevices).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicalDevices);
        }

        // GET: MedicalDevices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalDevices medicalDevices = db.MedicalDevices.Find(id);
            if (medicalDevices == null)
            {
                return HttpNotFound();
            }
            return View(medicalDevices);
        }

        // POST: MedicalDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicalDevices medicalDevices = db.MedicalDevices.Find(id);
            db.MedicalDevices.Remove(medicalDevices);
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
