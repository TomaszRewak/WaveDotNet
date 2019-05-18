using WaveDotNet.Designer.Views.Common;
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

namespace WaveDotNet.Designer.Views.Tree.Controls
{
	internal class ConnectionHandleControlBase : UserControl<ConnectionHandleControl>
	{ }

	internal partial class ConnectionHandleControl : ConnectionHandleControlBase
	{
		public ConnectionHandleControl()
		{
			InitializeComponent();
		}

		private static readonly DependencyProperty IndexProperty = Register<int>(nameof(Index));
		public int Index
		{
			get => GetValue<int>(IndexProperty);
			set => SetValue(IndexProperty, value);
		}

		private void MouseUpOverDeleteConnection(object sender, MouseButtonEventArgs e)
		{
			DeleteConnection?.Invoke(this, e);
		}

		public event MouseButtonEventHandler DeleteConnection;
	}
}
