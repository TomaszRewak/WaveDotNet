using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Filters
{
	public sealed class AmplitudeWaveFilter : IWave
	{
		public double MaxAmplitude { get; set; }
		public IWave BaseWave { get; set; }

		public double Probe(double time)
		{
			return Math.Max(-MaxAmplitude, Math.Min(MaxAmplitude, BaseWave.Probe(time)));
		}
	}
}
