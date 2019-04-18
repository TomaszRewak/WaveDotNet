using Microsoft.Extensions.DependencyInjection;
using Rain.Designer.Modules.Helpers;
using Rain.Designer.ViewModels.Tree;
using Rain.Designer.ViewModels.Tree.Helpers;
using Rain.Designer.ViewModels.Waves.Blocks.Combiners;
using Rain.Designer.ViewModels.Waves.Blocks.Generators;
using Rain.Designer.ViewModels.Waves.Blocks.Transformers;
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
			serviceCollection.AddTransient<TreeDesignerViewModel>();

			serviceCollection.AddFactory<TreeViewModel>();

			serviceCollection.AddFactory<AdditiveWaveCombinerBlockViewModel>();
			serviceCollection.AddFactory<LinearWaveGeneratorBlockViewModel>();
			serviceCollection.AddFactory<SinWaveGeneratorBlockViewModel>();
			serviceCollection.AddFactory<AmplitudeWaveTransformerBlockViewModel>();
			serviceCollection.AddFactory<FrequencyWaveTransformerBlockViewModel>();
			serviceCollection.AddFactory<WhiteNoiseWaveGeneratorBlockViewModel>();

			serviceCollection.AddSingleton<WaveBlockFactoryHelper>();
			serviceCollection.AddSingleton<WavePlayerHelper>();
			serviceCollection.AddSingleton<WaveBuilderHelper>();
		}
	}
}
