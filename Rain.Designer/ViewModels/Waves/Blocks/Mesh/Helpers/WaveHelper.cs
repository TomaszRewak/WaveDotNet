using Rain.Designer.DataStructures;
using Rain.Wave;
using Rain.Wave.Mesh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Waves.Blocks.Mesh.Helpers
{
    internal class WaveHelper
    {
		public IWave GenerateWave(MeshBlockViewModel mesh, IWave[] inputs)
		{
			var nodes = mesh
				.Nodes
				.ToDictionary(
					node => node.Position,
					node => GenerateNode(node, inputs));

			foreach (var node in nodes)
				node.Value.Connections = mesh.Connections
					.Where(connection => connection.Ends.Contains(node.Key))
					.Select(connection => GenerateConnection(connection, nodes[connection.Ends.Second(node.Key)]))
					.ToArray();

			return new MeshWaveGenerator
			{
				Nodes = nodes
					.Select(node => node.Value)
					.ToArray()
			};
		}

		private Node GenerateNode(NodeViewModel node, IWave[] inputs)
		{
			return new Node
			{
				Input = node.Input.HasValue ? inputs[node.Input.Value] : null,
				IsOutput = node.IsOutput,
				Mass = node.Mass,
				InitialVelocity = node.InitialVelocity
			};
		}

		private Connection GenerateConnection(ConnectionViewModel connection, Node node)
		{
			return new Connection
			{
				Stiffness = connection.Stiffness,
				Target = node
			};
		}
	}
}
