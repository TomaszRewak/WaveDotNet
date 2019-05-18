using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class DoubleAddConverter : ValueConverter<double, double>
	{
		public double Value { get; set; }

		public override double Convert(double value)
		{
			return value + Value;
		}

		public override double ConvertBack(double value)
		{
			return value - Value;
		}
	}
}
