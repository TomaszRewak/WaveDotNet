using WaveDotNet.Wave;
using WaveDotNet.Wave.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.ViewModels.Waves.Blocks.Filters
{
	internal class AmplitudeWaveFilterBlockViewModel : WaveBlockViewModel
	{
		private double _maxAmplitude = 1;
		public double MaxAmplitude
		{
			get => _maxAmplitude;
			set => Set(ref _maxAmplitude, value)
				.Then(UpdateWaveFactory);
		}

		public AmplitudeWaveFilterBlockViewModel() : base(1, 1)
		{
			UpdateWaveFactory();
		}

		public void UpdateWaveFactory()
		{
			var maxAmplitude = MaxAmplitude;

			WaveFactory = (IWave[] inputs) => new AmplitudeWaveFilter(maxAmplitude: maxAmplitude, baseWave: inputs.First());
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
