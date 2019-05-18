using System;
using System.Collections.Generic;
using System.Text;

namespace WaveDotNet.Wave.Filters
{
	public sealed class AmplitudeWaveFilter : IWave
	{
		private readonly IWave _baseWave;
		private readonly double _maxAmplitude;

		public AmplitudeWaveFilter(IWave baseWave, double maxAmplitude)
		{
			_baseWave = baseWave;
			_maxAmplitude = maxAmplitude;
		}

		public double Probe(double time)
		{
			return Math.Max(-_maxAmplitude, Math.Min(_maxAmplitude, _baseWave.Probe(time)));
		}
	}
}
