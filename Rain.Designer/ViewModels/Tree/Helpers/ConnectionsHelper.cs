using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Tree.Helpers
{
	internal class ConnectionsHelper
	{
		public void UpdateConnections(TreeDesignerViewModel tree)
		{
			foreach (var node in tree.Nodes)
				UpdateConnections(tree, node);
		}

		private void UpdateConnections(TreeDesignerViewModel tree, NodeViewModel node)
		{
			node.Inputs = node
				.Inputs
				.Where(input => tree.Nodes.Contains(input))
				.ToList();
		}
	}
}
