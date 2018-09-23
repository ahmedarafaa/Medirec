using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Http;
using MediRec.Models;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Builder;

namespace MediRec
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var setting = config.Formatters.JsonFormatter.SerializerSettings;
            setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            setting.Formatting = Formatting.Indented;

            config.AddODataQueryFilter();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Doctors>("Doctors");
            builder.EntitySet<Entities>("Entities");
            builder.EntitySet<Areas>("Areas");
            builder.EntitySet<Cities>("Cities");
            builder.EntitySet<Countries>("Countries");
            builder.EntitySet<DoctorsEntities>("DoctorsEntities");
            builder.EntitySet<EntitiesTypes>("EntitiesTypes");
            builder.EntitySet<Specialties>("Specialties");
            builder.EntitySet<SubSpecialities>("SubSpecialities");

            config.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());


            config.EnsureInitialized();

            config.Select().Expand().Filter().OrderBy().MaxTop(null).Count();
        }

    }
}
