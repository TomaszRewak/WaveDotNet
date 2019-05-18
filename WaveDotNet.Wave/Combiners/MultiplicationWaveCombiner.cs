using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveDotNet.Wave.Combiners
{
	public sealed class MultiplicationWaveCombiner : IWave
	{
		public readonly IWave[] _waves;

		public MultiplicationWaveCombiner(IWave[] waves)
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
