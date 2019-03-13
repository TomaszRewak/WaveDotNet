using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rain.Wave.Combiners
{
	public sealed class MinWaveCombiner : IWave
	{
		private readonly IWave[] _waves;

		public MinWaveCombiner(params IWave[] waves)
		{
			_waves = waves;
		}

		public float Probe(float time)
		{
			return this._waves.Min(wave => wave.Probe(time));
		}
	}
}
