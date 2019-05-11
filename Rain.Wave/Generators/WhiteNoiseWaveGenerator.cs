using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Generators
{
	public sealed class WhiteNoiseWaveGenerator : IWave
	{
		private Random _randomGenerator = new Random();

		private readonly double _amplitude;

		public WhiteNoiseWaveGenerator(double amplitude)
		{
			_amplitude = amplitude;
		}

		public double Probe(double time)
		{
			return (_randomGenerator.NextDouble() * 2.0 - 1.0) * _amplitude;
		}
	}
}
