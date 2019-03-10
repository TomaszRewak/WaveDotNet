using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Rain.Sandbox
{
	public interface IWave
	{
		float Probe();
	}

	public class FilteredWhiteNoiseWave : IWave
	{
		private Random _randomGenerator = new Random();
		private float _lastSample;

		public float Probe()
		{
			var randomValue = (float)_randomGenerator.NextDouble();

			_lastSample = _lastSample + (float)Math.Max(-0.2, Math.Min(0.2, Math.Sign(randomValue - _lastSample) * (float)Math.Pow(randomValue - _lastSample, 2)));

			return _lastSample;
		}
	}

	public class SinWaveFilter : IWave
	{
		private int _sample = 0;

		private IWave _baseWave;
		private int _interval;

		public SinWaveFilter(IWave baseWave, int interval)
		{
			_baseWave = baseWave;
			_interval = interval;
		}

		public float Probe()
		{
			_sample = (_sample + 1) % _interval;

			var filterValue = 0.75f + 0.25f * (float)Math.Sin(2 * Math.PI * _sample / _interval);

			return filterValue * _baseWave.Probe();
		}
	}

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
		public IWave Wave { get; set; }

		public WaveFormat WaveFormat { get; set; }
		public float Amplitude { get; set; }

		public int Read(byte[] buffer, int offset, int count)
		{
			var valueBuffer = MemoryMarshal.Cast<byte, float>(buffer.AsSpan().Slice(offset, count));

			valueBuffer.Fill(0);

			int sampleRate = WaveFormat.SampleRate;
			for (int n = 0; n < valueBuffer.Length; n++)
				valueBuffer[n] = Wave.Probe() * Amplitude;

			return count;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var sineWaveProvider = new WaveProvider
			{
				WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(16000, 1),
				Amplitude = 0.2f,
				Wave = new SinWaveFilter(
					new FilteredWhiteNoiseWave(),
					64000)
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
