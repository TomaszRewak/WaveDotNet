using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Filters
{
	public sealed class AmplitudeWaveFilter : IWave
	{
		private readonly float _maxAmplitude;
		private readonly IWave _baseWave;

		public AmplitudeWaveFilter(float maxAmplitude, IWave baseWave)
		{
			_maxAmplitude = maxAmplitude;
			_baseWave = baseWave;
		}

		public float Probe(float time)
		{
			return Math.Max(-_maxAmplitude, Math.Min(_maxAmplitude, _baseWave.Probe(time)));
		}
	}
}
