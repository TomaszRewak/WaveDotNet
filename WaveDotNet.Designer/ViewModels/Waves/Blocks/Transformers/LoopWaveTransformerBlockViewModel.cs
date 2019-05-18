using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveDotNet.Wave;
using WaveDotNet.Wave.Transformers;

namespace WaveDotNet.Designer.ViewModels.Waves.Blocks.Transformers
{
	internal class LoopWaveTransformerBlockViewModel : WaveBlockViewModel
	{
		public LoopWaveTransformerBlockViewModel() : base(1, 1)
		{
			UpdateWaveFactory();
		}

		private double _period = 1;
		public double Period
		{
			get => _period;
			set => Set(ref _period, value)
				.Then(UpdateWaveFactory);
		}

		public void UpdateWaveFactory()
		{
			var period = Period;

			WaveFactory = (IWave[] inputs) => new LoopWaveTransformer(baseWave: inputs.First(), period: period);
		}

		public override dynamic Serialize()
		{
			return new { Period };
		}

		public override void Deserialize(dynamic value)
		{
			Period = value.Period;
		}
	}
}
