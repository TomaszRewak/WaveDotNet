using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Transformers
{
	public sealed class OffsetWaveTransformer
	{
		private readonly IWave _baseWave;
		private readonly float _offset;

		public OffsetWaveTransformer(IWave baseWave, float offset)
		{
			_baseWave = baseWave;
			_offset = offset;
		}

		public float Probe(float time)
		{
			return _baseWave.Probe(time + _offset);
		}
	}
}
