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
using AutoMapper;
using MediRec.Dtos;
using MediRec.Models;

namespace MediRec.Controllers.MediAPI
{
    public class VaccinesController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Vaccines
        public IEnumerable<VaccinesDto> GetVaccines()
        {
            return _context.Vaccines.ToList().Select(Mapper.Map<Vaccines, VaccinesDto>);
        }

        // GET: api/Vaccines/5
        //[ResponseType(typeof(Vaccines))]
        //public IHttpActionResult GetVaccines(int id)
        //{
        //    Vaccines vaccines = db.Vaccines.Find(id);
        //    if (vaccines == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(vaccines);
        //}

        // PUT: api/Vaccines/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutVaccines(int id, Vaccines vaccines)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != vaccines.VaccineId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(vaccines).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!VaccinesExists(id))
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

        //// POST: api/Vaccines
        //[ResponseType(typeof(Vaccines))]
        //public IHttpActionResult PostVaccines(Vaccines vaccines)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Vaccines.Add(vaccines);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = vaccines.VaccineId }, vaccines);
        //}

        //// DELETE: api/Vaccines/5
        //[ResponseType(typeof(Vaccines))]
        //public IHttpActionResult DeleteVaccines(int id)
        //{
        //    Vaccines vaccines = db.Vaccines.Find(id);
        //    if (vaccines == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Vaccines.Remove(vaccines);
        //    db.SaveChanges();

        //    return Ok(vaccines);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }

        private bool VaccinesExists(int id)
        {
            return _context.Vaccines.Count(e => e.VaccineId == id) > 0;
        }
    }
}