using Rain.Designer.DataStructures;
using Rain.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Rain.Designer.Views.Waves.Blocks.Mesh.Converters
{
	internal class NodePlaceholdersConverter : ValueConverter<IReadOnlyCollection<MeshPoint>, IReadOnlyCollection<MeshPoint>>
	{
		public override IReadOnlyCollection<MeshPoint> Convert(IReadOnlyCollection<MeshPoint> value)
		{
			return value
				.SelectMany(GetNeighbourPoints)
				.Distinct()
				.Where(node => !value.Contains(node))
				.ToList();
		}

		public override IReadOnlyCollection<MeshPoint> ConvertBack(IReadOnlyCollection<MeshPoint> value)
		{
			throw new NotImplementedException();
		}

		private IEnumerable<MeshPoint> GetNeighbourPoints(MeshPoint point)
		{
			yield return new MeshPoint(point.X + 1, point.Y);
			yield return new MeshPoint(point.X - 1, point.Y);
			yield return new MeshPoint(point.X, point.Y + 1);
			yield return new MeshPoint(point.X, point.Y - 1);
		}
	}
}
