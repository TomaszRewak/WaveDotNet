﻿using Rain.Designer.DataStructures;
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

		public dynamic Save(MeshBlockViewModel mesh)
		{
			return new
			{
				Nodes = mesh.Nodes.Select(node => new
				{
					node.InitialVelocity,
					node.Input,
					node.IsOutput,
					node.Mass,
					node.Position.X,
					node.Position.Y
				}),
				Connections = mesh.Connections.Select(connection => new
				{
					X1 = connection.PointA.X,
					Y1 = connection.PointA.Y,
					X2 = connection.PointA.X,
					Y2 = connection.PointA.Y,
					connection.Stiffness
				})
			};
		}

		public void Load(MeshBlockViewModel mesh, dynamic value)
		{
			mesh.Nodes = (value.Nodes as IEnumerable<dynamic>)
				.Select(LoadNode)
				.ToList();

			foreach (var connection in value.Connections)
				mesh.Connections
					.Where(c => c.Ends.Contains(new MeshPoint((int)connection.X1, (int)connection.Y1)) && c.Ends.Contains(new MeshPoint((int)connection.X2, (int)connection.Y2)))
					.First()
					.Stiffness = connection.Stiffness;
		}

		private NodeViewModel LoadNode(dynamic value)
		{
			var node = _nodeFactory();

			node.InitialVelocity = value.InitialVelocity;
			node.Input = value.Input;
			node.IsOutput = value.IsOutput;
			node.Mass = value.Mass;
			node.Position = new MeshPoint((int)value.X, (int)value.Y);

			return node;
		}
	}
}