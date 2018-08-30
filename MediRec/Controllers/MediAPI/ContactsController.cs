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
    public class ContactsController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Contacts
        public IQueryable<Contacts> GetContacts()
        {
            return _context.Contacts;
        }

        // GET: api/Contacts/5
        [EnableQuery(PageSize = 3)]
        [ResponseType(typeof(Contacts))]
        public IHttpActionResult GetContacts(int id)
        {
            var contacts = _context.Contacts.Where(c => c.UserId == id);

            if (contacts == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return Ok(contacts);
        }

        [Route("api/GetContactsDetails/{userId}")]
        [ResponseType(typeof(Contacts))]
        public IHttpActionResult GetContactsDetails(int userId)
        {
            var contacts = _context.Contacts.Where(c => c.UserId == userId);

            if (contacts == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return Ok(contacts);
        }

        [Route("api/GetContactsCount/{userId}")]
        public IHttpActionResult GetContactsCount(int userId)
        {
            var contacts = _context.Contacts.Count(c => c.UserId == userId);

            if (contacts == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(contacts);
        }

        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public void PutContacts(int id, ContactsDto contactsDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var contacts = _context.Contacts.SingleOrDefault(c => c.ContactId == id);

            if (contacts == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(contactsDto, contacts);

            _context.SaveChanges();
        }

        // POST: api/Contacts
        [ResponseType(typeof(Contacts))]
        public ContactsDto PostContacts(ContactsDto contactsDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var contacts = Mapper.Map<ContactsDto, Contacts>(contactsDto);
            _context.Contacts.Add(contacts);
            _context.SaveChanges();

            contactsDto.ContactId = contacts.ContactId;

            return contactsDto;
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(Contacts))]
        public IHttpActionResult DeleteContacts(int id)
        {
            Contacts contacts = _context.Contacts.SingleOrDefault(c => c.ContactId == id);
            if (contacts == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Contacts.Remove(contacts);
            _context.SaveChanges();

            return Ok(contacts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }

        private bool ContactsExists(int id)
        {
            return _context.Contacts.Count(e => e.ContactId == id) > 0;
        }
    }
}