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
		private SinWaveGenerator _lastWave;

		public SinWaveGeneratorBlockViewModel() : base(0, 0)
		{ }

		private double _frequency = 200.0;
		public double Frequency
		{
			get => _frequency;
			set => Set(ref _frequency, value)
				.Then(UpdateLastWave);
		}

		private double _amplitude = 1.0;
		public double Amplitude
		{
			get => _amplitude;
			set => Set(ref _amplitude, value)
				.Then(UpdateLastWave);
		}

		private void UpdateLastWave()
		{
			if (_lastWave == null)
				return;

			_lastWave.Amplitude = Amplitude;
			_lastWave.Frequency = Frequency;
		}

		public override IWave GenerateWave(IWave[] inputs)
		{
			return _lastWave = new SinWaveGenerator
			{
				Frequency = Frequency,
				Amplitude = Amplitude
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
