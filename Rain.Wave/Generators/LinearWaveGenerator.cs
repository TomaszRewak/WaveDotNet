using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Generators
{
	public sealed class LinearWaveGenerator : IWave
	{
		private readonly float _a;
		private readonly float _b;

		public LinearWaveGenerator(float a, float b)
		{
			_a = a;
			_b = b;
		}

		public float Probe(float time)
		{
			return _a * time + _b;
		}
	}
}
