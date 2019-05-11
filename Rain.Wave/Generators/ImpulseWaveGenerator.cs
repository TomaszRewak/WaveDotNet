using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Generators
{
	public class ImpulseWaveGenerator : IWave
	{
		private double _lastProbeTime;

		private readonly double _amplitude;

		public ImpulseWaveGenerator(double amplitude)
		{
			_amplitude = amplitude;
		}

		public double Probe(double time)
		{
			if (_lastProbeTime >= time)
				return 0;

			_lastProbeTime = time;

			return _amplitude;
		}
	}
}
