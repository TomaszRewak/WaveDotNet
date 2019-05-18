using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WaveDotNet.Designer.Views.Plots.Converters
{
	internal class SamplesToPathConverter : ValueConverter<(double, double)[], PathGeometry>
	{
		public int Height { get; set; }

		public override PathGeometry Convert((double, double)[] values)
		{
			if (values == null)
				return null;

			return new PathGeometry
			{
				Figures = new PathFigureCollection {
					new PathFigure
					{
						StartPoint = GetStartingPoint(values),
						IsClosed = true,
						Segments = new PathSegmentCollection(
							new Point[] { }
								.Concat(GetUpperBound(values))
								.Concat(GetLowerBound(values))
								.Select(point => new LineSegment(point, true)))
					}
				}
			};
		}

		private Point GetStartingPoint((double, double)[] values) =>
			new Point(0, -values[0].Item2);

		private IEnumerable<Point> GetUpperBound((double, double)[] values) =>
			values.Skip(1).Select((v, i) => new Point(i + 1, -v.Item2));

		private IEnumerable<Point> GetLowerBound((double, double)[] values) =>
			values.Select((v, i) => new Point(i, -v.Item1)).Reverse();

		public override (double, double)[] ConvertBack(PathGeometry value)
		{
			throw new NotImplementedException();
		}
	}
}
