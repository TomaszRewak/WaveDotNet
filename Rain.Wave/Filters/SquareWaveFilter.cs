using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Filters
{
	public sealed class SquareWaveFilter : IWave
	{
		private readonly IWave _baseWave;

		public SquareWaveFilter(IWave baseWave)
		{
			_baseWave = baseWave;
		}

		public double Probe(double time)
		{
			var value = _baseWave.Probe(time);

			return value * value;
		}
	}
}
