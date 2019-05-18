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
	internal class AsyncMultiValueConverter : MarkupExtension, IMultiValueConverter
	{
		public IMultiValueConverter Converter { get; set; }

		public AsyncMultiValueConverter()
		{ }

		public AsyncMultiValueConverter(IMultiValueConverter converter)
		{
			Converter = converter;
		}

		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var converterResult = new AsyncConverterResult();
			var valuesCopy = values.ToArray();

			Task.Run(() => Process(converterResult, valuesCopy));

			return converterResult;
		}

		private void Process(AsyncConverterResult converterResult, object[] values)
		{
			var result = Converter.Convert(values, null, null, CultureInfo.CurrentCulture);

			converterResult.Dispatcher.Invoke(() =>
			{
				converterResult.Result = result;
			});
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
