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
		private double _alpha = 0.9;
		public double Alpha
		{
			get => _alpha;
			set => Set(ref _alpha, value)
				.Then(UpdateWaveFactory);
		}

		public LowPassWaveFilterBlockViewModel() : base(1, 1)
		{
			UpdateWaveFactory();
		}

		public void UpdateWaveFactory()
		{
			var alpha = Alpha;

			WaveFactory = (IWave[] inputs) => new LowPassWaveFilter(alpha: alpha, baseWave: inputs.First());
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
