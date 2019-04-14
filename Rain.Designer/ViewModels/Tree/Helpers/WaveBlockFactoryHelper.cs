using Rain.Designer.ViewModels.Waves;
using Rain.Designer.ViewModels.Waves.Blocks.Combiners;
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

			public WaveBlockFactory(string name, Func<WaveBlockViewModel> factory)
			{
				_factory = factory;

				Name = name;
			}

			WaveBlockViewModel Create() => _factory();

			public string Name { get; }
		}

		public WaveBlockFactoryHelper(
			Func<AdditiveWaveCombinerBlockViewModel> additiveWaveCombinerBlockFactory,
			Func<LinearWaveGeneratorBlockViewModel> linearWaveGeneratorBlockFactory,
			Func<SinWaveGeneratorBlockViewModel> sinWaveGeneratorBlockFactory,
			Func<AmplitudeWaveTransformerBlockViewModel> amplitudeWaveTransformerBlockFactory,
			Func<FrequencyWaveTransformerBlockViewModel> frequencyWaveTransformerBlockFactory)
		{
			AvailableFactories = new List<WaveBlockFactory>
			{
				new WaveBlockFactory("Add", additiveWaveCombinerBlockFactory),
				new WaveBlockFactory("Linear function", linearWaveGeneratorBlockFactory),
				new WaveBlockFactory("Sin function", sinWaveGeneratorBlockFactory),
				new WaveBlockFactory("Amplitude", amplitudeWaveTransformerBlockFactory),
				new WaveBlockFactory("Frequency", frequencyWaveTransformerBlockFactory),
			};
		}

		public IReadOnlyCollection<WaveBlockFactory> AvailableFactories { get; }
    }
}
