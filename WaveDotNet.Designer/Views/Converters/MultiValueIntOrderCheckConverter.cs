using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class MultiValueIntOrderCheckConverter : MarkupExtension, IMultiValueConverter
	{
		public bool Strict { get; set; }

		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			for (int i = 1; i < values.Length; i++)
			{
				if (!(values[i - 1] is int a))
					return false;

				if (!(values[i] is int b))
					return false;

				if (a > b)
					return false;

				if (Strict && a == b)
					return false;
			}

			return true;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}
}
