using Microsoft.Extensions.DependencyInjection;
using WaveDotNet.Designer.ViewModels.WaveDesigner;
using WaveDotNet.Designer.ViewModels.WaveDesigner.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Modules
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
