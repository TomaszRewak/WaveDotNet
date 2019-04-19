using Rain.Wave;
using Rain.Wave.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Waves.Blocks.Generators
{
	internal class SinWaveGeneratorBlockViewModel : WaveBlockViewModel
	{
		public SinWaveGeneratorBlockViewModel() : base(0, 0)
		{ }

		private double _frequency = 200.0;
		public double Frequency
		{
			get => _frequency;
			set => Set(ref _frequency, value);
		}

		public override IWave GenerateWave(IWave[] inputs)
		{
			return new SinWaveGenerator(Frequency);
		}
	}
}
