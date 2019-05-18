using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WaveDotNet.Designer.Views.Common
{
	internal class DependencyObject<Owner> : DependencyObject
	{
		protected static DependencyProperty Register<T>(string name, T defaultValue = default(T)) => DependencyProperty.Register(
			name,
			typeof(T),
			typeof(Owner),
			new PropertyMetadata(defaultValue));

		protected static DependencyProperty Register<T>(string name, Action<Owner> propertyChangedCallback, T defaultValue = default(T)) => DependencyProperty.Register(
			name,
			typeof(T),
			typeof(Owner),
			new PropertyMetadata(defaultValue, (sender, arg) =>
			{
				if (!(sender is Owner owner))
					throw new InvalidCastException();

				propertyChangedCallback(owner);
			}));

		protected T GetValue<T>(DependencyProperty property) => (T)GetValue(property);
	}
}
