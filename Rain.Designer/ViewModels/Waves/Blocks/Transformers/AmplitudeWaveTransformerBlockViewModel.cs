using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rain.Wave;
using Rain.Wave.Transformers;

namespace Rain.Designer.ViewModels.Waves.Blocks.Transformers
{
	internal class AmplitudeWaveTransformerBlockViewModel : WaveBlockViewModel
	{
		public AmplitudeWaveTransformerBlockViewModel()
		{
			MinInputs = 1;
			MaxInputs = 1;
		}

		private float _multiplier;
		public float Multiplier
		{
			get => _multiplier;
			set => Set(ref _multiplier, value);
		}

		private float _offset;
		public float Offset
		{
			get => _offset;
			set => Set(ref _offset, value);
		}

		public override IWave GenerateWave(IWave[] inputs)
		{
			return new AmplitudeWaveTransformer(Multiplier, Offset, inputs.First());
		}
	}
}
