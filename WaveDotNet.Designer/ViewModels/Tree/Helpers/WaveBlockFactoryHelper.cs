using WaveDotNet.Designer.ViewModels.Waves;
using WaveDotNet.Designer.ViewModels.Waves.Blocks.Combiners;
using WaveDotNet.Designer.ViewModels.Waves.Blocks.Filters;
using WaveDotNet.Designer.ViewModels.Waves.Blocks.Generators;
using WaveDotNet.Designer.ViewModels.Waves.Blocks.Transformers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WaveDotNet.Designer.ViewModels.Tree.Helpers
{
	internal class WaveBlockFactoryHelper
	{
		internal class WaveBlockFactory
		{
			private readonly Func<WaveBlockViewModel> _factory;

			public WaveBlockFactory(Color color, string icon, string name, Func<WaveBlockViewModel> factory)
			{
				_factory = factory;

				Icon = icon;
				Color = color;
				Name = name;
			}

			public WaveBlockViewModel Create() => _factory();

			public Color Color { get; }
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
			Func<AveragingWaveFilterBlockViewModel> AveragingWaveFilterBlockFactory,

			Func<LinearWaveGeneratorBlockViewModel> linearWaveGeneratorBlockFactory,
			Func<SinWaveGeneratorBlockViewModel> sinWaveGeneratorBlockFactory,
			Func<SquareWaveGeneratorBlockViewModel> squareWaveGeneratorBlockFactory,
			Func<TriangleWaveGeneratorBlockViewModel> triangleWaveGeneratorBlockFactory,

			Func<AmplitudeWaveTransformerBlockViewModel> amplitudeWaveTransformerBlockFactory,
			Func<FrequencyWaveTransformerBlockViewModel> frequencyWaveTransformerBlockFactory,
			Func<LoopWaveTransformerBlockViewModel> loopWaveTransformerBlockFactory)
		{
			AvailableFactories = new List<WaveBlockFactory>
			{
				new WaveBlockFactory(Colors.CornflowerBlue, "+", "Add", additiveWaveCombinerBlockFactory),
				new WaveBlockFactory(Colors.CornflowerBlue, "↑", "Max", maxWaveCombinerBlockFactory),
				new WaveBlockFactory(Colors.CornflowerBlue, "↓", "Min", minWaveCombinerBlockFactory),
				new WaveBlockFactory(Colors.CornflowerBlue, "ｘ", "Multiply", multiplicationWaveCombinerBlockFactory),

				new WaveBlockFactory(Colors.Goldenrod, "=", "Amplitude filter", amplitudeWaveFilterBlockFactory),
				new WaveBlockFactory(Colors.Goldenrod, "〜", "Averaging filter", AveragingWaveFilterBlockFactory),
				new WaveBlockFactory(Colors.Goldenrod, "√", "Power filter", powerWaveFilterBlockFactory),

				new WaveBlockFactory(Color.FromRgb(105, 186, 96), "⟋", "Linear function", linearWaveGeneratorBlockFactory),
				new WaveBlockFactory(Color.FromRgb(105, 186, 96), "∿", "Sin function", sinWaveGeneratorBlockFactory),
				new WaveBlockFactory(Color.FromRgb(105, 186, 96), "⊓", "Square function", squareWaveGeneratorBlockFactory),
				new WaveBlockFactory(Color.FromRgb(105, 186, 96), "Λ", "Triangle function", triangleWaveGeneratorBlockFactory),

				new WaveBlockFactory(Colors.Gray, "↥", "Amplitude and offset", amplitudeWaveTransformerBlockFactory),
				new WaveBlockFactory(Colors.Gray, "↝", "Frequency", frequencyWaveTransformerBlockFactory),
				new WaveBlockFactory(Colors.Gray, "↻", "Loop", loopWaveTransformerBlockFactory)
			};
		}

		public IReadOnlyCollection<WaveBlockFactory> AvailableFactories { get; }
	}
}
