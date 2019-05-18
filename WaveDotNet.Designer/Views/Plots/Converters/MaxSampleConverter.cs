using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Views.Plots.Converters
{
	internal class MaxSampleConverter : ValueConverter<(double, double)[], double>
	{
		public override double Convert((double, double)[] value)
		{
			return value?.Max(sample => sample.Item2) ?? 0;
		}

		public override (double, double)[] ConvertBack(double value)
		{
			throw new NotImplementedException();
		}
	}
}
