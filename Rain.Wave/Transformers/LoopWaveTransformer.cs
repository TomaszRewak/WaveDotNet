using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Transformers
{
	public class LoopWaveTransformer : IWave
	{
		private readonly float _period;
		private readonly IWave _baseWave;

		public LoopWaveTransformer(float period, IWave baseWave)
		{
			_period = period;
			_baseWave = baseWave;
		}

		public float Probe(float time)
		{
			return _baseWave.Probe(time % _period);
		}
	}
}
