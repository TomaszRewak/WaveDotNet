using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class ComparisonConverter : ValueConverter<object, bool>
	{
		public object Value { get; set; }

		public override bool Convert(object value)
		{
			return object.Equals(value, Value);
		}

		public override object ConvertBack(bool value)
		{
			throw new NotSupportedException();
		}
	}
}
