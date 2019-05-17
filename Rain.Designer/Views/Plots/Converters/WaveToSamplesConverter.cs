using Rain.Designer.Views.Common;
using Rain.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rain.Designer.Views.Plots.Converters
{
	internal class WaveToSamplesConverter : MultiValueConverter<(double, double)[]>
	{
		public int SampleRate { get; set; }
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

			for (var time = from; time < to; time += 1.0 / SampleRate)
			{
				var sample = wave.Probe(time);
				var index = (int)(Width * (time - from) / (to - from));

				var (min, max) = values[index];
				values[index] = (Math.Min(min, sample), Math.Max(max, sample));
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
