using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Filters
{
	public sealed class SquareWaveFilter : IWave
	{
		public IWave BaseWave { get; set; }

		public SquareWaveFilter(IWave baseWave)
		{
			BaseWave = baseWave;
		}

		public double Probe(double time)
		{
			var value = BaseWave.Probe(time);

			return value * value;
		}
	}
}
