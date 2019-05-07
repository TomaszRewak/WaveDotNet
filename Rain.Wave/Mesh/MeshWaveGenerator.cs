using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Rain.Wave.Mesh
{
	public class MeshWaveGenerator : IWave
	{
		public Node[] Nodes { get; set; }

		public double Probe(double time)
		{
			foreach (var node in Nodes)
				node.Initialize(time);

			foreach (var node in Nodes)
				node.PrepareNextState(time);

			foreach (var node in Nodes)
				node.UpdateCurrentState();

			double output = 0;
			foreach (var node in Nodes)
				if (node.IsOutput)
					output += node.CurrentPosition;

			return output;
		}
	}
}
