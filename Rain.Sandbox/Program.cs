using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Rain.Sandbox
{
	public interface IWave
	{
		float Probe(float time);
	}

	public class WhiteNoiseWave : IWave
	{
		private Random _randomGenerator = new Random();

		public float Probe(float time)
		{
			return (float)_randomGenerator.NextDouble();
		}
	}

	public class LowPassWaveFilter : IWave
	{
		private float _lastSample;
		private IWave _baseWave;

		public LowPassWaveFilter(IWave baseWave)
		{
			_baseWave = baseWave;
		}

		public float Probe(float time)
		{
			var value = _baseWave.Probe(time);

			_lastSample = _lastSample + (float)Math.Max(-0.2, Math.Min(0.2, Math.Sign(value - _lastSample) * (float)Math.Pow(value - _lastSample, 2)));

			return _lastSample;
		}
	}

	public class SinWaveFilter : IWave
	{
		private IWave _baseWave;

		public SinWaveFilter(IWave baseWave)
		{
			_baseWave = baseWave;
		}

		public float Probe(float time)
		{
			var filterValue = 0.75f + 0.25f * (float)Math.Sin(2 * Math.PI * time);

			return filterValue * _baseWave.Probe(time);
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
		private float _time;

		public IWave Wave { get; set; }

		public WaveFormat WaveFormat { get; set; }
		public float Amplitude { get; set; }

		public int Read(byte[] buffer, int offset, int count)
		{
			var valueBuffer = MemoryMarshal.Cast<byte, float>(buffer.AsSpan().Slice(offset, count));

			valueBuffer.Fill(0);

			int sampleRate = WaveFormat.SampleRate;
			for (int n = 0; n < valueBuffer.Length; n++)
			{
				valueBuffer[n] = Wave.Probe(_time) * Amplitude;
				_time += 1.0f / WaveFormat.SampleRate;
			}

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
				Wave = new SinWaveFilter(new LowPassWaveFilter(new WhiteNoiseWave()))
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
