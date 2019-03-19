using Rain.Designer.DataStructures;
using Rain.Designer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Mesh
{
	internal class MeshVM : ViewModel
	{
		private IReadOnlyCollection<MeshNodeVM> _nodes = new List<MeshNodeVM>();
		public IReadOnlyCollection<MeshNodeVM> Nodes
		{
			get => _nodes;
			private set => Set(ref _nodes, value).Then(UpdateConnections);
		}

		private IReadOnlyCollection<MeshConnectionVM> _connections = new List<MeshConnectionVM>();
		public IReadOnlyCollection<MeshConnectionVM> Connections
		{
			get => _connections;
			private set => Set(ref _connections, value);
		}

		private IEnumerable<UnorderedPair<MeshPoint>> GetPotentialConnections(MeshPoint point)
		{
			yield return new UnorderedPair<MeshPoint>(point, new MeshPoint(point.X + 1, point.Y));
			yield return new UnorderedPair<MeshPoint>(point, new MeshPoint(point.X - 1, point.Y));
			yield return new UnorderedPair<MeshPoint>(point, new MeshPoint(point.X, point.Y + 1));
			yield return new UnorderedPair<MeshPoint>(point, new MeshPoint(point.X, point.Y - 1));
		}

		private void UpdateConnections()
		{
			var points = this.Nodes
				.Select(node => node.Position)
				.ToList();

			var requiredConnections = points
				.SelectMany(GetPotentialConnections)
				.Distinct()
				.Where(connection => connection.All(points.Contains))
				.ToList();

			var validConnections = Connections
				.Where(connection => requiredConnections.Contains(connection.Connection))
				.ToList();

			var newConnections = requiredConnections
				.Except(validConnections.Select(connection => connection.Connection))
				.Select(connection => new MeshConnectionVM()
				{
					Connection = connection
				})
				.ToList();

			Connections = validConnections.Union(newConnections).ToList();
		}
	}
}
