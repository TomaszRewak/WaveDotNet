using Microsoft.Extensions.DependencyInjection;
using Rain.Designer.ViewModels.WaveDesigner;
using Rain.Designer.ViewModels.WaveDesigner.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.Modules
{
	internal class WaveDesignerModule
	{
		public static void Register(ServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<WaveDesignerViewModel>();

			serviceCollection.AddTransient<FileHelper>();
			serviceCollection.AddTransient<SerializationHelper>();
		}
	}
}
