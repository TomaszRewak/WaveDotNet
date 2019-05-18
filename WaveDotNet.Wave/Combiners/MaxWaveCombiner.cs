using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveDotNet.Wave.Combiners
{
	public sealed class MaxWaveCombiner : IWave
	{
		private readonly IWave[] _waves;

		public MaxWaveCombiner(IWave[] waves)
		{
			_waves = waves;
		}

		public double Probe(double time)
		{
			return _waves.Max(wave => wave.Probe(time));
		}
	}
}
