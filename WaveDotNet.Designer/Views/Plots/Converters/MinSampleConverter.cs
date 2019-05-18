using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Views.Plots.Converters
{
    internal class MinSampleConverter : ValueConverter<(double, double)[], double>
	{
		public override double Convert((double, double)[] value)
		{
			return value?.Min(sample => sample.Item1) ?? 0;
		}

		public override (double, double)[] ConvertBack(double value)
		{
			throw new NotImplementedException();
		}
	}
}
