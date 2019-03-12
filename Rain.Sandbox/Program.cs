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
			var sineWaveProvider = new WaveProvider(
				sampleRate: 16000, 
				channels: new[] {
					new AmplitureWaveTransformer(
						multiplier: 0.3f,
						baseWave: new MultiplicationWaveCombiner(
							new SquareWaveFilter(
								baseWave: new WhiteNoiseWaveGenerator()),
							new AmplitudeOffsetWaveTransformer(
								offset: 0.8f,
								baseWave: new AmplitureWaveTransformer(
									multiplier: 0.2f,
									baseWave: new MultiplicationWaveCombiner(
										new FrequencyWaveTransformer(
											period: 4f,
											baseWave: new SinWaveGenerator()),
										new FrequencyWaveTransformer(
											period: 3.3f,
											baseWave: new SinWaveGenerator()),
										new FrequencyWaveTransformer(
											period: 5.7f,
											baseWave: new SinWaveGenerator()))))))
				});

			using (var wo = new WaveOutEvent())
			{
				wo.Init(sineWaveProvider);
				wo.Play();

				while (wo.PlaybackState == PlaybackState.Playing)
					Thread.Sleep(500);
			}
		}
	}
}
