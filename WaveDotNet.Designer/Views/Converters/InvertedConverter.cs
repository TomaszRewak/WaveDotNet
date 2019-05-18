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
	internal class InvertedConverter : MarkupExtension, IValueConverter
	{
		public IValueConverter Converter { get; set; }

		public InvertedConverter()
		{ }

		public InvertedConverter(IValueConverter converter)
		{
			Converter = converter;
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Converter.ConvertBack(value, targetType, parameter, culture);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Converter.Convert(value, targetType, parameter, culture);
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}
}
