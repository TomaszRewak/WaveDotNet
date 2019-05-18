using WaveDotNet.Designer.ViewModels.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.ViewModels.WaveDesigner.Helpers
{
	internal class SerializationHelper
	{
		private readonly Func<NodeViewModel> _nodeFactory;

		public SerializationHelper(Func<NodeViewModel> nodeFactory)
		{
			_nodeFactory = nodeFactory;
		}

		public dynamic Serialize(WaveDesignerViewModel waveDesigner)
		{
			return new
			{
				Nodes = SerializeNodes(waveDesigner.TreeDesigner),
				Connections = SerializeConnections(waveDesigner.TreeDesigner)
			};
		}

		private IEnumerable<dynamic> SerializeNodes(TreeViewModel tree)
		{
			return tree.Nodes.Select(node => node.Serialize());
		}

		private IEnumerable<dynamic> SerializeConnections(TreeViewModel tree)
		{
			var nodes = tree.Nodes.ToList();

			return nodes.SelectMany(node => node.Inputs.Select(connectedNode => new
			{
				From = nodes.IndexOf(node),
				To = nodes.IndexOf(connectedNode)
			}));
		}

		public void Deserialize(WaveDesignerViewModel viewModel, dynamic value)
		{
			viewModel.TreeDesigner.Nodes = (value.Nodes as IEnumerable<dynamic>)
				.Select(nodeDescription => (NodeViewModel)DeserializeNode(nodeDescription))
				.ToList();

			foreach (var connection in value.Connections)
				viewModel.TreeDesigner.Nodes.ElementAt((int)connection.From).AddInput(viewModel.TreeDesigner.Nodes.ElementAt((int)connection.To));
		}

		private NodeViewModel DeserializeNode(dynamic value)
		{
			var node = _nodeFactory();
			node.Deserialize(value);
			return node;
		}
	}
}
