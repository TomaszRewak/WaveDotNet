using Microsoft.Extensions.DependencyInjection;
using WaveDotNet.Designer.Modules.Helpers;
using WaveDotNet.Designer.ViewModels.Tree;
using WaveDotNet.Designer.ViewModels.Tree.Helpers;
using WaveDotNet.Designer.ViewModels.Waves.Blocks.Combiners;
using WaveDotNet.Designer.ViewModels.Waves.Blocks.Filters;
using WaveDotNet.Designer.ViewModels.Waves.Blocks.Generators;
using WaveDotNet.Designer.ViewModels.Waves.Blocks.Transformers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Modules
{
	internal static class TreeModule
	{
		public static void Register(ServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<TreeViewModel>();

			serviceCollection.AddFactory<NodeViewModel>();

			serviceCollection.AddFactory<AdditiveWaveCombinerBlockViewModel>();
			serviceCollection.AddFactory<MaxWaveCombinerBlockViewModel>();
			serviceCollection.AddFactory<MinWaveCombinerBlockViewModel>();
			serviceCollection.AddFactory<MultiplicationWaveCombinerBlockViewModel>();

			serviceCollection.AddFactory<AmplitudeWaveFilterBlockViewModel>();
			serviceCollection.AddFactory<PowerWaveFilterBlockViewModel>();
			serviceCollection.AddFactory<AveragingWaveFilterBlockViewModel>();

			serviceCollection.AddFactory<LinearWaveGeneratorBlockViewModel>();
			serviceCollection.AddFactory<SinWaveGeneratorBlockViewModel>();
			serviceCollection.AddFactory<SquareWaveGeneratorBlockViewModel>();
			serviceCollection.AddFactory<TriangleWaveGeneratorBlockViewModel>();

			serviceCollection.AddFactory<AmplitudeWaveTransformerBlockViewModel>();
			serviceCollection.AddFactory<FrequencyWaveTransformerBlockViewModel>();
			serviceCollection.AddFactory<LoopWaveTransformerBlockViewModel>();

			serviceCollection.AddSingleton<WaveBlockFactoryHelper>();
			serviceCollection.AddSingleton<WavePlayerHelper>();
			serviceCollection.AddSingleton<WaveBuilderHelper>();
			serviceCollection.AddSingleton<WaveBlockSerializationHelper>();
			serviceCollection.AddSingleton<ConnectionsHelper>();
		}
	}
}
