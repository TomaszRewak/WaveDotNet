using Microsoft.Extensions.DependencyInjection;
using Rain.Designer.ViewModels.Samples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.Modules
{
    internal static class SamplesModule
	{
		public static void Register(ServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<SamplesViewModel>();
			serviceCollection.AddTransient<SampleViewModel>();
			serviceCollection.AddTransient<Func<SampleViewModel>>(sp => () => sp.GetService<SampleViewModel>());
		}
	}
}
