using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Generators
{
	public sealed class SinWaveGenerator : IWave
	{
		public double Frequency { get; set; }

		public double Probe(double time)
		{
			return Math.Sin(time * Math.PI * 2 * Frequency);
		}
	}
}
