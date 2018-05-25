using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PRAserver
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services


            //   CORS (Cross-Origin Resource Sharing) 
            //   Enables XMLHttpRequests from localhost servers: Node.js (8080) and Python (8000)  
            //   for all API controllers and all HTTP methods
            var cors = new EnableCorsAttribute("http://localhost:8080 , http://localhost:8000", "*", "*"); // origins, headers, methods
            config.EnableCors(cors);


            // Web API routes
            config.MapHttpAttributeRoutes();                        
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

        }
    }
}
