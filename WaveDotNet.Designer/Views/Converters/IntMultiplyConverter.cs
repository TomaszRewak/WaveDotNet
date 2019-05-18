using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class IntMultiplyConverter : ValueConverter<int, double>
	{
		public double By { get; set; }

		public override double Convert(int value)
		{
			return value * By;
		}

		public override int ConvertBack(double value)
		{
			return (int)(value / By);
		}
	}
}
