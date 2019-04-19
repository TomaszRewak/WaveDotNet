using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Transformers
{
	public sealed class PhaseWaveTransformer : IWave
	{
		private readonly double _offset;
		private readonly IWave _baseWave;

		public PhaseWaveTransformer(double offset, IWave baseWave)
		{
			_offset = offset;
			_baseWave = baseWave;
		}

		public double Probe(double time)
		{
			return _baseWave.Probe(time + _offset);
		}
	}
}
