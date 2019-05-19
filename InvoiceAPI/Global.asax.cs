﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using InvoiceAPI.Tools;
using InvoiceAPI.Infrastructure;

namespace InvoiceAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(ContainerConfig.Configure());
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
