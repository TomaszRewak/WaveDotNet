using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Transformers
{
	public sealed class AmplitudeWaveTransformer : IWave
	{
		private readonly float _multiplier;
		private readonly float _offset;
		private readonly IWave _baseWave;

		public AmplitudeWaveTransformer(float multiplier, float offset, IWave baseWave)
		{
			_multiplier = multiplier;
			_offset = offset;
			_baseWave = baseWave;
		}

		public float Probe(float time)
		{
			return _baseWave.Probe(time) * _multiplier + _offset;
		}
	}
}
