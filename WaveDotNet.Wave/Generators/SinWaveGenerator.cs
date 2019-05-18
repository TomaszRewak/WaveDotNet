using System;
using System.Collections.Generic;
using System.Text;

namespace WaveDotNet.Wave.Generators
{
	public sealed class SinWaveGenerator : IWave
	{
		private readonly double _frequency;
		private readonly double _amplitude;

		public SinWaveGenerator(double frequency, double amplitude)
		{
			_frequency = frequency;
			_amplitude = amplitude;
		}

		public double Probe(double time)
		{
			return Math.Sin(time * Math.PI * 2 * _frequency) * _amplitude;
		}
	}
}
