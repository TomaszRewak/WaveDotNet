using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rain.Wave.Combiners
{
	public sealed class AdditiveWaveCombiner : IWave
	{
		public IWave[] Waves { get; set; }

		public double Probe(double time)
		{
			return Waves.Sum(wave => wave.Probe(time));
		}
	}
}
