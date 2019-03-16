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
			//var backgroundRainWave =
			//	new AmplitudeWaveTransformer(
			//		multiplier: 0.2f,
			//		offset: 0.0f,
			//		baseWave: new MultiplicationWaveCombiner(
			//			new AmplitudeWaveFilter(
			//				maxAmplitude: 0.75f,
			//				baseWave: new SquareWaveFilter(
			//					baseWave: new WhiteNoiseWaveGenerator())),
			//			new AmplitudeWaveTransformer(
			//				multiplier: 0.2f,
			//				offset: 0.8f,
			//				baseWave: new MultiplicationWaveCombiner(
			//					new FrequencyWaveTransformer(
			//						frequency: 0.25f,
			//						baseWave: new SinWaveGenerator()),
			//					new FrequencyWaveTransformer(
			//						frequency: 0.13f,
			//						baseWave: new SinWaveGenerator()),
			//					new FrequencyWaveTransformer(
			//						frequency: 0.07f,
			//						baseWave: new SinWaveGenerator())))));

			//var waveProvider = new WaveProvider(
			//	sampleRate: 16000,
			//	channels: new[] {
			//		new AdditiveWaveCombiner(
			//			new AmplitudeWaveTransformer(1.0f, 0.0f, backgroundRainWave),
			//			new PhaseWaveTransformer(0.5f, new AmplitudeWaveTransformer(0.5f, 0.0f, backgroundRainWave))),

			//		new AdditiveWaveCombiner(
			//			new AmplitudeWaveTransformer(0.5f, 0.0f, backgroundRainWave),
			//			new PhaseWaveTransformer(0.5f, new AmplitudeWaveTransformer(1.0f, 0.0f, backgroundRainWave)))
			//	});

			var thunderWave =
				new AmplitudeWaveTransformer(
					multiplier: 0.2f,
					offset: 0.0f,
					baseWave: new MultiplicationWaveCombiner(
						new SquareWaveFilter(new SquareWaveFilter(new WhiteNoiseWaveGenerator())),
						new MultiplicationWaveCombiner(
							new LinearWaveGenerator(-0.2f, 1f),
							new AmplitudeWaveTransformer(
								multiplier: 0.2f,
								offset: 0.8f,
								baseWave: new SinWaveGenerator()))));

			var waveProvider = new WaveProvider(
				sampleRate: 16000,
				channels: new[] {
					new LoopWaveTransformer(5f, new AmplitudeWaveTransformer(1.0f, 0.0f, thunderWave))
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
