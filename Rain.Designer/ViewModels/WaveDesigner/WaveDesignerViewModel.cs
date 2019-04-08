using Rain.Designer.ViewModels.Common;
using Rain.Designer.ViewModels.Mesh;
using Rain.Designer.ViewModels.Samples;
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
		public SamplesViewModel Samples { get; }

		public WaveDesignerViewModel(
			MeshViewModel mesh,
			SamplesViewModel samples)
		{
			Mesh = mesh;
			Samples = samples;
		}
	}
}
