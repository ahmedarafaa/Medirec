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
using System.Web.Http.OData;
using AutoMapper;
using MediRec.Dtos;
using MediRec.Models;

namespace MediRec.Controllers.MediAPI
{
    public class ImmunizationsController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Immunizations
        public IEnumerable<ImmunizationsDto> GetImmunizations()
        {
            return _context.Immunizations.ToList().Select(Mapper.Map<Immunizations,ImmunizationsDto>);
        }

        // GET: api/Immunizations/5
        [EnableQuery(PageSize = 10)]
        [ResponseType(typeof(Immunizations))]
        public IHttpActionResult GetImmunizations(int userId)
        {
            //var immunizations = _context.Immunizations.Include(i => i.UserId == userId);

            //if (immunizations == null)
            //    throw new HttpResponseException(HttpStatusCode.NotFound);

            //return Mapper.Map<Immunizations,ImmunizationsDto>(immunizations);

            var immunizations = _context.Immunizations.Where(i => i.UserId == userId);
            if (immunizations == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(immunizations);
        }

        [Route("api/GetImmunizationsDetails/{userId}")]
        [ResponseType(typeof(Immunizations))]
        public IHttpActionResult GetImmunizationsDetails(int userId)
        {
            var immunizations = _context.Immunizations.Where(i => i.UserId == userId);
            if (immunizations == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(immunizations);
        }

        [Route("api/GetImmunizationsCount/{userId}")]
        [ResponseType(typeof(Immunizations))]
        public IHttpActionResult GetImmunizationsCount(int userId)
        {
            var immunizations = _context.Immunizations.Count(i => i.UserId == userId);

            if (immunizations == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(immunizations);
        }

        // PUT: api/Immunizations/5
        [ResponseType(typeof(void))]
        public void PutImmunizations(int id, ImmunizationsDto immunizationsDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var immunizations = _context.Immunizations.SingleOrDefault(i => i.ImmunizationId == id);

            if (immunizations == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(immunizationsDto, immunizations);

            _context.SaveChanges();
        }

        // POST: api/Immunizations
        [ResponseType(typeof(Immunizations))]
        public ImmunizationsDto PostImmunizations(ImmunizationsDto immunizationsDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var immunizations = Mapper.Map<ImmunizationsDto, Immunizations>(immunizationsDto);
            _context.Immunizations.Add(immunizations);
            _context.SaveChanges();

            immunizationsDto.ImmunizationId = immunizations.ImmunizationId;

            return immunizationsDto;
        }

        // DELETE: api/Immunizations/5
        [ResponseType(typeof(Immunizations))]
        public IHttpActionResult DeleteImmunizations(int id)
        {
            var immunizations = _context.Immunizations.SingleOrDefault(i => i.ImmunizationId == id);
            if (immunizations == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Immunizations.Remove(immunizations);
            _context.SaveChanges();

            return Ok(immunizations);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }

        private bool ImmunizationsExists(int id)
        {
            return _context.Immunizations.Count(e => e.ImmunizationId == id) > 0;
        }
    }
}