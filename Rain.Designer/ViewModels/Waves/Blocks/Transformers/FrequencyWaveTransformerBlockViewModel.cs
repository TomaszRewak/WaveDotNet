using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rain.Wave;
using Rain.Wave.Transformers;

namespace Rain.Designer.ViewModels.Waves.Blocks.Transformers
{
	internal class FrequencyWaveTransformerBlockViewModel : WaveBlockViewModel
	{
		public FrequencyWaveTransformerBlockViewModel() : base(1, 1)
		{ }

		private float _frequency;
		public float Frequency
		{
			get => _frequency;
			set => Set(ref _frequency, value);
		}

		public override IWave GenerateWave(IWave[] inputs)
		{
			return new FrequencyWaveTransformer(Frequency, inputs.First());
		}
	}
}
