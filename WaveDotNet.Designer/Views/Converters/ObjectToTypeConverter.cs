using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class ObjectToTypeConverter : ValueConverter<object, Type>
	{
		public override Type Convert(object value)
		{
			return value?.GetType();
		}

		public override object ConvertBack(Type value)
		{
			throw new NotSupportedException();
		}
	}
}
