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
			return new AmplitudeWaveTransformer(baseWave: inputs.First(), multiplier: Multiplier, horizontalOffset: HorizontalOffset, verticalOffset: VerticalOffset);
		}

		public override dynamic Serialize()
		{
			return new { Multiplier, VerticalOffset, HorizontalOffset };
		}

		public override void Deserialize(dynamic value)
		{
			Multiplier = value.Multiplier;
			VerticalOffset = value.VerticalOffset;
			HorizontalOffset = value.HorizontalOffset;
		}
	}
}
