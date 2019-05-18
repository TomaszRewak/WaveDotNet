using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class ColorInterpolationConverter : ValueConverter<double, Color>
	{
		public Color From { get; set; }
		public Color To { get; set; }

		public override Color Convert(double value)
		{
			return Color.Add(
				Color.Multiply(From, (float)(1 - value)),
				Color.Multiply(To, (float)value)
				);
		}

		public override double ConvertBack(Color value)
		{
			throw new NotSupportedException();
		}
	}
}
