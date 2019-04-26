using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rain.Wave;
using Rain.Wave.Generators;

namespace Rain.Designer.ViewModels.Waves.Blocks.Generators
{
	internal class LinearWaveGeneratorBlockViewModel : WaveBlockViewModel
	{
		public LinearWaveGeneratorBlockViewModel() : base(0, 0)
		{ }

		private double _a = 1;
		public double A
		{
			get => _a;
			set => Set(ref _a, value);
		}

		private double _b = 0;
		public double B
		{
			get => _b;
			set => Set(ref _b, value);
		}

		public override IWave GenerateWave(IWave[] inputs)
		{
			return new LinearWaveGenerator
			{
				A = A,
				B = B
			};
		}
	}
}
