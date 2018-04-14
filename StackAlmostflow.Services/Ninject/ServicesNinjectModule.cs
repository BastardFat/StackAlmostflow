using AutoMapper;
using Ninject.Modules;
using Ninject.Web.Common;
using StackAlmostflow.Services.Configurations;
using StackAlmostflow.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAlmostflow.Services.Ninject
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToMethod(ctx => AutoMapperConfig.CreateMapperConfiguration().CreateMapper()).InSingletonScope();

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
