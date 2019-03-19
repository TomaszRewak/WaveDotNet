using Rain.Designer.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Mesh.Helpers
{
	internal class ConnectionsHelper
	{
		private readonly Func<ConnectionViewModel> _connectionFactory;

		public ConnectionsHelper(Func<ConnectionViewModel> connectionFactory)
		{
			_connectionFactory = connectionFactory;
		}

		public IReadOnlyCollection<ConnectionViewModel> UpdateConnections(IReadOnlyCollection<NodeViewModel> nodes, IReadOnlyCollection<ConnectionViewModel> connections)
		{
			var existingPoints = nodes
				.Select(node => node.Position)
				.ToList();

			var requiredConnections = existingPoints
				.SelectMany(GetPotentialConnections)
				.Distinct()
				.Where(connection => connection.All(existingPoints.Contains))
				.ToList();

			var validConnections = connections
				.Where(connection => requiredConnections.Contains(connection.Ends))
				.ToList();

			var newConnections = requiredConnections
				.Except(validConnections.Select(connection => connection.Ends))
				.Select(CreateNewConnection)
				.ToList();

			return validConnections.Union(newConnections).ToList();
		}
		
		private IEnumerable<UnorderedPair<MeshPoint>> GetPotentialConnections(MeshPoint point)
		{
			yield return new UnorderedPair<MeshPoint>(point, new MeshPoint(point.X + 1, point.Y));
			yield return new UnorderedPair<MeshPoint>(point, new MeshPoint(point.X - 1, point.Y));
			yield return new UnorderedPair<MeshPoint>(point, new MeshPoint(point.X, point.Y + 1));
			yield return new UnorderedPair<MeshPoint>(point, new MeshPoint(point.X, point.Y - 1));
		}

		private ConnectionViewModel CreateNewConnection(UnorderedPair<MeshPoint> ends)
		{
			var newConnection = _connectionFactory();
			newConnection.Ends = ends;

			return newConnection;
		}
	}
}
