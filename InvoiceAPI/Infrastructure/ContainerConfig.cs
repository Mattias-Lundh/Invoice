using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using InvoiceAPI.Tools;

namespace InvoiceAPI.Infrastructure
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var containerBuilder = new ContainerBuilder();

            // register additional dependencies here
            containerBuilder.RegisterType<PdfParser>().As<IPdfParser>();
            containerBuilder.RegisterType<DataExtractor>().As<IDataExtractor>();

            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            return containerBuilder.Build();
        }
    }
}