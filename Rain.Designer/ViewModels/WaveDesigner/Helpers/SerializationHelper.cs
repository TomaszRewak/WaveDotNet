using Rain.Designer.ViewModels.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.WaveDesigner.Helpers
{
	internal class SerializationHelper
	{
		private readonly Func<NodeViewModel> _nodeFactory;

		public SerializationHelper(Func<NodeViewModel> nodeFactory)
		{
			_nodeFactory = nodeFactory;
		}

		public dynamic Serialize(WaveDesignerViewModel viewModel)
		{
			return new
			{
				Nodes = viewModel.TreeDesigner.Nodes.Select(node => node.Serialize())
			};
		}

		private dynamic SerializeNodes(TreeDesignerViewModel tree)
		{
			return tree.Nodes.Select(node => node.Serialize());
		}

		public void Deserialize(WaveDesignerViewModel viewModel, dynamic value)
		{
			viewModel.TreeDesigner.Nodes = (value.Nodes as IEnumerable<dynamic>)
				.Select(nodeDescription => (NodeViewModel)DeserializeNode(nodeDescription))
				.ToList();
		}

		private NodeViewModel DeserializeNode(dynamic value)
		{
			var node = _nodeFactory();
			node.Deserialize(value);
			return node;
		}
	}
}
