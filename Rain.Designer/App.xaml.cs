using Microsoft.Extensions.DependencyInjection;
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
			var container = serviceCollection.BuildServiceProvider();

			base.OnStartup(e);
		}
	}
}
