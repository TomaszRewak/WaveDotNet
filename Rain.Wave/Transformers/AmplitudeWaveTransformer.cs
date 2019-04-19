﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Transformers
{
	public sealed class AmplitudeWaveTransformer : IWave
	{
		private readonly double _multiplier;
		private readonly double _offset;
		private readonly IWave _baseWave;

		public AmplitudeWaveTransformer(double multiplier, double offset, IWave baseWave)
		{
			_multiplier = multiplier;
			_offset = offset;
			_baseWave = baseWave;
		}

		public double Probe(double time)
		{
			return _baseWave.Probe(time) * _multiplier + _offset;
		}
	}
}
