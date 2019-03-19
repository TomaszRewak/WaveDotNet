using Microsoft.Extensions.DependencyInjection;
using Rain.Designer.Modules;
using Rain.Designer.ViewModels.Mesh;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Rain.Designer
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			var serviceCollection = new ServiceCollection();
			MeshModule.Register(serviceCollection);
			var container = serviceCollection.BuildServiceProvider();

			container.GetRequiredService<MeshViewModel>();

			base.OnStartup(e);
		}
	}
}
