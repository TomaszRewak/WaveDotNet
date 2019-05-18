using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveDotNet.Wave;
using WaveDotNet.Wave.Generators;

namespace WaveDotNet.Designer.ViewModels.Waves.Blocks.Generators
{
	internal class SquareWaveGeneratorBlockViewModel : WaveBlockViewModel
	{
		public SquareWaveGeneratorBlockViewModel() : base(0, 0)
		{
			UpdateWaveFactory();
		}

		private double _frequency = 200.0;
		public double Frequency
		{
			get => _frequency;
			set => Set(ref _frequency, value)
				.Then(UpdateWaveFactory);
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
			var frequency = Frequency;

			WaveFactory = (IWave[] inputs) => new SquareWaveGenerator(amplitude: amplitude, frequency: frequency);
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
