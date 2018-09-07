using AutoMapper;
using MediRec.Dtos;
using MediRec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediRec.Controllers.MediAPI
{
    public class SpecialtiesController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Specialties
        public IEnumerable<SpecialtiesDto> GetDoctors()
        {
            return _context.Specialties.ToList().Select(Mapper.Map<Specialties, SpecialtiesDto>);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }

        private bool DoctorsExists(int id)
        {
            return _context.Specialties.Count(e => e.SpecialtyId == id) > 0;
        }
    }
}
