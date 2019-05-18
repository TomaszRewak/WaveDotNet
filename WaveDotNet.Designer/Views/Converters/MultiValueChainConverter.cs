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
	internal class MultiValueChainConverter : MarkupExtension, IMultiValueConverter
	{
		public IValueConverter PreProcessing { get; set; } = new ChainConverter();
		public IMultiValueConverter MultiValueConverter { get; set; }
		public IValueConverter PostProcessing { get; set; } = new ChainConverter();

		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			for (int i = 0; i < values.Length; i++)
				values[i] = PreProcessing.Convert(values[i], null, null, culture);

			var value = MultiValueConverter.Convert(values, null, parameter, culture);

			return PostProcessing.Convert(value, null, null, culture);
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{

			value = PostProcessing.ConvertBack(value, null, null, culture);

			var values = MultiValueConverter.ConvertBack(value, null, parameter, culture);

			for (int i = 0; i < values.Length; i++)
				values[i] = PreProcessing.ConvertBack(values[i], null, null, culture);

			return values;
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}
}
