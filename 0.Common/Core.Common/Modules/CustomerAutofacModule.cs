using Autofac;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Modules
{
    public class CustomerAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);


            var assemblies = DependencyContext.Default.CompileLibraries.Where(lib => !lib.Serviceable && lib.Type.Equals("project", StringComparison.OrdinalIgnoreCase))
                .Select(lib => AssemblyLoadContext.Default.LoadFromAssemblyName(new System.Reflection.AssemblyName(lib.Name)))
                .ToArray();
            var baseType = typeof(IAutoInject);


            builder.RegisterAssemblyTypes(assemblies)
                  .Where(b => b.GetInterfaces().Any(c => c == baseType && b != baseType))
                  .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();
        }

    }
}
