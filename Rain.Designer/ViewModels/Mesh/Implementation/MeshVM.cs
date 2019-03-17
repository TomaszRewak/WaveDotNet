using Rain.Designer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Mesh.Implementation
{
	internal class MeshVM : ViewModel, IMeshVM
	{
		public IMeshNodeVM[,] Nodes { get; private set; }

		public MeshVM()
		{
			Nodes = new[,] {
				{ new MeshNodeVM() }
			};
		}


	}
}
