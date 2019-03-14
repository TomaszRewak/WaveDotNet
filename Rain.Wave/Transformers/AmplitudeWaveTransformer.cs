using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Transformers
{
	public sealed class AmplitudeWaveTransformer : IWave
	{
		private readonly float _multiplier;
		private readonly IWave _baseWave;

		public AmplitudeWaveTransformer(float multiplier, IWave baseWave)
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
