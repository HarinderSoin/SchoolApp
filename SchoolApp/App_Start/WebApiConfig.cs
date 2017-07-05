using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SchoolApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Added for Odata
            config.AddODataQueryFilter();
            // Added by HSS for JSON
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute("API Default", "api/{controller}/{action}/{id}",
new { id = RouteParameter.Optional });
        }
    }
}
