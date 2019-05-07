using Rain.Designer.ViewModels.Common;
using Rain.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Waves
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

		public bool CanGenerate(int inputsNumber) => inputsNumber >= MinInputs && inputsNumber <= MaxInputs;

		public abstract IWave GenerateWave(IWave[] inputs);

		public abstract dynamic Serialize();
		public abstract void Deserialize(dynamic value);
	}
}
