using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Rain.Wave;
using Rain.Wave.Filters;
using Rain.Wave.Generators;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Rain.Sandbox
{
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
				Wave = new SinWaveFilter(new SquareWaveFilter(new WhiteNoiseWaveGenerator()))
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
