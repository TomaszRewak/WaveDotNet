using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Generators
{
	public sealed class SquareWaveGenerator : IWave
	{
		public double Frequency { get; set; }
		public double Amplitude { get; set; }

		public double Probe(double time)
		{
			return (time * Frequency) % 1f < 0.5 ? -Amplitude : Amplitude;
		}
	}
}
