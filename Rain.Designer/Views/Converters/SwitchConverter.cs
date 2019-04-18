using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Rain.Designer.Views.Converters
{
	internal class CaseConverter
	{
		public object Case { get; set; }
		public object Value { get; set; }
	}

	internal class SwitchConverter : List<CaseConverter>, IValueConverter
	{
		public object Default { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			foreach (var c in this)
				if (object.Equals(value, c.Case))
					return c.Value;

			return Default;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
