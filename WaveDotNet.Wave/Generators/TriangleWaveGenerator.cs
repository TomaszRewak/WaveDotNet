using System;
using System.Collections.Generic;
using System.Text;

namespace WaveDotNet.Wave.Generators
{
	public sealed class TriangleWaveGenerator : IWave
	{
		private readonly double _frequency;
		private readonly double _amplitude;

		public TriangleWaveGenerator(double frequency, double amplitude)
		{
			_frequency = frequency;
			_amplitude = amplitude;
		}

		public double Probe(double time)
		{
			var modulo = (time * _frequency) % 1.0;

			return
				modulo < 0.5
				?
				(4.0 * modulo - 1.0) * _amplitude
				:
				(-4.0 * modulo + 3.0) * _amplitude;
		}
	}
}
