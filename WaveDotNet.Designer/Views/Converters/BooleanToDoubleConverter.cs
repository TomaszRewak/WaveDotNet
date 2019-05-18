using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class BooleanToDoubleConverter : ValueConverter<bool, double>
	{
		public double True { get; set; }
		public double False { get; set; }

		public override double Convert(bool value)
		{
			return value
				? True
				: False;
		}

		public override bool ConvertBack(double value)
		{
			throw new NotSupportedException();
		}
	}
}
