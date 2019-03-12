using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Combiners
{
	public sealed class MultiplicationWaveCombiner : IWave
	{
		private readonly IWave _waveA;
		private readonly IWave _waveB;

		public MultiplicationWaveCombiner(IWave waveA, IWave waveB)
		{
			_waveA = waveA;
			_waveB = waveB;
		}

		public float Probe(float time)
		{
			return _waveA.Probe(time) * _waveB.Probe(time);
		}
	}
}
