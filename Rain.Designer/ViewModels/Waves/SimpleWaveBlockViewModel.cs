using Rain.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Waves
{
	internal abstract class SimpleWaveBlockViewModel<T> : WaveBlockViewModel where T : IWave, new()
	{
		public SimpleWaveBlockViewModel()
		{
			MinInputs = 0;
			MaxInputs = 0;
		}

		public override IWave GenerateWave(IWave[] inputs)
		{
			return new T();
		}
	}
}
