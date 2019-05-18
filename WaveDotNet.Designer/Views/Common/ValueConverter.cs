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
	internal abstract class ValueConverter<TIn, TOut, TParam> : MarkupExtension, IValueConverter
	{
		protected abstract TOut Convert(TIn value, TParam parameter);
		protected abstract TIn ConvertBack(TOut value, TParam parameter);

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(parameter is TParam typedParameter))
				throw new InvalidCastException();

			if (value == null)
				return Convert(default, typedParameter);

			if (!(value is TIn typedValue))
				throw new InvalidCastException();

			return Convert(typedValue, typedParameter);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{

			if (!(parameter is TParam typedParameter))
				throw new InvalidCastException();

			if (value == null)
				return ConvertBack(default, typedParameter);

			if (!(value is TOut typedValue))
				throw new InvalidCastException();

			return ConvertBack(typedValue, typedParameter);
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}

	internal abstract class ValueConverter<TIn, TOut> : MarkupExtension, IValueConverter
	{
		public abstract TOut Convert(TIn value);
		public abstract TIn ConvertBack(TOut value);

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return Convert(default);

			if (!(value is TIn typedValue))
				throw new InvalidCastException();

			return Convert(typedValue);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return ConvertBack(default);

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
