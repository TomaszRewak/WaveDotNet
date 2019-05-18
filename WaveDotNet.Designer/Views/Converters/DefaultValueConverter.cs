using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class DefaultValueConverter : ValueConverter<object, object>
	{
		public object DefaultValue { get; set; }

		public override object Convert(object value)
		{
			return value ?? DefaultValue;
		}

		public override object ConvertBack(object value)
		{
			throw new NotSupportedException();
		}
	}
}
