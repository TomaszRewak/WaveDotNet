using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveDotNet.Wave.Combiners
{
	public sealed class AdditiveWaveCombiner : IWave
	{
		private readonly IWave[] _waves;

		public AdditiveWaveCombiner(IWave[] waves)
		{
			_waves = waves;
		}

		public double Probe(double time)
		{
			return _waves.Sum(wave => wave.Probe(time));
		}
	}
}
