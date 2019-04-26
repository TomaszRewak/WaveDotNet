using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Transformers
{
	public sealed class FrequencyWaveTransformer : IWave
	{
		public double Frequency { get; set; }
		public IWave BaseWave { get; set; }

		public double Probe(double time)
		{
			return BaseWave.Probe(time * Frequency);
		}
	}
}
