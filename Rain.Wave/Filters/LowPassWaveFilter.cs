using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Filters
{
	public class LowPassWaveFilter : IWave
	{
		double _power = 0;
		double _lastProbe = int.MinValue;

		public double Alpha { get; set; }
		public IWave BaseWave { get; set; }

		public double Probe(double time)
		{
			if (_lastProbe == time)
				return _power;

			_lastProbe = time;

			return _power = Alpha * _power + (1 - Alpha) * BaseWave.Probe(time);
		}
	}
}
