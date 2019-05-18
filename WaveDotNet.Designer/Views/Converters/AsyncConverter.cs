using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace WaveDotNet.Designer.Views.Converters
{
	[ContentProperty(nameof(Converter))]
	internal class AsyncConverter : ValueConverter<object, AsyncConverterResult>
	{
		public IValueConverter Converter { get; set; }

		public AsyncConverter()
		{ }

		public AsyncConverter(IValueConverter converter)
		{
			Converter = converter;
		}

		public override AsyncConverterResult Convert(object value)
		{
			var converterResult = new AsyncConverterResult();

			Task.Run(() => Process(converterResult, value));

			return converterResult;
		}

		private void Process(AsyncConverterResult converterResult, object value)
		{
			var result = Converter.Convert(value, null, null, CultureInfo.CurrentCulture);

			converterResult.Dispatcher.Invoke(() => {
				converterResult.Result = result;
			});
		}

		public override object ConvertBack(AsyncConverterResult value)
		{
			throw new NotImplementedException();
		}
	}

	internal class AsyncConverterResult : DependencyObject<AsyncConverterResult>
	{
		private static readonly DependencyProperty ResultProperty = Register<object>(nameof(Result));
		public object Result
		{
			get => GetValue<object>(ResultProperty);
			set => SetValue(ResultProperty, value);
		}
	}
}
