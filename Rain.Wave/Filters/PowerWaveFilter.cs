using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Filters
{
	public sealed class PowerWaveFilter : IWave
	{
		public IWave BaseWave { get; set; }

		public double Power { get; set; }

		public double Probe(double time)
		{
			var value = BaseWave.Probe(time);

			return Math.Pow(value, Power);
		}
	}
}
