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
    public class CalendersDetailsController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();


        // GET: api/CalendersDetails/5
        [Route("api/CalendersDetails/{doctorId}")]
        [ResponseType(typeof(CalendersDetails))]
        public IHttpActionResult GetCalendersDetails(int doctorId, int entityId)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var calendersDetails = _context.CalendersDetails.Where(c => c.DoctorId == doctorId);

            if (calendersDetails == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return Ok(calendersDetails);
        }

        //EntityType --> 1 --> Calender from to
        //EntityType --> 2 --> Generate Calender per minutes 
        [Route("api/CalendersDetails/{doctorId}/{entityId}/{generateDays}/{entityType}")]
        [ResponseType(typeof(CalendersDetails))]
        public IHttpActionResult PostCalendersDetails(int doctorId, int entityId, int generateDays, int entityType)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //delete all records from database

            var deleteCalenderDetails = _context.CalendersDetails.Where(c => c.DoctorId == doctorId & c.EntityId == entityId);

            _context.CalendersDetails.RemoveRange(deleteCalenderDetails);
            _context.SaveChanges();

            //Generate calender
            var calenders = _context.Calenders.Where(c => c.DoctorId == doctorId & c.EntityId == entityId);

            if (calenders == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //Generate calender when entitytype = 1
            if (entityType == 1)
            {
                for (int i = 0; i < generateDays; i++)
                {
                    foreach (var item in calenders)
                    {
                        if (item.DayName == DateTime.Now.AddDays(+i).DayOfWeek.ToString())
                        {
                            var cDetails = new CalendersDetails
                            {
                                CalendersId = item.CalendersId,
                                EntityId = entityId,
                                DoctorId = doctorId,
                                TimeFrom = item.TimeFrom,
                                TimeTo = item.TimeTo,
                                Date = DateTime.Now.AddDays(+i),
                                DayName = DateTime.Now.AddDays(+i).DayOfWeek.ToString()
                            };
                            _context.CalendersDetails.Add(cDetails);
                        }
                    }
                }
            }


            //Generate calender when entitytype = 2

            if (entityType == 2)
            {
                for (int i = 0; i < generateDays; i++)
                {
                    foreach (var item in calenders)
                    {
                        if (item.TimeFrom == item.TimeTo && item.DayName == DateTime.Now.AddDays(+i).DayOfWeek.ToString())
                        {
                            var cDetails = new CalendersDetails
                            {
                                CalendersId = item.CalendersId,
                                EntityId = entityId,
                                DoctorId = doctorId,
                                TimeFrom = item.TimeFrom,
                                Date = DateTime.Now.AddDays(+i),
                                DayName = DateTime.Now.AddDays(+i).DayOfWeek.ToString()
                            };
                            _context.CalendersDetails.Add(cDetails);
                        }

                        for (var j = item.TimeFrom; j < item.TimeTo; j = j + TimeSpan.FromMinutes(item.GenerateEveryXMin))
                        {
                            if (item.DayName == DateTime.Now.AddDays(+i).DayOfWeek.ToString())
                            {
                                var cDetails = new CalendersDetails
                                {
                                    CalendersId = item.CalendersId,
                                    EntityId = entityId,
                                    DoctorId = doctorId,
                                    TimeFrom = j,
                                    Date = DateTime.Now.AddDays(+i),
                                    DayName = DateTime.Now.AddDays(+i).DayOfWeek.ToString()
                                };
                                _context.CalendersDetails.Add(cDetails);
                            }
                        }
                    }
                }

            }


            _context.SaveChanges();
            return Ok();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }

        private bool CalendersDetailsExists(int id)
        {
            return _context.CalendersDetails.Count(e => e.CalendersDetailsId == id) > 0;
        }
    }
}