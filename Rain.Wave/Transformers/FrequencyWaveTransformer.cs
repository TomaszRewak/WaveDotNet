using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Transformers
{
	public sealed class FrequencyWaveTransformer : IWave
	{
		private readonly double _frequency;
		private readonly IWave _baseWave;

		public FrequencyWaveTransformer(double frequency, IWave baseWave)
		{
			_frequency = frequency;
			_baseWave = baseWave;
		}

		public double Probe(double time)
		{
			return _baseWave.Probe(time * _frequency);
		}
	}
}
