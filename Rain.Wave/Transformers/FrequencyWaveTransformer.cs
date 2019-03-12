using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Transformers
{
	public sealed class FrequencyWaveTransformer
	{
		private readonly IWave _baseWave;
		private readonly float _period;

		public FrequencyWaveTransformer(IWave baseWave, float period)
		{
			_baseWave = baseWave;
			_period = period;
		}

		public float Probe(float time)
		{
			return _baseWave.Probe(time * _period);
		}
	}
}
