using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WaveDotNet.Designer.Views.Common
{
	internal class UserControl<Owner> : UserControl
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

		protected static DependencyPropertyKey RegisterReadOnly<T>(string name, T defaultValue = default(T)) => DependencyProperty.RegisterReadOnly(
			name,
			typeof(T),
			typeof(Owner),
			new PropertyMetadata(defaultValue));

		protected static RoutedEvent RegisterEvent(string name, RoutingStrategy routingStrategy) => EventManager.RegisterRoutedEvent(
			name,
			routingStrategy,
			typeof(RoutedEventArgs),
			typeof(Owner));

		protected T GetValue<T>(DependencyProperty property) => (T)GetValue(property);

		protected void RaiseEvent(RoutedEvent eventToRise) => RaiseEvent(new RoutedEventArgs(eventToRise));
	}
}
