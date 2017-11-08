using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Antelope.Binders;
using System.Web.Http.ModelBinding.Binders;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

using Antelope.Handlers;
using Antelope.Models;

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

            config.MessageHandlers.Add(new DatatableCookieHandler());

            var provider = new SimpleModelBinderProvider(typeof(JsonDatatable), new JsonDatatableBinder());
            config.Services.Insert(typeof(ModelBinderProvider), 0, provider);
        }
    }
}
