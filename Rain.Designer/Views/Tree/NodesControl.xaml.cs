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
		private static readonly DependencyProperty ConnectionNodeProperty = Register<NodeViewModel>(nameof(ConnectionNode));
		public NodeViewModel ConnectionNode
		{
			get => GetValue<NodeViewModel>(ConnectionNodeProperty);
			set => SetValue(ConnectionNodeProperty, value);
		}

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

			if (e.LeftButton != MouseButtonState.Pressed)
				ConnectionNode = null;
		}

		private void NodeControl_StartConnection(object sender, NodeViewModel node)
		{
			ConnectionNode = node;
		}

		private void NodeControl_EndConnection(object sender, NodeViewModel e)
		{
			if (ConnectionNode == null)
				return;

			if (ConnectionNode.AddInputCommand.CanExecute(e))
				ConnectionNode.AddInputCommand.Execute(e);

			ConnectionNode = null;
		}
	}
}
