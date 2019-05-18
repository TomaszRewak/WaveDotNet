using WaveDotNet.Designer.DataStructures;
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

namespace WaveDotNet.Designer.Views.Tree
{
	internal class ConnectionControlBase : UserControl<ConnectionControl>
	{ }

	internal partial class ConnectionControl : ConnectionControlBase
	{
		private static readonly DependencyProperty BeginProperty = Register<Position>(nameof(Begin));
		public Position Begin
		{
			get => GetValue<Position>(BeginProperty);
			set => SetValue(BeginProperty, value);
		}

		private static readonly DependencyProperty EndProperty = Register<Position>(nameof(End));
		public Position End
		{
			get => GetValue<Position>(EndProperty);
			set => SetValue(EndProperty, value);
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
