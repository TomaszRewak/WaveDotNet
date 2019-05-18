using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class NullableToBooleanConverter : ValueConverter<object, bool>
	{
		public override bool Convert(object value)
		{
			return value != null;
		}

		public override object ConvertBack(bool value)
		{
			throw new NotSupportedException();
		}
	}
}
