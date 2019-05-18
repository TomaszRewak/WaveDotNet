using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Filters
{
	public class LowPassWaveFilter : IWave
	{
		private readonly IWave _baseWave;
		private readonly double _alpha;

		public LowPassWaveFilter(IWave baseWave, double alpha)
		{
			_baseWave = baseWave;
			_alpha = alpha;
		}

		public double Probe(double time)
		{
			return (_baseWave.Probe(time - 1 / _alpha) + _baseWave.Probe(time + 1 / _alpha)) / 2;
		}
	}
}
