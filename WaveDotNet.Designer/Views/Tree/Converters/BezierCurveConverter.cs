using WaveDotNet.Designer.DataStructures;
using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WaveDotNet.Designer.Views.Tree.Converters
{
	internal class BezierCurveConverter : MultiValueConverter<Geometry>
	{
		public double InputsDistance { get; set; }

		public double InputsXOffset { get; set; }
		public double InputsYOffset { get; set; }

		public double OutputYOffset { get; set; }

		protected override Geometry Convert(MultiValueConverterProvider valueProvider)
		{
			var begin = valueProvider.Get<Position>(0);
			var end = valueProvider.Get<Position>(1);
			var index = valueProvider.Get<int>(2);

			begin = new Position(
				begin.X + InputsXOffset + index * InputsDistance,
				begin.Y + InputsYOffset);

			end = new Position(
				end.X,
				end.Y + OutputYOffset);

			return new PathGeometry
			{
				Figures = new PathFigureCollection {
					new PathFigure
					{
						StartPoint = new System.Windows.Point(begin.X, begin.Y),
						IsClosed = false,
						Segments = new PathSegmentCollection {
							new BezierSegment
							{
								Point1 = new System.Windows.Point(begin.X, end.Y),
								Point2 = new System.Windows.Point(end.X, begin.Y),
								Point3 = new System.Windows.Point(end.X, end.Y)
							}
						}
					}
				}
			};
		}

		protected override object[] ConvertBack(Geometry value)
		{
			throw new NotSupportedException();
		}
	}
}
