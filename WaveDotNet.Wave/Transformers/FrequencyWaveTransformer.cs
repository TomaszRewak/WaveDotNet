using System;
using System.Collections.Generic;
using System.Text;

namespace WaveDotNet.Wave.Transformers
{
	public sealed class FrequencyWaveTransformer : IWave
	{
		private readonly IWave _baseWave;
		private readonly double _frequency;

		public FrequencyWaveTransformer(IWave baseWave, double frequency)
		{
			_baseWave = baseWave;
			_frequency = frequency;
		}

		public double Probe(double time)
		{
			return _baseWave.Probe(time * _frequency);
		}
	}
}
