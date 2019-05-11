using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Filters
{
	public sealed class PowerWaveFilter : IWave
	{
		private readonly IWave _baseWave;
		private readonly double _power;

		public PowerWaveFilter(IWave baseWave, double power)
		{
			_baseWave = baseWave;
			_power = power;
		}

		public double Probe(double time)
		{
			var value = _baseWave.Probe(time);

			return Math.Pow(value, _power);
		}
	}
}
