using Rain.Designer.DataStructures;
using Rain.Designer.ViewModels.Common;
using Rain.Designer.ViewModels.Waves.Blocks.Mesh.Helpers;
using Rain.Wave;
using Rain.Wave.Mesh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rain.Designer.ViewModels.Waves.Blocks.Mesh
{
	internal class MeshBlockViewModel : WaveBlockViewModel
	{
		private readonly NodesHelper _nodesHelper;
		private readonly ConnectionsHelper _connectionsHelper;

		public MeshBlockViewModel(
			NodesHelper nodesHelper,
			ConnectionsHelper connectionsHelper) : base(0, int.MaxValue)
		{
			_nodesHelper = nodesHelper;
			_connectionsHelper = connectionsHelper;

			Nodes = new[] {
				new NodeViewModel() { Position = new MeshPoint(2, 2) },
				new NodeViewModel() { Position = new MeshPoint(2, 3) },
				new NodeViewModel() { Position = new MeshPoint(3, 3) }
			};
		}

		private IReadOnlyCollection<NodeViewModel> _nodes = new List<NodeViewModel>();
		public IReadOnlyCollection<NodeViewModel> Nodes
		{
			get => _nodes;
			private set => Set(ref _nodes, value)
				.Then(UpdateConnections)
				.Then(UpdateSelectedNode);
		}

		private IReadOnlyCollection<ConnectionViewModel> _connections = new List<ConnectionViewModel>();
		public IReadOnlyCollection<ConnectionViewModel> Connections
		{
			get => _connections;
			private set => Set(ref _connections, value);
		}

		private NodeViewModel _selectedNode = null;
		public NodeViewModel SelectedNode
		{
			get => _selectedNode;
			private set => Set(ref _selectedNode, value);
		}

		private void UpdateConnections()
		{
			Connections = _connectionsHelper.UpdateConnections(Nodes, Connections);
		}

		private void UpdateSelectedNode()
		{
			if (!Nodes.Contains(SelectedNode))
				SelectedNode = null;
		}

		private void AddNode(MeshPoint meshPoint)
		{
			Nodes = _nodesHelper.AddNode(Nodes, meshPoint);
		}

		private void RemoveNode(MeshPoint meshPoint)
		{
			Nodes = _nodesHelper.RemoveNode(Nodes, meshPoint);
		}

		private void SelectNode(MeshPoint meshPoint)
		{
			SelectedNode = Nodes.FirstOrDefault(node => node.Position == meshPoint);
		}

		public override IWave GenerateWave(IWave[] inputs)
		{
			var nodes = Nodes
				.ToDictionary(
					node => node.Position,
					node => new Node
					{
						Input = node.Input.HasValue ? inputs[node.Input.Value] : null,
						IsOutput = node.IsOutput,
						Mass = node.Mass
					});

			foreach (var node in nodes)
				node.Value.Connections = Connections
					.Where(connection => connection.Ends.Contains(node.Key))
					.Select(connection => new Connection
					{
						Stiffness = connection.Stiffness,
						Target = nodes[connection.Ends.Second(node.Key)]
					})
					.ToArray();

			return new MeshWaveGenerator
			{
				Nodes = nodes
					.Select(node => node.Value)
					.ToArray()
			};
		}

		public ICommand AddNodeCommand => new Command<MeshPoint>(AddNode);
		public ICommand RemoveNodeCommand => new Command<MeshPoint>(RemoveNode);
		public ICommand SelectNodeCommand => new Command<MeshPoint>(SelectNode);
	}
}
