using AutoMapper;
using MediRec.Dtos;
using MediRec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace MediRec.Controllers.MediAPI
{
    public class DoctorsController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Doctors
        [EnableQuery(PageSize = 10)]
        public IHttpActionResult GetDoctors()
        {
            var doctor = _context.Doctors.Where(d => d.IsActive == false);

            if (doctor == null)
                throw new HttpResponseException(HttpStatusCode.NoContent);

            return Ok(doctor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoctorsExists(int id)
        {
            return _context.Doctors.Count(e => e.DoctorId == id) > 0;
        }
    }
}
