using System;
using System.Collections.Generic;
using System.Text;

namespace WaveDotNet.Wave.Filters
{
	public class AveragingWaveFilter : IWave
	{
		private readonly IWave _baseWave;
		private readonly double _alpha;

		public AveragingWaveFilter(IWave baseWave, double alpha)
		{
			_baseWave = baseWave;
			_alpha = alpha;
		}

		public double Probe(double time)
		{
			return (_baseWave.Probe(time - 1 / _alpha) + _baseWave.Probe(time + 1 / _alpha)) / 2;
		}
	}
}
