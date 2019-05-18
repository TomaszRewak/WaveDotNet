using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class DoubleToStringConverter : ValueConverter<double?, string>
	{
		public override string Convert(double? value)
		{
			return value?.ToString(CultureInfo.InvariantCulture);
		}

		public override double? ConvertBack(string value)
		{
			if (value.EndsWith("."))
				return null;
			if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedValue))
				return parsedValue;
			else
				return null;
		}
	}
}
