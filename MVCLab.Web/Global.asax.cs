﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using MVCLab.Web.App_Start;

namespace MVCLab.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacConfig.RegisterAutofac();

            
        }

        [HandleError(ExceptionType = typeof(NullReferenceException), View = "NullReferenceException")]
        //customErrors mode="On"
        public ActionResult Exception()
        {
            throw new NullReferenceException();
        }
    }
}
