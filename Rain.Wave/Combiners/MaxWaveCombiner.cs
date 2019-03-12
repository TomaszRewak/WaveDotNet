using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Combiners
{
	public sealed class MaxWaveCombiner : IWave
	{
		private readonly IWave _waveA;
		private readonly IWave _waveB;

		public MaxWaveCombiner(IWave waveA, IWave waveB)
		{
			_waveA = waveA;
			_waveB = waveB;
		}

		public float Probe(float time)
		{
			return Math.Max(
				_waveA.Probe(time),
				_waveB.Probe(time)
			);
		}
	}
}
