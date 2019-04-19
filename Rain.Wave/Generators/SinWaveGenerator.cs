using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Generators
{
	public sealed class SinWaveGenerator : IWave
	{
		private readonly float _frequency;

		public SinWaveGenerator(float frequency)
		{
			_frequency = frequency;
		}

		public float Probe(float time)
		{
			return (float)Math.Sin(time * Math.PI * 2 * _frequency);
		}
	}
}
