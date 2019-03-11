using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Generators
{
	public sealed class WhiteNoiseWaveGenerator : IWave
	{
		private Random _randomGenerator = new Random();

		public float Probe(float time)
		{
			return (float)_randomGenerator.NextDouble();
		}
	}
}
