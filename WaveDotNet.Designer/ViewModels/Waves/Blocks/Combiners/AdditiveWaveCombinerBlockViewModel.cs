using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveDotNet.Wave;
using WaveDotNet.Wave.Combiners;

namespace WaveDotNet.Designer.ViewModels.Waves.Blocks.Combiners
{
	internal class AdditiveWaveCombinerBlockViewModel : WaveBlockViewModel
	{
		public AdditiveWaveCombinerBlockViewModel() : base(1, int.MaxValue)
		{
			UpdateWaveFactory();
		}

		public void UpdateWaveFactory()
		{
			WaveFactory = (IWave[] inputs) => new AdditiveWaveCombiner(waves: inputs);
		}

		public override dynamic Serialize()
		{
			return new { };
		}

		public override void Deserialize(dynamic value)
		{ }
	}
}
