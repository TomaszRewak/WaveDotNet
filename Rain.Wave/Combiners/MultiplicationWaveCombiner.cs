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

		public float Probe(float time)
		{
			return _waves.Aggregate(1f, (value, wave) => value * wave.Probe(time));
		}
	}
}
