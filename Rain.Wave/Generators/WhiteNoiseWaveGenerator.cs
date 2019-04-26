using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Generators
{
	public sealed class WhiteNoiseWaveGenerator : IWave
	{
		private Random _randomGenerator = new Random();

		public double Amplitude { get; set; }

		public double Probe(double time)
		{
			return (_randomGenerator.NextDouble() * 2.0 - 1.0) * Amplitude;
		}
	}
}
