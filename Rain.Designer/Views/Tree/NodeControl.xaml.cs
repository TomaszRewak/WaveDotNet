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
	internal class NodeControlBase : UserControl<NodeControl>
	{ }

	internal partial class NodeControl : NodeControlBase
	{
		private Point _dragStartPoint;
		private Position _dragStartPosition;
		private bool _dragging;

		public NodeControl()
		{
			InitializeComponent();
		}

		private NodeViewModel Node => DataContext as NodeViewModel;

		private void StartDrag(object sender, MouseButtonEventArgs e)
		{
			_dragging = true;
			_dragStartPoint = Mouse.GetPosition(null);
			_dragStartPosition = Node.Position;

			DragHandle.CaptureMouse();
			e.Handled = true;
		}

		private void EndDrag(object sender, MouseButtonEventArgs e)
		{
			_dragging = false;

			DragHandle.ReleaseMouseCapture();
			e.Handled = true;
		}

		private void Drag(object sender, MouseEventArgs e)
		{
			if (!_dragging)
				return;

			var dragCurrentPoint = Mouse.GetPosition(null);
			var scale = this.TranslatePoint(new Point(1, 0), null).X - this.TranslatePoint(new Point(0, 0), null).X;

			Node.Position = new Position(
				_dragStartPosition.X + (dragCurrentPoint.X - _dragStartPoint.X) / scale,
				_dragStartPosition.Y + (dragCurrentPoint.Y - _dragStartPoint.Y) / scale);

			e.Handled = true;
		}

		private void MouseDownWithin(object sender, MouseButtonEventArgs e)
		{
			e.Handled = true;
		}

		private void TriggerStartConnection(object sender, MouseButtonEventArgs e)
		{
			StartConnection?.Invoke(this, Node);
		}

		private void TriggerEndConnection(object sender, MouseButtonEventArgs e)
		{
			EndConnection?.Invoke(this, Node);
		}

		public event EventHandler<NodeViewModel> StartConnection;
		public event EventHandler<NodeViewModel> EndConnection;
	}
}
