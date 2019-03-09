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

		public SimpleWaveProvider()
		{
			Frequency = 1000;
			Amplitude = 0.25f; // let's not hurt our ears            
		}

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

	class Program
	{
		static void Main(string[] args)
		{
			var sineWaveProvider = new SimpleWaveProvider();
			sineWaveProvider.WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(16000, 1); // 16kHz mono
			sineWaveProvider.Frequency = 500;
			sineWaveProvider.Amplitude = 0.2f;

			using (var wo = new WaveOutEvent())
			{
				wo.Init(sineWaveProvider);
				wo.Play();
				while (wo.PlaybackState == PlaybackState.Playing)
				{
					Thread.Sleep(500);
				}
			}
		}
	}
}
