using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rain.Wave.Combiners
{
	public sealed class AdditiveWaveCombiner : IWave
	{
		private readonly IWave[] _waves;

		public AdditiveWaveCombiner(params IWave[] waves)
		{
			_waves = waves;
		}

		public float Probe(float time)
		{
			return _waves.Sum(wave => wave.Probe(time));
		}
	}
}
