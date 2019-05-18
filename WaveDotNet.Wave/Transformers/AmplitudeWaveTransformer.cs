using System;
using System.Collections.Generic;
using System.Text;

namespace WaveDotNet.Wave.Transformers
{
	public sealed class AmplitudeWaveTransformer : IWave
	{
		private readonly IWave _baseWave;
		private readonly double _multiplier;
		private readonly double _horizontalOffset;
		private readonly double _verticalOffset;

		public AmplitudeWaveTransformer(IWave baseWave, double multiplier, double horizontalOffset, double verticalOffset)
		{
			_baseWave = baseWave;
			_multiplier = multiplier;
			_horizontalOffset = horizontalOffset;
			_verticalOffset = verticalOffset;
		}

		public double Probe(double time)
		{
			return _baseWave.Probe(time + _horizontalOffset) * _multiplier + _verticalOffset;
		}
	}
}
