﻿using StackAlmostflow.Database.Concrete;
using StackAlmostflow.Database.Concrete.Interfaces;
using StackAlmostflow.Utils;
using Ninject.Modules;
using Ninject.Web.Common;
using System.Linq;

namespace StackAlmostflow.Database.Ninject
{
    public class DatabaseNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStackAlmostflowDbContextFactory>().To<StackAlmostflowDbContextFactory>().InRequestScope();
            Bind<IStackAlmostflowUnitOfWork>().To<StackAlmostflowUnitOfWork>().InRequestScope();

            var bindings = NinjectDependencyAttribute.GetBindingsForAssembly(GetType().Assembly)
                .Select(x =>
                {
                    var binding = Bind(x.Source).To(x.Destenation);
                    switch (x.Scope)
                    {
                        case NinjectDependencyScope.Transient:
                            return binding.InTransientScope();
                        case NinjectDependencyScope.Request:
                            return binding.InRequestScope();
                        case NinjectDependencyScope.Thread:
                            return binding.InThreadScope();
                        case NinjectDependencyScope.Singleton:
                        default:
                            return binding.InSingletonScope();
                    }
                })
                .ToArray();

        }
    }
}
