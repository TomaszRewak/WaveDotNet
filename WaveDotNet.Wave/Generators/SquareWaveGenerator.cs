using System;
using System.Collections.Generic;
using System.Text;

namespace WaveDotNet.Wave.Generators
{
	public sealed class SquareWaveGenerator : IWave
	{
		private readonly double _frequency;
		private readonly double _amplitude;

		public SquareWaveGenerator(double frequency, double amplitude)
		{
			_frequency = frequency;
			_amplitude = amplitude;
		}

		public double Probe(double time)
		{
			return (time * _frequency) % 1f < 0.5 ? -_amplitude : _amplitude;
		}
	}
}
