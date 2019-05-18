using System;
using System.Collections.Generic;
using System.Text;

namespace WaveDotNet.Wave.Generators
{
	public sealed class LinearWaveGenerator : IWave
	{
		private readonly double _a;
		private readonly double _b;

		public LinearWaveGenerator(double a, double b)
		{
			_a = a;
			_b = b;
		}

		public double Probe(double time)
		{
			return _a * time + _b;
		}
	}
}
