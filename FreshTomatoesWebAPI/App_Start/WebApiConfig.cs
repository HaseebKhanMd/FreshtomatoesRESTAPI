using FreshTomatoesWebAPI.Filters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FreshTomatoesWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }

            );

         
            //config.EnableCors();
            //config.EnableCors(new EnableCorsAttribute());

            // Enable JSON only with CamelCaseNames
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);    
        
            // SSL : Uncomment this to support HTTPS APIs 
            //config.Filters.Add(new RequireHttpsAttribute());

            // Uncomment this to add Security to WebAPI
            config.Filters.Add(new RequireAuthorizeAttribute());
        }
    }
}
