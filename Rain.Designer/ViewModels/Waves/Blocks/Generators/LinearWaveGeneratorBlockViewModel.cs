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

		private float _a;
		public float A
		{
			get => _a;
			set => Set(ref _a, value);
		}

		private float _b;
		public float B
		{
			get => _b;
			set => Set(ref _b, value);
		}

		public override IWave GenerateWave(IWave[] inputs)
		{
			return new LinearWaveGenerator(A, B);
		}
	}
}
