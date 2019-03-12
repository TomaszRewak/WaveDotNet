using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Rain.Wave;
using Rain.Wave.Combiners;
using Rain.Wave.Filters;
using Rain.Wave.Generators;
using Rain.Wave.Transformers;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Rain.Sandbox
{
	public class SimpleWaveProvider : IWaveProvider
	{
		private int _sample;

		public float Frequency { get; set; }
		public float Amplitude { get; set; }
		public WaveFormat WaveFormat { get; set; }

		public int Read(byte[] buffer, int offset, int count)
		{
			var valueBuffer = MemoryMarshal.Cast<byte, float>(buffer.AsSpan().Slice(offset, count));

			int sampleRate = WaveFormat.SampleRate;
			for (int n = 0; n < valueBuffer.Length; n++)
			{
				valueBuffer[n] = (float)(Amplitude * Math.Sin(2 * Math.PI * _sample * Frequency / sampleRate));
				_sample = (_sample + 1) % sampleRate;
			}
			return count;
		}
	}

	public class WaveProvider : IWaveProvider
	{
		private long _time;

		public WaveFormat WaveFormat { get; }
		public IWave Wave { get; }

		public WaveProvider(WaveFormat waveFormat, IWave wave)
		{
			WaveFormat = waveFormat;
			Wave = new FrequencyWaveTransformer(
				period: waveFormat.SampleRate,
				baseWave: wave);
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			var valueBuffer = MemoryMarshal.Cast<byte, float>(buffer.AsSpan().Slice(offset, count));

			for (int n = 0; n < valueBuffer.Length; n++)
				valueBuffer[n] = Wave.Probe(_time++);

			return count;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var sineWaveProvider = new WaveProvider(
				waveFormat: WaveFormat.CreateIeeeFloatWaveFormat(sampleRate: 16000, channels: 1),
				wave: new AmplitureWaveTransformer(
					multiplier: 0.3f,
					baseWave: new MultiplicationWaveCombiner(
						new SquareWaveFilter(new WhiteNoiseWaveGenerator()),
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
										baseWave: new SinWaveGenerator())))))));

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
