using Rain.Designer.DataStructures;
using Rain.Designer.ViewModels.Tree;
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
	/// <summary>
	/// Interaction logic for NodeControl.xaml
	/// </summary>
	internal partial class NodeControl : UserControl
	{
		private System.Drawing.Point _dragStartPoint;
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
			_dragStartPoint = System.Windows.Forms.Control.MousePosition;
			_dragStartPosition = Node.Position;

			DragHandle.CaptureMouse();
			e.Handled = true;
		}

		private void EndDrag(object sender, MouseButtonEventArgs e)
		{
			_dragging = false;

			if (_dragStartPoint == System.Windows.Forms.Control.MousePosition)
				SelectNode?.Invoke(this, null);

			DragHandle.ReleaseMouseCapture();
			e.Handled = true;
		}

		private void Drag(object sender, MouseEventArgs e)
		{
			if (!_dragging)
				return;

			var dragCurrentPoint = System.Windows.Forms.Control.MousePosition;

			Node.Position = new Position(
				_dragStartPosition.X + dragCurrentPoint.X - _dragStartPoint.X,
				_dragStartPosition.Y + dragCurrentPoint.Y - _dragStartPoint.Y);

			e.Handled = true;
		}

		public event EventHandler SelectNode;
	}
}
