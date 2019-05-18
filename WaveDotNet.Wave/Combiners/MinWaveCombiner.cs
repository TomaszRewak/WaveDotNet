using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveDotNet.Wave.Combiners
{
	public sealed class MinWaveCombiner : IWave
	{
		private readonly IWave[] _waves;

		public MinWaveCombiner(IWave[] waves)
		{
			_waves = waves;
		}

		public double Probe(double time)
		{
			return _waves.Min(wave => wave.Probe(time));
		}
	}
}
