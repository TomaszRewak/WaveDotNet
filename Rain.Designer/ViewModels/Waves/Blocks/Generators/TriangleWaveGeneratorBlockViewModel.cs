using Rain.Wave;
using Rain.Wave.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Waves.Blocks.Generators
{
    internal class TriangleWaveGeneratorBlockViewModel : WaveBlockViewModel
	{
		public TriangleWaveGeneratorBlockViewModel() : base(0, 0)
		{ }

		private double _frequency = 200.0;
		public double Frequency
		{
			get => _frequency;
			set => Set(ref _frequency, value);
		}

		private double _amplitude = 1.0;
		public double Amplitude
		{
			get => _amplitude;
			set => Set(ref _amplitude, value);
		}

		public override IWave GenerateWave(IWave[] inputs)
		{
			return new TriangleWaveGenerator
			{
				Amplitude = Amplitude,
				Frequency = Frequency
			};
		}

		public override dynamic Serialize()
		{
			return new { Frequency, Amplitude };
		}

		public override void Deserialize(dynamic value)
		{
			Frequency = value.Frequency;
			Amplitude = value.Amplitude;
		}
	}
}
