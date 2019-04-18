using NAudio.Wave;
using Rain.Wave;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Generator
{
	public class WavePlayer : IDisposable
	{
		private readonly IWavePlayer _player;

		public WavePlayer(IWave wave, int sampleRate = 16000) :
			this(new WaveProvider(sampleRate, new[] { wave }))
		{ }

		public WavePlayer(IWaveProvider waveProvider)
		{
			_player = new WaveOutEvent();
			_player.Init(waveProvider);
		}

		public void Play()
		{
			_player.Play();
		}

		public void Dispose()
		{
			_player.Dispose();
		}
	}
}
