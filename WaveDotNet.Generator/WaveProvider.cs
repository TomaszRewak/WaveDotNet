using NAudio.Wave;
using WaveDotNet.Wave;
using WaveDotNet.Wave.Transformers;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace WaveDotNet.Generator
{
	internal class WaveProvider : IWaveProvider
	{
		private readonly WaveProviderState _state;

		public WaveFormat WaveFormat { get; }
		public IWave[] Channels { get; }

		public WaveProvider(int sampleRate, params IWave[] channels)
		{
			_state = new WaveProviderState(sampleRate);

			WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channels.Length);
			Channels = channels;
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
				buffer[i] = (float)(Channels[i].Probe(_state.Time) * _state.Volume);

			_state.Step();

			return buffer.Slice(Channels.Length);
		}

		public void Play() => _state.Play();
		public void Pause() => _state.Pause();
		public void Stop() => _state.Stop();
	}
}
