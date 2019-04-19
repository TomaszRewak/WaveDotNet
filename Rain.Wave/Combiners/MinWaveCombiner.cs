using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rain.Wave.Combiners
{
	public sealed class MinWaveCombiner : IWave
	{
		public IWave[] Waves { get; set; }

		public double Probe(double time)
		{
			return Waves.Min(wave => wave.Probe(time));
		}
	}
}
