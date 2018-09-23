using MediRec.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace MediRec.Controllers.MediAPI
{

    public class DoctorsController : ODataController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        [EnableQuery(MaxExpansionDepth = 5)]
        //[ODataRoute("Doctors")]
        [ODataRoute("DoctorsEntities")]
        [HttpGet]
        public IHttpActionResult GetDoctors()
        {
            //var query =
            //    from d in _context.Doctors
            //    from e in d.DoctorsEntities
            //    select new
            //    {
            //        d.DoctorId,
            //        d.NameEn,
            //        d.NameAr,
            //        d.Gender,
            //        d.AboutDoctorShortDescriptionEn,
            //        d.AboutDoctorShortDescriptionAr,
            //        d.SearchName,
            //        d.ImageURL,
            //        d.SpecialtyId,
            //        SpecialtiesNameEn = d.Specialties.NameEn,
            //        SpecialtiesNameAr = d.Specialties.NameAr,

            //        SubSpecialitiesNameEn = d.DoctorsSubSpecialities.Select(ds => ds.SubSpecialities.NameEn),
            //        SubSpecialitiesNameAr = d.DoctorsSubSpecialities.Select(ds => ds.SubSpecialities.NameAr),

            //        TitleNameEn = d.DoctorsDoctorsTitles.Select(dt => dt.DoctorsTitles.NameEn),
            //        TitleNameAr = d.DoctorsDoctorsTitles.Select(dt => dt.DoctorsTitles.NameAr),

            //        e.Entities.EntityId,
            //        EntityNameEn = e.Entities.NameEn,
            //        EntityNameAr = e.Entities.NameAr,
            //        EntityAddressEn = e.Entities.AddressEn,
            //        EntityAddressAr = e.Entities.AddressAr,
            //        EntityCalenderType = e.CalenderTypeId,
            //        EntityWaitingTime = e.WaitingTime,
            //        EntityTicketPrice = e.TicketPrice,

            //        EntityCityId = e.Entities.Cities.CityId,
            //        EntityCityNameEn = e.Entities.Cities.NameEn,
            //        EntityCityNameAr = e.Entities.Cities.NameAr,

            //        EntityAreaId = e.Entities.Areas.AreaId,
            //        EntityAreaNameEn = e.Entities.Areas.NameEn,
            //        EntityAreaNameAr = e.Entities.Areas.NameAr,

            //        PaymentId = e.PaymentTypes.PaymentTypesId,
            //        PaymentNameEn = e.PaymentTypes.NameEn,
            //        PaymentNameAr = e.PaymentTypes.NameAr

            //    };

            var query = _context.DoctorsEntities.Include(d => d.Doctors);


            if (query == null)
                throw new HttpResponseException(HttpStatusCode.NoContent);

            //return Ok(new
            //{
            //    Paging = new
            //    {
            //        Count = query.AsQueryable().Count()
            //    }
            //});
            return Ok(query);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }

        private bool DoctorsExists(int id)
        {
            return _context.Doctors.Count(e => e.DoctorId == id) > 0;
        }
    }
}
