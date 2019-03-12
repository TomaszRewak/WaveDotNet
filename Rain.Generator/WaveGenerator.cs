using NAudio.Wave;
using Rain.Wave;
using Rain.Wave.Transformers;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Rain.Generator
{
	public class WaveProvider : IWaveProvider
	{
		private long _time;

		public WaveFormat WaveFormat { get; }
		public IWave[] Channels { get; }

		public WaveProvider(int sampleRate, params IWave[] channels)
		{
			WaveFormat = new WaveFormat(sampleRate, channels.Length);
			Channels = channels.Select(wave => new FrequencyWaveTransformer(sampleRate, wave)).ToArray();
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			var valueBuffer = MemoryMarshal.Cast<byte, float>(buffer.AsSpan().Slice(offset, count));

			for (int n = 0; n < valueBuffer.Length; n++)
				valueBuffer[n] = Channels[0].Probe(_time++);

			return count;
		}
	}
}
