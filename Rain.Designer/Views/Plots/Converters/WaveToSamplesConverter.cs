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
	internal class WaveToSamplesConverter : ValueConverter<IWave, IEnumerable<Point>>
	{
		public override IEnumerable<Point> Convert(IWave value)
		{
			if (value == null)
				return null;

			var points = new List<Point>(300);

			for (int i = 0; i < 300; i++)
				points.Add(new Point(i, value.Probe(i) * 200));

			return points;
		}

		public override IWave ConvertBack(IEnumerable<Point> value)
		{
			throw new NotSupportedException();
		}
	}
}
