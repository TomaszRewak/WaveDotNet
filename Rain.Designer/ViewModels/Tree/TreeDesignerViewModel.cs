using Rain.Designer.DataStructures;
using Rain.Designer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rain.Designer.ViewModels.Tree
{
    internal class TreeDesignerViewModel : ViewModel
    {
		private Func<NodeViewModel> _nodeFactory;

		public TreeDesignerViewModel(Func<NodeViewModel> nodeFactory)
		{
			_nodeFactory = nodeFactory;
		}

		private IReadOnlyCollection<NodeViewModel> _nodes = new List<NodeViewModel>();
		public IReadOnlyCollection<NodeViewModel> Nodes
		{
			get => _nodes;
			set => Set(ref _nodes, value)
				.Then(UpdateSelectedNode);
		}

		private NodeViewModel _selectedNode;
		public NodeViewModel SelectedNode
		{
			get => _selectedNode;
			set => Set(ref _selectedNode, value);
		}

		private void UpdateSelectedNode()
		{
			if (!Nodes.Contains(SelectedNode))
				SelectedNode = null;
		}

		private void AddNode(Position position)
		{
			var newNode = _nodeFactory();
			newNode.Position = position;

			Nodes = Nodes
				.Concat(new[] { newNode })
				.ToList();

			SelectedNode = newNode;
		}

		private void SelectNode(NodeViewModel node)
		{
			this.SelectedNode = node;
		}

		private void RemoveNode(NodeViewModel node)
		{
			this.Nodes = Nodes
				.Except(new[] { node })
				.ToList();
		}

		public ICommand AddNodeCommand => new Command<Position>(AddNode);
		public ICommand SelectNodeCommand => new Command<NodeViewModel>(SelectNode);
		public ICommand RemoveNodeCommand => new Command<NodeViewModel>(RemoveNode);
    }
}
