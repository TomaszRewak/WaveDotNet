using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Filters
{
	public sealed class AmplitudeWaveFilter : IWave
	{
		private double MaxAmplitude { get; set; }
		private IWave BaseWave { get; set; }

		public double Probe(double time)
		{
			return Math.Max(-MaxAmplitude, Math.Min(MaxAmplitude, BaseWave.Probe(time)));
		}
	}
}
