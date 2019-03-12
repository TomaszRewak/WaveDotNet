using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Transformers
{
	public sealed class AmplitureWaveTransformer : IWave
	{
		private readonly float _multiplier;
		private readonly IWave _baseWave;

		public AmplitureWaveTransformer(float multiplier, IWave baseWave)
		{
			_multiplier = multiplier;
			_baseWave = baseWave;
		}

		public float Probe(float time)
		{
			return _baseWave.Probe(time) * _multiplier;
		}
	}
}
