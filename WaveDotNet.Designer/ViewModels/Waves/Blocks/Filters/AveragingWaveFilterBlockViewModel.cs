using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveDotNet.Wave;
using WaveDotNet.Wave.Filters;

namespace WaveDotNet.Designer.ViewModels.Waves.Blocks.Filters
{
	internal class AveragingWaveFilterBlockViewModel : WaveBlockViewModel
	{
		private double _alpha = 1000;
		public double Alpha
		{
			get => _alpha;
			set => Set(ref _alpha, value)
				.Then(UpdateWaveFactory);
		}

		public AveragingWaveFilterBlockViewModel() : base(1, 1)
		{
			UpdateWaveFactory();
		}

		public void UpdateWaveFactory()
		{
			var alpha = Alpha;

			WaveFactory = (IWave[] inputs) => new AveragingWaveFilter(alpha: alpha, baseWave: inputs.First());
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
