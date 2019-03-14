using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Generators
{
	public sealed class SquareWaveGenerator : IWave
	{
		public float Probe(float time)
		{
			return time % 1f < 0.5 ? -1f : 1f;
		}
	}
}
