using NAudio.Wave;
using WaveDotNet.Wave;
using System;
using System.Collections.Generic;
using System.Text;

namespace WaveDotNet.Generator
{
	public class WavePlayer : IDisposable
	{
		private readonly WaveProvider _waveProvider;
		private readonly IWavePlayer _wavePlayer;

		public WavePlayer(IWave wave, int sampleRate = 48000)
		{
			_waveProvider = new WaveProvider(sampleRate, new[] { wave });
			_wavePlayer = new WaveOutEvent();

			_wavePlayer.Init(_waveProvider);
		}

		public void Play()
		{
			if (_wavePlayer.PlaybackState != PlaybackState.Playing)
				_wavePlayer.Play();

			_waveProvider.Play();
		}

		public void Pause()
		{
			_waveProvider.Pause();
		}

		public void Stop()
		{
			_waveProvider.Stop();
		}

		public void Dispose()
		{
			_wavePlayer.Dispose();
		}
	}
}
