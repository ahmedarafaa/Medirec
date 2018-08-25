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
using Microsoft.AspNet.Identity;

namespace MediRec.Controllers.MediAPI
{
    [Authorize]
    public class EntitiesController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Entities
        public IQueryable<Entities> GetEntities()
        {
            return _context.Entities;
        }

        // GET: api/Entities/5
        [ResponseType(typeof(Entities))]
        public IHttpActionResult GetEntities(int id)
        {
            Entities entities = _context.Entities.Find(id);
            if (entities == null)
            {
                return NotFound();
            }

            return Ok(entities);
        }

        // PUT: api/Entities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntities(int id, Entities entities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entities.EntityId)
            {
                return BadRequest();
            }

            _context.Entry(entities).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntitiesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Entities
        [ResponseType(typeof(Entities))]
        public IHttpActionResult PostEntities(Entities entities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entitiesDoctors = new EntitiesDoctors
            {
                CountryId = entities.CountryId,
                CityId = entities.CityId,
                AreaId = entities.AreaId,
                DoctorId = User.Identity.GetUserId()
            };

            _context.EntitiesDoctors.Add(entitiesDoctors);

            _context.Entities.Add(entities);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = entities.EntityId }, entities);
        }

        // DELETE: api/Entities/5
        [ResponseType(typeof(Entities))]
        public IHttpActionResult DeleteEntities(int id)
        {
            Entities entities = _context.Entities.Find(id);
            if (entities == null)
            {
                return NotFound();
            }

            _context.Entities.Remove(entities);
            _context.SaveChanges();

            return Ok(entities);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntitiesExists(int id)
        {
            return _context.Entities.Count(e => e.EntityId == id) > 0;
        }
    }
}