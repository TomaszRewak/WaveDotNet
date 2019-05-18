using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveDotNet.Wave;
using WaveDotNet.Wave.Filters;

namespace WaveDotNet.Designer.ViewModels.Waves.Blocks.Filters
{
	internal class PowerWaveFilterBlockViewModel : WaveBlockViewModel
	{
		public PowerWaveFilterBlockViewModel() : base(1, 1)
		{
			UpdateWaveFactory();
		}

		private double _power = 2;
		public double Power
		{
			get => _power;
			set => Set(ref _power, value)
				.Then(UpdateWaveFactory);
		}

		public void UpdateWaveFactory()
		{
			var power = Power;

			WaveFactory = (IWave[] inputs) => new PowerWaveFilter(baseWave: inputs.First(), power: power);
		}

		public override dynamic Serialize()
		{
			return new { Power };
		}

		public override void Deserialize(dynamic value)
		{
			Power = value.Power;
		}
	}
}
