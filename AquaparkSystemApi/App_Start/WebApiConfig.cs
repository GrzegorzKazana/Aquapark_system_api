using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AquaparkSystemApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //var config = new HttpSelfHostConfiguration("http://localhost:8080");
            //config.Formatters.JsonFormatter.SupportedMediaTypes
            //    .Add(new MediaTypeHeaderValue("text/html"));
            //config.Routes.MapHttpRoute(
            //    "API Default", "api/{controller}/{action}/{id}",
            //    new { id = RouteParameter.Optional });
            //config.MessageHandlers.Add(new CustomHeaderHandler());
            // Web API routes
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            config.MessageHandlers.Add(new CustomHeaderHandler());
            //config.EnableCors(new EnableCorsAttribute(Properties.Settings.Default.Cors, "", ""));
            //config.UseCors(CorsOptions.AllowAll);
            EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:8080", "*", "GET,POST");
            config.EnableCors(cors);
            //config.EnableCors(CorsOpt);
            //
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{userToken}",
                defaults: new { userToken = RouteParameter.Optional }
            );
        }
    }
}
