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
    public class BloodPressureController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/BloodPressure
        public IQueryable<BloodPressure> GetBloodPressure()
        {
            return _context.BloodPressure;
        }

        // GET: api/BloodPressure/5
        [ResponseType(typeof(BloodPressure))]
        [EnableQuery(PageSize = 4)]
        public IHttpActionResult GetBloodPressure(int id)
        {
            var bloodPressure = _context.BloodPressure.Where(b => b.UserId == id);
            if (bloodPressure == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //return Mapper.Map<BloodPressure, BloodPressureDto>(bloodPressure);
            return Ok(bloodPressure);
        }

        [Route("api/GetBloodPressureDetails/{userId}")]
        [ResponseType(typeof(BloodPressure))]
        public IHttpActionResult GetBloodPressureDetails(int id)
        {
            var bloodPressure = _context.BloodPressure.Where(b => b.UserId == id);
            if (bloodPressure == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //return Mapper.Map<BloodPressure, BloodPressureDto>(bloodPressure);
            return Ok(bloodPressure);
        }

        [Route("api/GetBloodPressureCount/{userId}")]
        [ResponseType(typeof(BloodPressure))]
        public IHttpActionResult GetBloodPressureCount(int userId)
        {
            var bloodPressure = _context.BloodPressure.Count(i => i.UserId == userId);

            if (bloodPressure <= 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //return Mapper.Map<BloodPressure, BloodPressureDto>(bloodPressure);
            return Ok(bloodPressure);
        }

        // PUT: api/BloodPressure/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public void PutBloodPressure(int id, BloodPressureDto bloodPressureDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var bloodPressure = _context.BloodPressure.SingleOrDefault(b => b.BloodPressureId == id);

            if (bloodPressure == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(bloodPressureDto, bloodPressure);

            _context.SaveChanges();
        }

        // POST: api/BloodPressure
        [ResponseType(typeof(BloodPressure))]
        public BloodPressureDto PostBloodPressure(BloodPressureDto bloodPressureDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var bloodPressure = Mapper.Map<BloodPressureDto, BloodPressure>(bloodPressureDto);
            _context.BloodPressure.Add(bloodPressure);
            _context.SaveChanges();

            bloodPressureDto.BloodPressureId = bloodPressure.BloodPressureId;

            return bloodPressureDto;

        }

        // DELETE: api/BloodPressure/5
        [ResponseType(typeof(BloodPressure))]
        public IHttpActionResult DeleteBloodPressure(int id)
        {
            BloodPressure bloodPressure = _context.BloodPressure.SingleOrDefault(b => b.BloodPressureId == id);
            if (bloodPressure == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.BloodPressure.Remove(bloodPressure);
            _context.SaveChanges();

            return Ok(bloodPressure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BloodPressureExists(int id)
        {
            return _context.BloodPressure.Count(e => e.BloodPressureId == id) > 0;
        }
    }
}