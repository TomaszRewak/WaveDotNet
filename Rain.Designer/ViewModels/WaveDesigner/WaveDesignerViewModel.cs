using Rain.Designer.ViewModels.Common;
using Rain.Designer.ViewModels.Mesh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.WaveDesigner
{
	internal class WaveDesignerViewModel : ViewModel
	{
		public MeshViewModel Mesh { get; }

		public WaveDesignerViewModel(MeshViewModel mesh)
		{
			Mesh = mesh;
		}
	}
}
