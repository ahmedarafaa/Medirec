﻿using System;
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
    public class DoctorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Doctors
        public ActionResult Index()
        {
            var doctors = db.Doctors.Include(d => d.Areas).Include(d => d.Cities).Include(d => d.Countries);
            return View(doctors.ToList());
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctors doctors = db.Doctors.Find(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            return View(doctors);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "AreaCode");
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CountryCode");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryCode");
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorId,DoctorCode,NameAr,NameEn,SpecialtyId,CountryId,CityId,AreaId,Gender,TickerPrice,AboutDoctorShortDescription,AboutDoctorLongDescription,BirthDate,RegisterDate,Address,WaitingTime,SearchName,CreatedBy,CreadtedDateTime,ModifiedBy,ModifiedDateTime")] Doctors doctors)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "AreaCode", doctors.AreaId);
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CountryCode", doctors.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryCode", doctors.CountryId);
            return View(doctors);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctors doctors = db.Doctors.Find(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "AreaCode", doctors.AreaId);
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CountryCode", doctors.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryCode", doctors.CountryId);
            return View(doctors);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorId,DoctorCode,NameAr,NameEn,SpecialtyId,CountryId,CityId,AreaId,Gender,TickerPrice,AboutDoctorShortDescription,AboutDoctorLongDescription,BirthDate,RegisterDate,Address,WaitingTime,SearchName,CreatedBy,CreadtedDateTime,ModifiedBy,ModifiedDateTime")] Doctors doctors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "AreaCode", doctors.AreaId);
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CountryCode", doctors.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryCode", doctors.CountryId);
            return View(doctors);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctors doctors = db.Doctors.Find(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            return View(doctors);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctors doctors = db.Doctors.Find(id);
            db.Doctors.Remove(doctors);
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