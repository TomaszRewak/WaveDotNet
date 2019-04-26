using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Transformers
{
	public class LoopWaveTransformer : IWave
	{
		public double Period { get; set; }
		public IWave BaseWave { get; set; }

		public double Probe(double time)
		{
			return BaseWave.Probe(time % Period);
		}
	}
}
