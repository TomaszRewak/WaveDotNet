using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Generators
{
	public sealed class LinearWaveGenerator : IWave
	{
		public double A { get; set; }
		public double B { get; set; }

		public double Probe(double time)
		{
			return A * time + B;
		}
	}
}
