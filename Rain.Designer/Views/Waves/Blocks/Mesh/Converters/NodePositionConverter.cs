using Rain.Designer.DataStructures;
using Rain.Designer.ViewModels.Waves.Blocks.Mesh;
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
	internal class NodePositionConverter : ValueConverter<IReadOnlyCollection<NodeViewModel>, IReadOnlyCollection<MeshPoint>>
	{
		public override IReadOnlyCollection<MeshPoint> Convert(IReadOnlyCollection<NodeViewModel> value)
		{
			return value
				.Select(node => node.Position)
				.ToList();
		}

		public override IReadOnlyCollection<NodeViewModel> ConvertBack(IReadOnlyCollection<MeshPoint> value)
		{
			throw new NotImplementedException();
		}
	}
}
