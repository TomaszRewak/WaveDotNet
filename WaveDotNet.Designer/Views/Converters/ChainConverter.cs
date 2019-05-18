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
	[ContentProperty(nameof(Converter))]
	internal class ChainedConverter
	{
		public IValueConverter Converter { get; set; }
		public object ConverterParameter { get; set; }

		public object Convert(object value, CultureInfo culture)
		{
			return Converter.Convert(value, null, ConverterParameter, culture);
		}

		public object ConvertBack(object value, CultureInfo culture)
		{
			return Converter.ConvertBack(value, null, ConverterParameter, culture);
		}
	}

	internal class ChainConverter : List<ChainedConverter>, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			foreach (var converter in this)
				value = converter.Convert(value, culture);
			
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			foreach (var converter in (this as IEnumerable<ChainedConverter>).Reverse())
				value = converter.ConvertBack(value, culture);

			return value;
		}
	}
}
