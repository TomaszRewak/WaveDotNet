using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveDotNet.Wave;
using WaveDotNet.Wave.Transformers;

namespace WaveDotNet.Designer.ViewModels.Waves.Blocks.Transformers
{
	internal class FrequencyWaveTransformerBlockViewModel : WaveBlockViewModel
	{
		public FrequencyWaveTransformerBlockViewModel() : base(1, 1)
		{
			UpdateWaveFactory();
		}

		private double _frequency = 1;
		public double Frequency
		{
			get => _frequency;
			set => Set(ref _frequency, value)
				.Then(UpdateWaveFactory);
		}

		public void UpdateWaveFactory()
		{
			var frequency = Frequency;

			WaveFactory = (IWave[] inputs) => new FrequencyWaveTransformer(frequency: frequency, baseWave: inputs.First());
		}

		public override dynamic Serialize()
		{
			return new { Frequency };
		}

		public override void Deserialize(dynamic value)
		{
			Frequency = value.Frequency;
		}
	}
}
