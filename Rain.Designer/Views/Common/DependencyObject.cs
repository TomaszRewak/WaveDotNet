using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rain.Designer.Views.Common
{
	internal class DependencyObject<Owner> : DependencyObject
	{
		protected static DependencyProperty Register<Property>(string name) => DependencyProperty.Register(
			"Offset",
			typeof(Property),
			typeof(Owner));

		protected T GetValue<T>(DependencyProperty property) => (T)GetValue(property);
	}
}
