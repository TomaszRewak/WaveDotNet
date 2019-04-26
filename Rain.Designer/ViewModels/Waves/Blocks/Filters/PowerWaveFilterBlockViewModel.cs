using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rain.Wave;
using Rain.Wave.Filters;

namespace Rain.Designer.ViewModels.Waves.Blocks.Filters
{
	internal class PowerWaveFilterBlockViewModel : WaveBlockViewModel
	{
		public PowerWaveFilterBlockViewModel() : base(1, 1)
		{ }

		private double _power = 2;
		public double Power
		{
			get => _power;
			set => Set(ref _power, value);
		}

		public override IWave GenerateWave(IWave[] inputs)
		{
			return new PowerWaveFilter
			{
				BaseWave = inputs.First(),
				Power = Power
			};
		}
	}
}
