using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Filters
{
	public class LowPassWaveFilter : IWave
	{
		double _power = 0;
		double _lastProbe = int.MinValue;

		private readonly IWave _baseWave;
		private readonly double _alpha;

		public LowPassWaveFilter(IWave baseWave, double alpha)
		{
			_baseWave = baseWave;
			_alpha = alpha;
		}

		public double Probe(double time)
		{
			if (_lastProbe == time)
				return _power;

			_lastProbe = time;

			return _power = _alpha * _power + (1 - _alpha) * _baseWave.Probe(time);
		}
	}
}
