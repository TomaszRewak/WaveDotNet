using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Modules.Helpers
{
    internal static class ModuleFactoryHelper
    {
		public static IServiceCollection AddFactory<T>(this IServiceCollection services) where T : class
		{
			services.AddTransient<T>();
			services.AddTransient<Func<T>>(sp => () => sp.GetService<T>());

			return services;
		}
    }
}
