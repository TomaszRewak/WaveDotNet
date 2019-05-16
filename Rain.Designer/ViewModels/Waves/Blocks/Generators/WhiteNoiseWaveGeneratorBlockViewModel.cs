﻿using Rain.Wave;
using Rain.Wave.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Waves.Blocks.Generators
{
	internal class WhiteNoiseWaveGeneratorBlockViewModel : WaveBlockViewModel
	{
		public WhiteNoiseWaveGeneratorBlockViewModel() : base(0, 0)
		{
			UpdateWaveFactory();
		}

		private double _amplitude = 1.0;
		public double Amplitude
		{
			get => _amplitude;
			set => Set(ref _amplitude, value)
				.Then(UpdateWaveFactory);
		}

		public void UpdateWaveFactory()
		{
			var amplitude = Amplitude;

			WaveFactory = (IWave[] inputs) => new WhiteNoiseWaveGenerator(amplitude: amplitude);
		}

		public override dynamic Serialize()
		{
			return new { Amplitude };
		}

		public override void Deserialize(dynamic value)
		{
			Amplitude = value.Amplitude;
		}
	}
}
