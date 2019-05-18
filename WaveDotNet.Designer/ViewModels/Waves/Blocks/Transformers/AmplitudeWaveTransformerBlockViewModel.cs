using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveDotNet.Wave;
using WaveDotNet.Wave.Transformers;

namespace WaveDotNet.Designer.ViewModels.Waves.Blocks.Transformers
{
	internal class AmplitudeWaveTransformerBlockViewModel : WaveBlockViewModel
	{
		public AmplitudeWaveTransformerBlockViewModel() : base(1, 1)
		{
			UpdateWaveFactory();
		}

		private double _multiplier = 1;
		public double Multiplier
		{
			get => _multiplier;
			set => Set(ref _multiplier, value)
				.Then(UpdateWaveFactory);
		}

		private double _vertivelOffset = 0;
		public double VerticalOffset
		{
			get => _vertivelOffset;
			set => Set(ref _vertivelOffset, value)
				.Then(UpdateWaveFactory);
		}

		private double _horizontalOffset = 0;
		public double HorizontalOffset
		{
			get => _horizontalOffset;
			set => Set(ref _horizontalOffset, value)
				.Then(UpdateWaveFactory);
		}

		public void UpdateWaveFactory()
		{
			var multiplier = Multiplier;
			var horizontalOffset = HorizontalOffset;
			var verticalOffset = VerticalOffset;

			WaveFactory = (IWave[] inputs) => new AmplitudeWaveTransformer(baseWave: inputs.First(), multiplier: multiplier, horizontalOffset: horizontalOffset, verticalOffset: verticalOffset);
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
