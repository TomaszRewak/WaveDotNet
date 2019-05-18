using System;
using System.Collections.Generic;
using System.Text;

namespace WaveDotNet.Wave.Transformers
{
	public class LoopWaveTransformer : IWave
	{
		private readonly IWave _baseWave;
		private readonly double _period;

		public LoopWaveTransformer(IWave baseWave, double period)
		{
			_baseWave = baseWave;
			_period = period;
		}

		public double Probe(double time)
		{
			return _baseWave.Probe(time % _period);
		}
	}
}
