using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MediRec.Models;

namespace MediRec.Controllers.MediAPI
{
    public class AreasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Areas
        //public IQueryable<Areas> GetAreas()
        //{
        //    return db.Areas;
        //}

        // GET: api/Areas/5
        [ResponseType(typeof(Areas))]
        public IHttpActionResult GetAreas(int id)
        {
            var areas = db.Areas.Where(a => a.CityId == id);
            if (areas == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(areas);
        }

        //// PUT: api/Areas/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutAreas(int id, Areas areas)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != areas.AreaId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(areas).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AreasExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Areas
        //[ResponseType(typeof(Areas))]
        //public IHttpActionResult PostAreas(Areas areas)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Areas.Add(areas);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = areas.AreaId }, areas);
        //}

        //// DELETE: api/Areas/5
        //[ResponseType(typeof(Areas))]
        //public IHttpActionResult DeleteAreas(int id)
        //{
        //    Areas areas = db.Areas.Find(id);
        //    if (areas == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Areas.Remove(areas);
        //    db.SaveChanges();

        //    return Ok(areas);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }

        private bool AreasExists(int id)
        {
            return db.Areas.Count(e => e.AreaId == id) > 0;
        }
    }
}