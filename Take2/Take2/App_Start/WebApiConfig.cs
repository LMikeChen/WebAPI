using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Take2.Filter;
using WebApiContrib.Formatting.Jsonp;

namespace Take2
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = config.Formatters.OfType<System.Net.Http.Formatting.JsonMediaTypeFormatter>().FirstOrDefault();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();


            //// Add support JSONP
            var formatter = new JsonpMediaTypeFormatter(jsonFormatter);
            config.Formatters.Insert(0, formatter);

#if !DEBUG
            config.Filters.Add(new RequireHttps());

#endif
        }
    }
}
