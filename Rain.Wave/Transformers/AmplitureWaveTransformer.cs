using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Transformers
{
	public sealed class AmplitureWaveTransformer
	{
		private readonly IWave _baseWave;
		private readonly float _multiplier;

		public AmplitureWaveTransformer(IWave baseWave, float multiplier)
		{
			_baseWave = baseWave;
			_multiplier = multiplier;
		}

		public float Probe(float time)
		{
			return _baseWave.Probe(time) * _multiplier;
		}
	}
}
