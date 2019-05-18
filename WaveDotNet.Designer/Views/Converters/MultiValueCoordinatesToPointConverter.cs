using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class MultiValueCoordinatesToPointConverter : MultiValueConverter<Point>
	{
		protected override Point Convert(MultiValueConverterProvider valueProvider)
		{
			return new Point(
				valueProvider.Get<double>(0), 
				valueProvider.Get<double>(1));
		}

		protected override object[] ConvertBack(Point value)
		{
			return new object[] {
				value.X,
				value.Y
			};
		}
	}
}
