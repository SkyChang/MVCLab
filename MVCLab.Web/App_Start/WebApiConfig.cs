using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MVCLab.Domain.CRM;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace MVCLab.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // OData:
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Customer>("Customers");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "OData",
                model: builder.GetEdmModel());

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

      
        }
    }
}
