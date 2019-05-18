using WaveDotNet.Designer.ViewModels.Common;
using WaveDotNet.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.ViewModels.Waves
{
	internal abstract class WaveBlockViewModel : ViewModel, ISerializable
	{
		public int MinInputs { get; }
		public int MaxInputs { get; }

		protected WaveBlockViewModel(int minInputs, int maxInputs)
		{
			MinInputs = minInputs;
			MaxInputs = maxInputs;
		}

		private Func<IWave[], IWave> _waveFactory;
		public Func<IWave[], IWave> WaveFactory
		{
			get => _waveFactory;
			set => Set(ref _waveFactory, value);
		}

		public abstract dynamic Serialize();
		public abstract void Deserialize(dynamic value);
	}
}
