using Rain.Designer.DataStructures;
using Rain.Designer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Mesh.Implementation
{
	internal class MeshNodeVM : ViewModel, IMeshNodeVM
	{
		public UnorderedPair<MeshPoint> Position { get; set; }
	}
}
