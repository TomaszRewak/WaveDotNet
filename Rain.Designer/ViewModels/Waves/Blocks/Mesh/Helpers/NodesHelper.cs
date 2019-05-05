using Rain.Designer.DataStructures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Waves.Blocks.Mesh.Helpers
{
	internal class NodesHelper
	{
		private readonly Func<NodeViewModel> _nodeFactory;

		public NodesHelper(Func<NodeViewModel> nodeFactory)
		{
			_nodeFactory = nodeFactory;
		}

		public IReadOnlyCollection<NodeViewModel> RemoveNode(IReadOnlyCollection<NodeViewModel> nodes, MeshPoint meshPoint)
		{
			Debug.Assert(nodes.Select(node => node.Position).Contains(meshPoint));

			return nodes
				.Where(node => node.Position != meshPoint)
				.ToList();
		}

		public IReadOnlyCollection<NodeViewModel> AddNode(IReadOnlyCollection<NodeViewModel> nodes, MeshPoint meshPoint)
		{
			Debug.Assert(!nodes.Select(node => node.Position).Contains(meshPoint));

			var newNode = _nodeFactory();
			newNode.Position = meshPoint;

			return nodes
				.Union(new[] { newNode })
				.ToList();
		}
	}
}
