using Rain.Designer.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Waves.Blocks.Mesh.Helpers
{
	internal class SerializationHelper
	{
		private readonly Func<NodeViewModel> _nodeFactory;

		public SerializationHelper(Func<NodeViewModel> nodeFactory)
		{
			_nodeFactory = nodeFactory;
		}

		public dynamic Serialize(MeshBlockViewModel mesh)
		{
			return new
			{
				Nodes = mesh.Nodes.Select(node => new
				{
					node.InitialVelocity,
					node.Input,
					node.IsOutput,
					node.Mass,
					Point = new
					{
						node.Position.X,
						node.Position.Y
					}
				}),
				Connections = mesh.Connections.Select(connection => new
				{
					PointA = new
					{
						connection.PointA.X,
						connection.PointA.Y
					},
					PointB = new
					{
						connection.PointA.X,
						connection.PointA.Y
					},
					connection.Stiffness
				})
			};
		}

		public void Deserialize(MeshBlockViewModel mesh, dynamic value)
		{
			mesh.Nodes = (value.Nodes as IEnumerable<dynamic>)
				.Select(DeserializeNode)
				.ToList();

			foreach (var connection in value.Connections)
				mesh.Connections
					.Where(c => c.Ends.Contains((MeshPoint)DeserializePoint(connection.PointA)) && c.Ends.Contains((MeshPoint)DeserializePoint(connection.PointB)))
					.First()
					.Stiffness = connection.Stiffness;
		}

		private NodeViewModel DeserializeNode(dynamic value)
		{
			var node = _nodeFactory();

			node.InitialVelocity = value.InitialVelocity;
			node.Input = value.Input;
			node.IsOutput = value.IsOutput;
			node.Mass = value.Mass;
			node.Position = DeserializePoint(value.Point);

			return node;
		}

		private MeshPoint DeserializePoint(dynamic value)
		{
			return new MeshPoint((int)value.X, (int)value.Y);
		}
	}
}
