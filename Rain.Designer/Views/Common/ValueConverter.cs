using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Rain.Designer.Views.Common
{
	internal abstract class ValueConverter<TIn, TOut, TParam> : IValueConverter
	{
		public abstract TOut Convert(TIn value, TParam parameter);
		public abstract TIn ConvertBack(TOut value, TParam parameter);

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is TIn typedValue))
				throw new InvalidCastException();

			if (!(parameter is TParam typedParameter))
				throw new InvalidCastException();

			return Convert(typedValue, typedParameter);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is TOut typedValue))
				throw new InvalidCastException();

			if (!(parameter is TParam typedParameter))
				throw new InvalidCastException();

			return ConvertBack(typedValue, typedParameter);
		}
	}

	internal abstract class ValueConverter<TIn, TOut> : IValueConverter
	{
		public abstract TOut Convert(TIn value);
		public abstract TIn ConvertBack(TOut value);

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is TIn typedValue))
				throw new InvalidCastException();

			return Convert(typedValue);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is TOut typedValue))
				throw new InvalidCastException();

			return ConvertBack(typedValue);
		}
	}
}
