using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rain.Wave;
using Rain.Wave.Transformers;

namespace Rain.Designer.ViewModels.Waves.Blocks.Transformers
{
	internal class AmplitudeWaveTransformerBlockViewModel : WaveBlockViewModel
	{
		public AmplitudeWaveTransformerBlockViewModel() : base(1, 1)
		{ }

		private double _multiplier;
		public double Multiplier
		{
			get => _multiplier;
			set => Set(ref _multiplier, value);
		}

		private double _offset;
		public double Offset
		{
			get => _offset;
			set => Set(ref _offset, value);
		}

		public override IWave GenerateWave(IWave[] inputs)
		{
			return new AmplitudeWaveTransformer(Multiplier, Offset, inputs.First());
		}
	}
}
