using Rain.Designer.ViewModels.Waves;
using Rain.Designer.ViewModels.Waves.Blocks.Combiners;
using Rain.Designer.ViewModels.Waves.Blocks.Filters;
using Rain.Designer.ViewModels.Waves.Blocks.Generators;
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

			public WaveBlockFactory(string icon, string name, Func<WaveBlockViewModel> factory)
			{
				_factory = factory;

				Icon = icon;
				Name = name;
			}

			public WaveBlockViewModel Create() => _factory();

			public string Icon { get; }
			public string Name { get; }
			public Type Type => _factory.Method.ReturnType;
		}

		public WaveBlockFactoryHelper(
			Func<AdditiveWaveCombinerBlockViewModel> additiveWaveCombinerBlockFactory,
			Func<MaxWaveCombinerBlockViewModel> maxWaveCombinerBlockFactory,
			Func<MinWaveCombinerBlockViewModel> minWaveCombinerBlockFactory,
			Func<MultiplicationWaveCombinerBlockViewModel> multiplicationWaveCombinerBlockFactory,

			Func<AmplitudeWaveFilterBlockViewModel> amplitudeWaveFilterBlockFactory,
			Func<PowerWaveFilterBlockViewModel> powerWaveFilterBlockFactory,
			Func<LowPassWaveFilterBlockViewModel> lowPassWaveFilterBlockFactory,

			Func<LinearWaveGeneratorBlockViewModel> linearWaveGeneratorBlockFactory,
			Func<SinWaveGeneratorBlockViewModel> sinWaveGeneratorBlockFactory,
			Func<SquareWaveGeneratorBlockViewModel> squareWaveGeneratorBlockFactory,
			Func<TriangleWaveGeneratorBlockViewModel> triangleWaveGeneratorBlockFactory,
			Func<WhiteNoiseWaveGeneratorBlockViewModel> whiteNoiseWaveTransformerBlockFactory,

			Func<AmplitudeWaveTransformerBlockViewModel> amplitudeWaveTransformerBlockFactory,
			Func<FrequencyWaveTransformerBlockViewModel> frequencyWaveTransformerBlockFactory,
			Func<LoopWaveTransformerBlockViewModel> loopWaveTransformerBlockFactory)
		{
			AvailableFactories = new List<WaveBlockFactory>
			{
				new WaveBlockFactory("+", "Add", additiveWaveCombinerBlockFactory),
				new WaveBlockFactory("max", "Max", maxWaveCombinerBlockFactory),
				new WaveBlockFactory("min", "Min", minWaveCombinerBlockFactory),
				new WaveBlockFactory("ｘ", "Multiply", multiplicationWaveCombinerBlockFactory),

				new WaveBlockFactory("=", "Amplitude filter", amplitudeWaveFilterBlockFactory),
				new WaveBlockFactory("√", "Power filter", powerWaveFilterBlockFactory),
				new WaveBlockFactory("〜", "Low pass filter", lowPassWaveFilterBlockFactory),

				new WaveBlockFactory("╱", "Linear function", linearWaveGeneratorBlockFactory),
				new WaveBlockFactory("∿", "Sin function", sinWaveGeneratorBlockFactory),
				new WaveBlockFactory("⊓", "Square function", squareWaveGeneratorBlockFactory),
				new WaveBlockFactory("Λ", "Triangle function", triangleWaveGeneratorBlockFactory),
				new WaveBlockFactory("▩", "WhiteNoise", whiteNoiseWaveTransformerBlockFactory),

				new WaveBlockFactory("↥", "Amplitude", amplitudeWaveTransformerBlockFactory),
				new WaveBlockFactory("↝", "Frequency", frequencyWaveTransformerBlockFactory),
				new WaveBlockFactory("↻", "Loop", loopWaveTransformerBlockFactory)
			};
		}

		public IReadOnlyCollection<WaveBlockFactory> AvailableFactories { get; }
	}
}
