using Microsoft.Extensions.DependencyInjection;
using Rain.Designer.ViewModels.Mesh;
using Rain.Designer.ViewModels.Mesh.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.Modules
{
	internal static class MeshModule
	{
		public static void Register(ServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<MeshViewModel>();
			serviceCollection.AddTransient<NodeViewModel>();
			serviceCollection.AddTransient<Func<NodeViewModel>>(sp => () => sp.GetService<NodeViewModel>());
			serviceCollection.AddTransient<ConnectionViewModel>();
			serviceCollection.AddTransient<Func<ConnectionViewModel>>(sp => () => sp.GetService<ConnectionViewModel>());

			serviceCollection.AddTransient<NodesHelper>();
			serviceCollection.AddTransient<ConnectionsHelper>();
		}
	}
}
