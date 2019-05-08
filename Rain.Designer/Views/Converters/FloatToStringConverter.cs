using Rain.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.Views.Converters
{
	internal class DoubleToStringConverter : ValueConverter<double, string>
	{
		public override string Convert(double value)
		{
			return value.ToString();
		}

		public override double ConvertBack(string value)
		{
			return double.Parse(value.Replace(',', '.'), CultureInfo.InvariantCulture);
		}
	}
}
