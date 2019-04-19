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
			WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channels.Length);
			Channels = channels.Select(wave => new FrequencyWaveTransformer(1f / sampleRate, wave)).ToArray();
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			var valueBuffer = MemoryMarshal.Cast<byte, float>(buffer.AsSpan().Slice(offset, count));

			while (!valueBuffer.IsEmpty)
				valueBuffer = ReadSmaple(valueBuffer);

			return count;
		}

		private Span<float> ReadSmaple(Span<float> buffer)
		{
			for (int i = 0; i < Channels.Length; i++)
				buffer[i] = (float)Channels[i].Probe(_time);

			_time++;

			return buffer.Slice(Channels.Length);
		}
	}
}
