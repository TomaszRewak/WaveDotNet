using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rain.Wave;
using Rain.Wave.Filters;

namespace Rain.Designer.ViewModels.Waves.Blocks.Filters
{
	internal class LowPassWaveFilterBlockViewModel : WaveBlockViewModel
	{
		public double Alpha { get; set; }

		public LowPassWaveFilterBlockViewModel() : base(1, 1)
		{ }

		public override IWave GenerateWave(IWave[] inputs)
		{
			return new LowPassWaveFilter(alpha: Alpha, baseWave: inputs.First());
		}

		public override dynamic Serialize()
		{
			return new
			{
				Alpha
			};
		}

		public override void Deserialize(dynamic value)
		{
			Alpha = value.Alpha;
		}
	}
}
