using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rain.Wave.Combiners
{
	public sealed class MultiplicationWaveCombiner : IWave
	{
		public IWave[] Waves { get; set; }

		public double Probe(double time)
		{
			var value = 1.0;

			foreach (var wave in Waves)
				value *= wave.Probe(time);

			return value;
		}
	}
}
