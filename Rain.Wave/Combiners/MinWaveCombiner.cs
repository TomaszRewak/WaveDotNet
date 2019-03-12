using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Combiners
{
	public sealed class MinWaveCombiner
	{
		private readonly IWave _waveA;
		private readonly IWave _waveB;

		public MinWaveCombiner(IWave waveA, IWave waveB)
		{
			_waveA = waveA;
			_waveB = waveB;
		}

		public float Probe(float time)
		{
			return Math.Min(
				_waveA.Probe(time),
				_waveB.Probe(time)
			);
		}
	}
}
