using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveDotNet.Wave;
using WaveDotNet.Wave.Generators;

namespace WaveDotNet.Designer.ViewModels.Waves.Blocks.Generators
{
	internal class LinearWaveGeneratorBlockViewModel : WaveBlockViewModel
	{
		public LinearWaveGeneratorBlockViewModel() : base(0, 0)
		{
			UpdateWaveFactory();
		}

		private double _a = 1;
		public double A
		{
			get => _a;
			set => Set(ref _a, value)
				.Then(UpdateWaveFactory);
		}

		private double _b = 0;
		public double B
		{
			get => _b;
			set => Set(ref _b, value)
				.Then(UpdateWaveFactory);
		}

		public void UpdateWaveFactory()
		{
			var a = A;
			var b = B;

			WaveFactory = (IWave[] inputs) => new LinearWaveGenerator(a: a, b: b);
		}

		public override dynamic Serialize()
		{
			return new { A, B };
		}

		public override void Deserialize(dynamic value)
		{
			A = value.A;
			B = value.B;
		}
	}
}
