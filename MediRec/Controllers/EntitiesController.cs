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
    public class EntitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Entities
        public ActionResult Index()
        {
            var entities = db.Entities.Include(e => e.Areas).Include(e => e.Cities).Include(e => e.Countries).Include(e => e.GetEntitiesTypes);
            return View(entities.ToList());
        }

        // GET: Entities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entities entities = db.Entities.Find(id);
            if (entities == null)
            {
                return HttpNotFound();
            }
            return View(entities);
        }

        // GET: Entities/Create
        public ActionResult Create()
        {
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "AreaCode");
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CountryCode");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryCode");
            ViewBag.EntitiesTypesId = new SelectList(db.EntitiesTypes, "EntitiesTypesId", "EntitiesTypesCode");
            return View();
        }

        // POST: Entities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntityId,EntityCode,NameAr,NameEn,CountryId,CityId,AreaId,EntitiesTypesId")] Entities entities)
        {
            if (ModelState.IsValid)
            {
                db.Entities.Add(entities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "AreaCode", entities.AreaId);
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CountryCode", entities.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryCode", entities.CountryId);
            ViewBag.EntitiesTypesId = new SelectList(db.EntitiesTypes, "EntitiesTypesId", "EntitiesTypesCode", entities.EntitiesTypesId);
            return View(entities);
        }

        // GET: Entities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entities entities = db.Entities.Find(id);
            if (entities == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "AreaCode", entities.AreaId);
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CountryCode", entities.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryCode", entities.CountryId);
            ViewBag.EntitiesTypesId = new SelectList(db.EntitiesTypes, "EntitiesTypesId", "EntitiesTypesCode", entities.EntitiesTypesId);
            return View(entities);
        }

        // POST: Entities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntityId,EntityCode,NameAr,NameEn,CountryId,CityId,AreaId,EntitiesTypesId")] Entities entities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaId = new SelectList(db.Areas, "AreaId", "AreaCode", entities.AreaId);
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CountryCode", entities.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryCode", entities.CountryId);
            ViewBag.EntitiesTypesId = new SelectList(db.EntitiesTypes, "EntitiesTypesId", "EntitiesTypesCode", entities.EntitiesTypesId);
            return View(entities);
        }

        // GET: Entities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entities entities = db.Entities.Find(id);
            if (entities == null)
            {
                return HttpNotFound();
            }
            return View(entities);
        }

        // POST: Entities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entities entities = db.Entities.Find(id);
            db.Entities.Remove(entities);
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
