using Rain.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rain.Designer.Views.Tree
{
	internal class ConnectionControlBase : UserControl<ConnectionControl>
	{ }

	internal partial class ConnectionControl : ConnectionControlBase
	{
		private static readonly DependencyProperty X1Property = Register<double>(nameof(X1));
		public double X1
		{
			get => GetValue<double>(X1Property);
			set => SetValue(X1Property, value);
		}

		private static readonly DependencyProperty Y1Property = Register<double>(nameof(Y1));
		public double Y1
		{
			get => GetValue<double>(Y1Property);
			set => SetValue(Y1Property, value);
		}

		private static readonly DependencyProperty X2Property = Register<double>(nameof(X2));
		public double X2
		{
			get => GetValue<double>(X2Property);
			set => SetValue(X2Property, value);
		}

		private static readonly DependencyProperty Y2Property = Register<double>(nameof(Y2));
		public double Y2
		{
			get => GetValue<double>(Y2Property);
			set => SetValue(Y2Property, value);
		}

		private static readonly DependencyProperty ConnectionIndexProperty = Register<int>(nameof(ConnectionIndex));
		public int ConnectionIndex
		{
			get => GetValue<int>(ConnectionIndexProperty);
			set => SetValue(ConnectionIndexProperty, value);
		}

		public ConnectionControl()
		{
			InitializeComponent();
		}
	}
}
