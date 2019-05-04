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

		private readonly DependencyPropertyKey MouseDownPositionProperty = RegisterReadOnly<Position>(nameof(MouseDownPosition));
		public Position MouseDownPosition
		{
			get => GetValue<Position>(MouseDownPositionProperty.DependencyProperty);
			set => SetValue(MouseDownPositionProperty, value);
		}

		private readonly DependencyPropertyKey DraggedDistanceProperty = RegisterReadOnly<double>(nameof(DraggedDistance));
		public double DraggedDistance
		{
			get => GetValue<double>(DraggedDistanceProperty.DependencyProperty);
			set => SetValue(DraggedDistanceProperty, value);
		}

		private readonly DependencyPropertyKey IsPressingProperty = RegisterReadOnly<bool>(nameof(IsPressing));
		public bool IsPressing
		{
			get => GetValue<bool>(IsPressingProperty.DependencyProperty);
			set => SetValue(IsPressingProperty, value);
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
			DraggedDistance += 
				Math.Abs(MouseDownPosition.X - MousePosition.X) + 
				Math.Abs(MouseDownPosition.Y - MousePosition.Y);

			NodesContainer.Margin = new Thickness()
			{
				Left = NodesContainer.Margin.Left - MouseDownPosition.X + MousePosition.X,
				Top = NodesContainer.Margin.Top - MouseDownPosition.Y + MousePosition.Y,
			};
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

			if (IsPressing)
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
			IsPressing = true;
			DraggedDistance = 0;
			MouseDownPosition = MousePosition;
		}

		private void MouseLeftButtonUpOverCanvas(object sender, MouseButtonEventArgs e)
		{
			if (IsPressing && DraggedDistance < 5)
				(DataContext as TreeDesignerViewModel)?.AddNodeCommand.Execute(MousePosition);

			NodesContainer.ReleaseMouseCapture();
			IsPressing = false;
		}

		private void MouseWheelOverCanvas(object sender, MouseWheelEventArgs e)
		{
			ZoomIn(e.Delta > 0 ? 1.1 : 1 / 1.1);
		}
	}
}
