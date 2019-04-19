using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rain.Wave.Combiners
{
	public sealed class MultiplicationWaveCombiner : IWave
	{
		private readonly IWave[] _waves;

		public MultiplicationWaveCombiner(params IWave[] waves)
		{
			_waves = waves;
		}

		public double Probe(double time)
		{
			var value = 1.0;

			foreach (var wave in _waves)
				value *= wave.Probe(time);

			return value;
		}
	}
}
