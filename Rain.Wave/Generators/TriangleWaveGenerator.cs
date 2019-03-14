using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Generators
{
	public sealed class TriangleWaveGenerator : IWave
	{
		public float Probe(float time)
		{
			var modulo = time % 1f;

			return
				modulo < 0.5f
				?
				4f * modulo - 1f
				:
				-4f * modulo + 3f;
		}
	}
}
