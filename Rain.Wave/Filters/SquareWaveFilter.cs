using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Filters
{
	public sealed class SquareWaveFilter : IWave
	{
		private readonly IWave _baseWave;

		private float _lastSample;

		public SquareWaveFilter(IWave baseWave)
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
}
