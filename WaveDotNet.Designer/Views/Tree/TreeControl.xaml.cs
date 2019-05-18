using WaveDotNet.Designer.DataStructures;
using WaveDotNet.Designer.ViewModels.Tree;
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
	internal class TreeControlBase : UserControl<TreeControl>
	{ }

	internal partial class TreeControl : TreeControlBase
	{
		private Position _dragStartPosition;
		private bool _dragRemovedSelection;
		private bool _dragging;
		private bool _dragged;

		public TreeControl()
		{
			InitializeComponent();
		}

		private TreeViewModel Tree => DataContext as TreeViewModel;

		private static readonly DependencyProperty ConnectionNodeProperty = Register<NodeViewModel>(nameof(ConnectionNode));
		public NodeViewModel ConnectionNode
		{
			get => GetValue<NodeViewModel>(ConnectionNodeProperty);
			set => SetValue(ConnectionNodeProperty, value);
		}

		private readonly DependencyPropertyKey MousePositionProperty = RegisterReadOnly<Position>(nameof(MousePosition));
		public Position MousePosition
		{
			get => GetValue<Position>(MousePositionProperty.DependencyProperty);
			set => SetValue(MousePositionProperty, value);
		}

		private readonly DependencyPropertyKey ZoomProperty = RegisterReadOnly<double>(nameof(Zoom), 1);
		public double Zoom
		{
			get => GetValue<double>(ZoomProperty.DependencyProperty);
			set => SetValue(ZoomProperty, value);
		}

		private void UpdateMousePosition()
		{
			var positon = Mouse.GetPosition(NodesContainer);
			MousePosition = new Position(positon.X, positon.Y);
		}

		private void Drag()
		{
			NodesContainer.Margin = new Thickness()
			{
				Left = NodesContainer.Margin.Left - _dragStartPosition.X + MousePosition.X,
				Top = NodesContainer.Margin.Top - _dragStartPosition.Y + MousePosition.Y,
			};

			_dragged = true;
		}

		private void ZoomIn(double factor)
		{
			var newZoom = Math.Min(Math.Max(0.25, Zoom *  factor), 4);
			var mousePosition = Mouse.GetPosition(ScrollContainer);

			NodesContainer.Margin = new Thickness()
			{
				Left = NodesContainer.Margin.Left + (mousePosition.X) * (1 - newZoom / Zoom),
				Top = NodesContainer.Margin.Top + (mousePosition.Y) * (1 - newZoom / Zoom)
			};

			Zoom = newZoom;
		}

		private void MouseMoveOverCanvas(object sender, MouseEventArgs e)
		{
			UpdateMousePosition();

			if (e.LeftButton != MouseButtonState.Pressed)
				ConnectionNode = null;

			if (_dragging)
				Drag();
		}

		private void StartConnection(object sender, NodeViewModel node)
		{
			ConnectionNode = node;
		}

		private void EndConnection(object sender, NodeViewModel e)
		{
			if (ConnectionNode == null)
				return;

			if (ConnectionNode.AddInputCommand.CanExecute(e))
				ConnectionNode.AddInputCommand.Execute(e);

			ConnectionNode = null;
		}

		private void MouseLeftButtonDownOverCanvas(object sender, MouseButtonEventArgs e)
		{
			NodesContainer.CaptureMouse();

			_dragging = true;
			_dragged = false;
			_dragStartPosition = MousePosition;
			_dragRemovedSelection = Tree.SelectedNode != null;

			Tree.SelectedNode = null;
		}

		private void MouseLeftButtonUpOverCanvas(object sender, MouseButtonEventArgs e)
		{
			if (!_dragging)
				return;

			if (!_dragRemovedSelection && !_dragged)
				Tree.AddNodeCommand.Execute(MousePosition);

			_dragging = false;

			NodesContainer.ReleaseMouseCapture();
		}

		private void MouseWheelOverCanvas(object sender, MouseWheelEventArgs e)
		{
			ZoomIn(e.Delta > 0 ? 1.1 : 1 / 1.1);
		}
	}
}
