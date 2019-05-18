using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace WaveDotNet.Designer.Views.Common
{
	internal class MultiValueConverterProvider
	{
		private readonly object[] _values;

		public MultiValueConverterProvider(object[] values)
		{
			_values = values;
		}

		public T Get<T>(int index)
		{
			if (!(_values[index] is T value))
				throw new InvalidCastException();

			return value;
		}

		public bool TryGet<T>(int index, out T value)
		{
			if (_values[index] is T typedValue)
			{
				value = typedValue;
				return true;
			}
			else
			{
				value = default;
				return false;
			}
		}
	}

	internal abstract class MultiValueConverter<TOut, TParam> : MarkupExtension, IMultiValueConverter
	{
		protected abstract TOut Convert(MultiValueConverterProvider valueProvider, TParam parameter);
		protected abstract object[] ConvertBack(TOut value, TParam parameter);

		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(parameter is TParam typedParameter))
				throw new InvalidCastException();

			return Convert(new MultiValueConverterProvider(values), typedParameter);
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			if (!(value is TOut typedValue))
				throw new InvalidCastException();

			if (!(parameter is TParam typedParameter))
				throw new InvalidCastException();

			return ConvertBack(typedValue, typedParameter);
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}

	internal abstract class MultiValueConverter<TOut> : MarkupExtension, IMultiValueConverter
	{
		protected abstract TOut Convert(MultiValueConverterProvider valueProvider);
		protected abstract object[] ConvertBack(TOut value);

		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return Convert(new MultiValueConverterProvider(values));
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			if (!(value is TOut typedValue))
				throw new InvalidCastException();

			return ConvertBack(typedValue);
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}
}
