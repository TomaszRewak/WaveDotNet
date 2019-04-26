using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rain.Wave;
using Rain.Wave.Transformers;

namespace Rain.Designer.ViewModels.Waves.Blocks.Transformers
{
	internal class LoopWaveTransformerBlockViewModel : WaveBlockViewModel
	{
		public LoopWaveTransformerBlockViewModel() : base(1, 1)
		{ }

		private double _period = 1;
		public double Period
		{
			get => _period;
			set => Set(ref _period, value);
		}

		public override IWave GenerateWave(IWave[] inputs)
		{
			return new LoopWaveTransformer
			{
				BaseWave = inputs.First(),
				Period = Period
			};
		}
	}
}
