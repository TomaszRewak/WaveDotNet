using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Mesh
{
	internal struct NodeState
	{
		public NodeState(double position, double velocity)
		{
			Position = position;
			Velocity = velocity;
		}

		public double Position { get; }
		public double Velocity { get; }
	}
}
