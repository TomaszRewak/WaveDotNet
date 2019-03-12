using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Transformers
{
	public sealed class FrequencyWaveTransformer : IWave
	{
		private readonly float _period;
		private readonly IWave _baseWave;

		public FrequencyWaveTransformer(float period, IWave baseWave)
		{
			_period = period;
			_baseWave = baseWave;
		}

		public float Probe(float time)
		{
			return _baseWave.Probe(time / _period);
		}
	}
}
