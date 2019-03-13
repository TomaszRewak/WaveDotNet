using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Transformers
{
	public sealed class FrequencyWaveTransformer : IWave
	{
		private readonly float _frequency;
		private readonly IWave _baseWave;

		public FrequencyWaveTransformer(float frequency, IWave baseWave)
		{
			_frequency = frequency;
			_baseWave = baseWave;
		}

		public float Probe(float time)
		{
			return _baseWave.Probe(time * _frequency);
		}
	}
}
