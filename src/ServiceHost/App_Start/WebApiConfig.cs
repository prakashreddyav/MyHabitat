using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace Services.FT.Host
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "GetRelations",
                routeTemplate: "api/MetaData/Relations/{id}",
                defaults: new {Controller= "MetaData", Action= "GetRelations",id = RouteParameter.Optional}
            );

            config.Routes.MapHttpRoute(
                name: "GetUserProfile",
                routeTemplate: "api/User/Profile",
                defaults: new { Controller = "UserManagement", Action = "GetProfile" }
            );

            config.Routes.MapHttpRoute(
                name: "GetUserProfile",
                routeTemplate: "api/User/Families/{id}",
                defaults: new { Controller = "Families", id = RouteParameter.Optional }
            );

            //For formatting response properties in camel case
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
