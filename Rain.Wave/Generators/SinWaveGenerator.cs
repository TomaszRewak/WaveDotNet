using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Generators
{
	public sealed class SinWaveGenerator : IWave
	{
		private readonly double _frequency;

		public SinWaveGenerator(double frequency)
		{
			_frequency = frequency;
		}

		public double Probe(double time)
		{
			return Math.Sin(time * Math.PI * 2 * _frequency);
		}
	}
}
