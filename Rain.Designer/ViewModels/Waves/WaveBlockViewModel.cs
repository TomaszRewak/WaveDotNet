using Rain.Designer.ViewModels.Common;
using Rain.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Waves
{
	internal abstract class WaveBlockViewModel : ViewModel
	{
		private int _minInputs = 0;
		public int MinInputs
		{
			get => _minInputs;
			set => Set(ref _minInputs, value);
		}

		private int _maxInputs = int.MaxValue;
		public int MaxInputs
		{
			get => _maxInputs;
			set => Set(ref _maxInputs, value);
		}

		public abstract IWave GenerateWave(IWave[] inputs);
	}
}
