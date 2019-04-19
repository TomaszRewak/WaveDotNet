using Rain.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.Views.Converters
{
	internal class FloatToStringConverter : ValueConverter<float, string>
	{
		public override string Convert(float value)
		{
			return value.ToString();
		}

		public override float ConvertBack(string value)
		{
			return float.Parse(value);
		}
	}
}
