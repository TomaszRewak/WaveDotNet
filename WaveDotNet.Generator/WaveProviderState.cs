using System;
using System.Collections.Generic;
using System.Text;

namespace WaveDotNet.Generator
{
	internal class WaveProviderState
	{
		private enum State { Playing, Paused, Stopped}

		private readonly int _sampleRate;
		private readonly int _fadeDelya;

		private int _sample = 0;

		private double _volume = 0;
		private double _targetVolume;
		private long _targetVolumeDelay;

		private State _state = State.Paused;
		private State _targetState;
		private long _targetStateDelay;

		public double Time => (double)_sample / _sampleRate;
		public double Volume => _volume;

		public WaveProviderState(int sampleRate)
		{
			_sampleRate = sampleRate;
			_fadeDelya = _sampleRate / 100;
		}

		internal void Step()
		{
			_targetStateDelay = Math.Max(0, _targetStateDelay - 1);
			_targetVolumeDelay = Math.Max(0, _targetVolumeDelay - 1);

			if (_targetStateDelay == 0)
				_state = _targetState;

			_volume += (_targetVolume - _volume) / (_targetVolumeDelay + 1);

			if (_state == State.Stopped)
				_sample = 0;
			if (_state == State.Playing)
				_sample++;
		}

		public void Play()
		{
			_targetStateDelay = 0;
			_targetState = State.Playing;

			_targetVolumeDelay = _fadeDelya / 10;
			_targetVolume = 1;
		}

		public void Pause()
		{
			_targetStateDelay = _fadeDelya;
			_targetState = State.Paused;

			_targetVolumeDelay = _fadeDelya;
			_targetVolume = 0;
		}

		public void Stop()
		{
			_targetStateDelay = _fadeDelya;
			_targetState = State.Stopped;

			_targetVolumeDelay = _fadeDelya;
			_targetVolume = 0;
		}
	}
}
