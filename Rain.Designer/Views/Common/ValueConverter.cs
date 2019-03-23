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
				return null;

			if (!(parameter is TParam typedParameter))
				return null;

			return Convert(typedValue, typedParameter);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is TOut typedValue))
				return null;

			if (!(parameter is TParam typedParameter))
				return null;

			return ConvertBack(typedValue, typedParameter);
		}
	}

	internal abstract class ValueConverter<TIn, TOut> : ValueConverter<TIn, TOut, object>
	{
		public abstract TOut Convert(TIn value);
		public abstract TIn ConvertBack(TOut value);

		public override TOut Convert(TIn value, object parameter) => Convert(value);

		public override TIn ConvertBack(TOut value, object parameter) => ConvertBack(value);
	}
}
