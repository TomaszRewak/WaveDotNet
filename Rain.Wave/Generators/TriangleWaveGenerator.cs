using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Generators
{
	public sealed class TriangleWaveGenerator : IWave
	{
		public double Frequency { get; set; }
		public double Amplitude { get; set; }

		public double Probe(double time)
		{
			var modulo = (time * Frequency) % 1.0;

			return
				modulo < 0.5
				?
				(4.0 * modulo - 1.0) * Amplitude
				:
				(-4.0 * modulo + 3.0) * Amplitude;
		}
	}
}
