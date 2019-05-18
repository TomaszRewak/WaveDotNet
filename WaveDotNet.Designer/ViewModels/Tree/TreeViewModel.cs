using WaveDotNet.Designer.DataStructures;
using WaveDotNet.Designer.ViewModels.Common;
using WaveDotNet.Designer.ViewModels.Tree.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WaveDotNet.Designer.ViewModels.Tree
{
    internal class TreeViewModel : ViewModel
    {
		private Func<NodeViewModel> _nodeFactory;
		private ConnectionsHelper _connectionsHelper;

		public TreeViewModel(
			Func<NodeViewModel> nodeFactory,
			ConnectionsHelper connectionsHelper)
		{
			_nodeFactory = nodeFactory;
			_connectionsHelper = connectionsHelper;
		}

		private IReadOnlyCollection<NodeViewModel> _nodes = new List<NodeViewModel>();
		public IReadOnlyCollection<NodeViewModel> Nodes
		{
			get => _nodes;
			set => Set(ref _nodes, value)
				.Then(UpdateConnections)
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

		private void UpdateConnections()
		{
			_connectionsHelper.UpdateConnections(this);
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
			SelectedNode = node;
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
