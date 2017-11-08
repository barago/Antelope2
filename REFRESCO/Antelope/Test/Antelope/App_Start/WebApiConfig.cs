using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Antelope
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/action/{controller}/{action}/{id}/{param1}/{param2}",
                defaults: new { id = RouteParameter.Optional, param1 = RouteParameter.Optional, param2 = RouteParameter.Optional }
            );
        }
    }
}
