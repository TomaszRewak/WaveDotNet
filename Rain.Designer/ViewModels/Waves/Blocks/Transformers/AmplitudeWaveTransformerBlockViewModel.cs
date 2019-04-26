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

		private double _multiplier = 1;
		public double Multiplier
		{
			get => _multiplier;
			set => Set(ref _multiplier, value);
		}

		private double _vertivelOffset = 0;
		public double VerticalOffset
		{
			get => _vertivelOffset;
			set => Set(ref _vertivelOffset, value);
		}

		private double _horizontalOffset = 0;
		public double HorizontalOffset
		{
			get => _horizontalOffset;
			set => Set(ref _horizontalOffset, value);
		}

		public override IWave GenerateWave(IWave[] inputs)
		{
			return new AmplitudeWaveTransformer
			{
				Multiplier = Multiplier,
				HorizontalOffset = HorizontalOffset,
				VerticalOffset = VerticalOffset,
				BaseWave = inputs.First()
			};
		}
	}
}
