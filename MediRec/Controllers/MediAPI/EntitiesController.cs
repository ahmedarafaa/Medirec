using MediRec.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using System.Linq;
using System.Web.Http;

namespace MediRec.Controllers.MediAPI
{
    public class EntitiesController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        [ODataRoute("Entities")]
        [EnableQuery(MaxExpansionDepth = 5)]
        public IHttpActionResult GetEntities()
        {
            return Ok(db.Entities.AsQueryable());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntitiesExists(int key)
        {
            return db.Entities.Count(e => e.EntityId == key) > 0;
        }
    }
}
