using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace isvb.dev
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "DashboardAPI/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
