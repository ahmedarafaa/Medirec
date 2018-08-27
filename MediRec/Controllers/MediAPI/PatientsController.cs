using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using MediRec.Dtos;
using MediRec.Models;
using MediRec.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MediRec.Controllers.MediAPI
{
    public class PatientsController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Patients
        public IQueryable<Patients> GetPatients()
        {
            return _context.Patients;
        }

        // GET: api/Patients/5
        [ResponseType(typeof(Patients))]
        public IHttpActionResult GetPatients(int id)
        {

            var patients =
                from p in _context.Patients.Where(pa => pa.UserId == id)
                join c in _context.Cities on p.CityId equals c.CityId
                join a in _context.Areas on p.AreaId equals a.AreaId
                join u in _context.Users on p.UserId equals u.UserId
                select new
                {
                    p.PatientCode,
                    c.NameEn,
                    AreaName = a.NameEn,
                    u.FullName,
                    u.Gender,
                    Age = DateTime.Today.Year - u.BirthDate.Year,
                    p.ImageURL
                };

            //var patients = _context.Patients.Find(id);
            if (patients == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(patients);
        }

        // PUT: api/Patients/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public void PutPatients(int id, PatientsDto patientsDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var patient = _context.Patients.SingleOrDefault(p => p.UserId == id);

            if (patient == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(patientsDto, patient);

            _context.SaveChanges();
        }

        // POST: api/Patients
        [ResponseType(typeof(Patients))]
        public IHttpActionResult PostPatients(Patients patients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Patients.Add(patients);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = patients.PatientId }, patients);
        }

        [HttpPost]
        [Route("api/UploadPatientPhoto/{userId}")]
        public IHttpActionResult UploadPatientPhoto(int userId)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.UserId == userId);

            //return Ok(HttpContext.Current.Server.MapPath(""));

            string destinationPath = @"G:\\PleskVhosts\\medirec.me\\36765264api.medirec.me\\Documents\\";
            HttpFileCollection files = HttpContext.Current.Request.Files;

            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                if (file.ContentLength > 0)
                {
                    string fileName = new FileInfo(file.FileName).Name;
                    string fileExtention = new FileInfo(file.FileName).Extension;

                    if (fileExtention == ".jpg" || fileExtention == ".png")
                    {
                        Guid id = Guid.NewGuid();
                        fileName = id.ToString() + "_" + fileName;
                        file.SaveAs(destinationPath + Path.GetFileName(fileName));
                        patient.ImageURL = "Documents/" + fileName;
                        _context.Entry(patient).State = EntityState.Modified;
                        _context.SaveChanges();
                        return Ok("OK");
                    }
                }
            }
            return Ok("Photo could not be uploaded..");
        }

        // DELETE: api/Patients/5
        [ResponseType(typeof(Patients))]
        public IHttpActionResult DeletePatients(int id)
        {
            Patients patients = _context.Patients.Find(id);
            if (patients == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patients);
            _context.SaveChanges();

            return Ok(patients);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientsExists(int id)
        {
            return _context.Patients.Count(e => e.PatientId == id) > 0;
        }
    }
}