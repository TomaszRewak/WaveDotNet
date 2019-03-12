using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Generators
{
	public sealed class SinWaveGenerator : IWave
	{
		public float Probe(float time)
		{
			return (float)Math.Sin(time * Math.PI * 2);
		}
	}
}
