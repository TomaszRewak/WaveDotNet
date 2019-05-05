using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Generators
{
	public class ImpulseWaveGenerator : IWave
	{
		private double _lastProbeTime;

		public double Amplitude { get; set; }

		public double Probe(double time)
		{
			if (_lastProbeTime >= time)
				return 0;

			_lastProbeTime = time;

			return Amplitude;
		}
	}
}
