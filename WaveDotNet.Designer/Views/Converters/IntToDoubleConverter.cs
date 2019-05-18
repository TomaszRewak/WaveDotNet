using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class IntToDoubleConverter : ValueConverter<int, double>
	{
		public override double Convert(int value)
		{
			return value;
		}

		public override int ConvertBack(double value)
		{
			throw new NotSupportedException();
		}
	}
}
