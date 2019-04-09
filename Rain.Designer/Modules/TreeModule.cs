using Microsoft.Extensions.DependencyInjection;
using Rain.Designer.ViewModels.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.Modules
{
    internal static class TreeModule
	{
		public static void Register(ServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<TreeViewModel>();
			serviceCollection.AddTransient<Func<TreeViewModel>>(sp => () => sp.GetRequiredService<TreeViewModel>());
		}
	}
}
