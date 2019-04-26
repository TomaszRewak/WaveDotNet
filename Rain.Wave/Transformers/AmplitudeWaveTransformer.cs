using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Transformers
{
	public sealed class AmplitudeWaveTransformer : IWave
	{
		public double Multiplier { get; set; }
		public double HorizontalOffset { get; set; }
		public double VerticalOffset { get; set; }

		public IWave BaseWave { get; set; }

		public double Probe(double time)
		{
			return BaseWave.Probe(time + HorizontalOffset) * Multiplier + VerticalOffset;
		}
	}
}
