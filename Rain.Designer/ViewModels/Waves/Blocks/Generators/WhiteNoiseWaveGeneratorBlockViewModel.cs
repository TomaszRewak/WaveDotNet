using Rain.Wave;
using Rain.Wave.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Waves.Blocks.Generators
{
    internal class WhiteNoiseWaveGeneratorBlockViewModel : WaveBlockViewModel
	{
		public WhiteNoiseWaveGeneratorBlockViewModel() : base(0, 0)
		{ }

		public override IWave GenerateWave(IWave[] inputs)
		{
			return new WhiteNoiseWaveGenerator();
		}
	}
}
