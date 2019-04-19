using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Filters
{
	public sealed class AmplitudeWaveFilter : IWave
	{
		private readonly double _maxAmplitude;
		private readonly IWave _baseWave;

		public AmplitudeWaveFilter(double maxAmplitude, IWave baseWave)
		{
			_maxAmplitude = maxAmplitude;
			_baseWave = baseWave;
		}

		public double Probe(double time)
		{
			return Math.Max(-_maxAmplitude, Math.Min(_maxAmplitude, _baseWave.Probe(time)));
		}
	}
}
