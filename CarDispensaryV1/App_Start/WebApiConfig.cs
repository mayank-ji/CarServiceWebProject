using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.SqlClient;
using System.Web.Http.Cors;

namespace CarDispensaryV1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //json
            config.Formatters.Remove(config.Formatters.XmlFormatter);


            var cors = new EnableCorsAttribute("*", "*", "*"); // You can adjust these values as needed
            config.EnableCors(cors);
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
