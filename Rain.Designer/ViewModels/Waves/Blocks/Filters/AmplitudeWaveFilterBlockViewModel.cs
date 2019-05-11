using Rain.Wave;
using Rain.Wave.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Waves.Blocks.Filters
{
	internal class AmplitudeWaveFilterBlockViewModel : WaveBlockViewModel
	{
		private double _maxAmplitude = 1;
		public double MaxAmplitude
		{
			get => _maxAmplitude;
			set => Set(ref _maxAmplitude, value);
		}

		public AmplitudeWaveFilterBlockViewModel() : base(1, 1)
		{ }

		public override IWave GenerateWave(IWave[] inputs)
		{
			return new AmplitudeWaveFilter(maxAmplitude: _maxAmplitude, baseWave: inputs.First());
		}

		public override dynamic Serialize()
		{
			return new { MaxAmplitude };
		}

		public override void Deserialize(dynamic value)
		{
			MaxAmplitude = value.MaxAmplitude;
		}
	}
}
