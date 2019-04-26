using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rain.Wave;
using Rain.Wave.Combiners;

namespace Rain.Designer.ViewModels.Waves.Blocks.Combiners
{
	internal class MaxWaveCombinerBlockViewModel : WaveBlockViewModel
	{
		public MaxWaveCombinerBlockViewModel() : base(1, Int32.MaxValue)
		{ }

		public override IWave GenerateWave(IWave[] inputs)
		{
			return new MaxWaveCombiner
			{
				Waves = inputs
			};
		}
	}
}
