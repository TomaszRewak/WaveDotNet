using NAudio.Wave;
using NAudio.Wave.SampleProviders;
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

	public class WhiteNoiseWaveProvider : IWaveProvider
	{
		private float _lastSample;
		private Random _randomGenerator = new Random();

		public float Frequency { get; set; }
		public float Amplitude { get; set; }
		public WaveFormat WaveFormat { get; set; }

		public int Read(byte[] buffer, int offset, int count)
		{
			var valueBuffer = MemoryMarshal.Cast<byte, float>(buffer.AsSpan().Slice(offset, count));

			int sampleRate = WaveFormat.SampleRate;
			for (int n = 0; n < valueBuffer.Length; n++)
			{
				float sample = (float)_randomGenerator.NextDouble();

				_lastSample = _lastSample + (float)Math.Max(-0.1, Math.Min(0.1, Math.Sign(sample - _lastSample) * (float)Math.Pow(sample - _lastSample, 2)));

				valueBuffer[n] = (float)(Amplitude * _lastSample);
			}
			return count;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var sineWaveProvider = new WhiteNoiseWaveProvider
			{
				Frequency = 500,
				Amplitude = 0.2f,
				WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(16000, 1)
			};

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
