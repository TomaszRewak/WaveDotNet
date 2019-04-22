using Rain.Designer.DataStructures;
using Rain.Designer.ViewModels.Tree;
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
	internal class NodesControlBase : UserControl<NodesControl>
	{ }

	internal partial class NodesControl : NodesControlBase
	{
		public NodesControl()
		{
			InitializeComponent();
		}

		private readonly DependencyPropertyKey MousePositionProperty = RegisterReadOnly<Position>(nameof(MousePosition));
		public Position MousePosition
		{
			get => GetValue<Position>(MousePositionProperty.DependencyProperty);
			set => SetValue(MousePositionProperty, value);
		}

		private void MouseMoveOverCanvas(object sender, MouseEventArgs e)
		{
			var positon = Mouse.GetPosition(sender as IInputElement);

			MousePosition = new Position(positon.X, positon.Y);
		}
	}
}
