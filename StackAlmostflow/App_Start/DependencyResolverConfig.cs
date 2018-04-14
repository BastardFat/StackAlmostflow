using StackAlmostflow.Ninject;
using StackAlmostflow.Database.Ninject;
using Ninject;
using System.Web.Http;
using System.Web.Mvc;
using System;
using StackAlmostflow.Services.Ninject;

namespace StackAlmostflow
{
    public class DependencyResolverConfig
    {
        public static void RegisterNinject()
        {


            var kernel = new StandardKernel(
                new DatabaseNinjectModule(),
                new ServicesNinjectModule()
            );


            NinjectDependencyResolver resolver = new NinjectDependencyResolver(kernel);
            DependencyResolver.SetResolver(resolver);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}