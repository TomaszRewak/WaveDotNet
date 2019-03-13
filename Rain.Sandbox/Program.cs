using NAudio.Wave;
using Rain.Generator;
using Rain.Wave.Combiners;
using Rain.Wave.Filters;
using Rain.Wave.Generators;
using Rain.Wave.Transformers;
using System.Threading;

namespace Rain.Sandbox
{
	class Program
	{
		static void Main(string[] args)
		{
			var backgroundRainWave =
				new AmplitureWaveTransformer(
					multiplier: 0.2f,
					baseWave: new MultiplicationWaveCombiner(
						new SquareWaveFilter(
							baseWave: new WhiteNoiseWaveGenerator()),
						new VerticalWaveTransformer(
							offset: 0.8f,
							baseWave: new AmplitureWaveTransformer(
								multiplier: 0.2f,
								baseWave: new MultiplicationWaveCombiner(
									new FrequencyWaveTransformer(
										frequency: 0.25f,
										baseWave: new SinWaveGenerator()),
									new FrequencyWaveTransformer(
										frequency: 0.13f,
										baseWave: new SinWaveGenerator()),
									new FrequencyWaveTransformer(
										frequency: 0.07f,
										baseWave: new SinWaveGenerator()))))));

			var waveProvider = new WaveProvider(
				sampleRate: 16000,
				channels: new[] {
					new AdditiveWaveCombiner(
						new AmplitureWaveTransformer(1.0f, backgroundRainWave),
						new HorizontalWaveTransformer(0.5f, new AmplitureWaveTransformer(0.5f, backgroundRainWave))),

					new AdditiveWaveCombiner(
						new AmplitureWaveTransformer(0.5f, backgroundRainWave),
						new HorizontalWaveTransformer(0.5f, new AmplitureWaveTransformer(1.0f, backgroundRainWave)))
				});

			using (var wo = new WaveOutEvent())
			{
				wo.Init(waveProvider);
				wo.Play();

				while (wo.PlaybackState == PlaybackState.Playing)
					Thread.Sleep(500);
			}
		}
	}
}
