using Rain.Designer.ViewModels.Waves;
using Rain.Designer.ViewModels.Waves.Blocks.Combiners;
using Rain.Designer.ViewModels.Waves.Blocks.Filters;
using Rain.Designer.ViewModels.Waves.Blocks.Generators;
using Rain.Designer.ViewModels.Waves.Blocks.Mesh;
using Rain.Designer.ViewModels.Waves.Blocks.Transformers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Tree.Helpers
{
	internal class WaveBlockFactoryHelper
	{
		internal class WaveBlockFactory
		{
			private readonly Func<WaveBlockViewModel> _factory;

			public WaveBlockFactory(string name, Func<WaveBlockViewModel> factory)
			{
				_factory = factory;

				Name = name;
			}

			public WaveBlockViewModel Create() => _factory();

			public string Name { get; }
		}

		public WaveBlockFactoryHelper(
			Func<AdditiveWaveCombinerBlockViewModel> additiveWaveCombinerBlockFactory,
			Func<MaxWaveCombinerBlockViewModel> maxWaveCombinerBlockFactory,
			Func<MinWaveCombinerBlockViewModel> minWaveCombinerBlockFactory,
			Func<MultiplicationWaveCombinerBlockViewModel> multiplicationWaveCombinerBlockFactory,

			Func<AmplitudeWaveFilterBlockViewModel> amplitudeWaveFilterBlockFactory,
			Func<PowerWaveFilterBlockViewModel> powerWaveFilterBlockFactory,

			Func<LinearWaveGeneratorBlockViewModel> linearWaveGeneratorBlockFactory,
			Func<SinWaveGeneratorBlockViewModel> sinWaveGeneratorBlockFactory,
			Func<SquareWaveGeneratorBlockViewModel> squareWaveGeneratorBlockFactory,
			Func<TriangleWaveGeneratorBlockViewModel> triangleWaveGeneratorBlockFactory,
			Func<WhiteNoiseWaveGeneratorBlockViewModel> whiteNoiseWaveTransformerBlockFactory,

			Func<AmplitudeWaveTransformerBlockViewModel> amplitudeWaveTransformerBlockFactory,
			Func<FrequencyWaveTransformerBlockViewModel> frequencyWaveTransformerBlockFactory,
			Func<LoopWaveTransformerBlockViewModel> loopWaveTransformerBlockFactory,

			Func<MeshBlockViewModel> meshFactory)
		{
			AvailableFactories = new List<WaveBlockFactory>
			{
				new WaveBlockFactory("Add", additiveWaveCombinerBlockFactory),
				new WaveBlockFactory("Max", maxWaveCombinerBlockFactory),
				new WaveBlockFactory("Min", minWaveCombinerBlockFactory),
				new WaveBlockFactory("Multiply", multiplicationWaveCombinerBlockFactory),

				new WaveBlockFactory("Amplitude filter", amplitudeWaveFilterBlockFactory),
				new WaveBlockFactory("Power filter", powerWaveFilterBlockFactory),

				new WaveBlockFactory("Linear function", linearWaveGeneratorBlockFactory),
				new WaveBlockFactory("Sin function", sinWaveGeneratorBlockFactory),
				new WaveBlockFactory("Square function", squareWaveGeneratorBlockFactory),
				new WaveBlockFactory("Triangle function", triangleWaveGeneratorBlockFactory),
				new WaveBlockFactory("WhiteNoise", whiteNoiseWaveTransformerBlockFactory),

				new WaveBlockFactory("Amplitude", amplitudeWaveTransformerBlockFactory),
				new WaveBlockFactory("Frequency", frequencyWaveTransformerBlockFactory),
				new WaveBlockFactory("Loop", loopWaveTransformerBlockFactory),

				new WaveBlockFactory("Mesh", meshFactory)
			};
		}

		public IReadOnlyCollection<WaveBlockFactory> AvailableFactories { get; }
	}
}
