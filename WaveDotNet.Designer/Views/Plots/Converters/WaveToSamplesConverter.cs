using WaveDotNet.Designer.Views.Common;
using WaveDotNet.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WaveDotNet.Designer.Views.Plots.Converters
{
	internal class WaveToSamplesConverter : MultiValueConverter<(double, double)[]>
	{
		private readonly Random _random = new Random();

		public int Width { get; set; }

		protected override (double, double)[] Convert(MultiValueConverterProvider valueProvider)
		{
			if (!valueProvider.TryGet<IWave>(0, out var wave) ||
				!valueProvider.TryGet<double>(1, out var from) ||
				!valueProvider.TryGet<double>(2, out var to))
				return null;

			return Probe(wave, from, to);
		}

		private (double, double)[] Probe(IWave wave, double from, double to)
		{
			var values = PrepareBuffer();

			for (int i = 0; i < Width; i++)
			{
				var (min, max) = values[i];

				for (int probe = 0; probe < 500; probe++)
				{
					var sample = wave.Probe(from + (i + _random.NextDouble()) / Width * (to - from));

					min = Math.Min(min, sample);
					max = Math.Max(max, sample);
				}

				values[i] = (min, max);
			}

			return values;
		}

		private (double, double)[] PrepareBuffer()
		{
			return Enumerable.Repeat((double.MaxValue, double.MinValue), Width).ToArray();
		}

		protected override object[] ConvertBack((double, double)[] value)
		{
			throw new NotSupportedException();
		}
	}
}
