using Microsoft.Extensions.DependencyInjection;
using WaveDotNet.Designer.ViewModels.Waves.Blocks.Combiners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Modules
{
	internal class WavesModule
	{
		public static void Register(ServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<AdditiveWaveCombinerBlockViewModel>();
		}
	}
}
