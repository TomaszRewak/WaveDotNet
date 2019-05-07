using Microsoft.Extensions.DependencyInjection;
using Rain.Designer.Modules.Helpers;
using Rain.Designer.ViewModels.Waves.Blocks.Mesh;
using Rain.Designer.ViewModels.Waves.Blocks.Mesh.Helpers;
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
			serviceCollection.AddFactory<MeshBlockViewModel>();
			serviceCollection.AddFactory<NodeViewModel>();
			serviceCollection.AddFactory<ConnectionViewModel>();

			serviceCollection.AddTransient<NodesHelper>();
			serviceCollection.AddTransient<ConnectionsHelper>();
			serviceCollection.AddTransient<WaveHelper>();
			serviceCollection.AddTransient<SerializationHelper>();
		}
	}
}
