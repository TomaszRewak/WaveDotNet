using System;
using System.Collections.Generic;
using System.Text;

namespace Rain.Wave.Mesh
{
	public class Node
	{
		private NodeState _currentState;
		private NodeState _nextState;

		private double? _lastProbeTime;

		public IWave Input { get; set; }

		public bool IsOutput { get; set; }
		public double Mass { get; set; }
		public double InitialVelocity { get; set; }

		public Connection[] Connections { get; set; }

		internal double CurrentPosition => _currentState.Position;

		internal void UpdateCurrentState()
		{
			_currentState = _nextState;
		}

		public void Initialize(double time)
		{
			if (_lastProbeTime.HasValue && _lastProbeTime <= time)
				return;

			_currentState = new NodeState(
				position: 0, 
				velocity: InitialVelocity);

			_lastProbeTime = time;
		}

		internal void PrepareNextState(double time)
		{
			if (Input != null)
				PrepareNextInputState(time);
			else
				PrepareNextFreeFloatingState(time - _lastProbeTime.Value);

			UpdateProbeTimestamp(time);
		}

		private void UpdateProbeTimestamp(double time)
		{
			_lastProbeTime = time;
		}

		private void PrepareNextInputState(double time)
		{
			_currentState = new NodeState(
				position: Input?.Probe(time) ?? 1.0d, 
				velocity: 0);
		}

		private void PrepareNextFreeFloatingState(double timeDifference)
		{
			double force = 0;
			foreach (var connection in Connections)
				force += (connection.Target.CurrentPosition - _currentState.Position) * connection.Stiffness;

			var acceleration = force / Mass;
			var velocity = _currentState.Velocity + acceleration * timeDifference;

			_nextState = new NodeState(
				position: _currentState.Position + velocity * timeDifference,
				velocity: velocity);
		}
	}
}
