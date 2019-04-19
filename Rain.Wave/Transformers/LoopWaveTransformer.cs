using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Transformers
{
	public class LoopWaveTransformer : IWave
	{
		private readonly double _period;
		private readonly IWave _baseWave;

		public LoopWaveTransformer(double period, IWave baseWave)
		{
			_period = period;
			_baseWave = baseWave;
		}

		public double Probe(double time)
		{
			return _baseWave.Probe(time % _period);
		}
	}
}
