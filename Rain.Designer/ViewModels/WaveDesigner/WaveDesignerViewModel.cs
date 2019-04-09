using Rain.Designer.ViewModels.Common;
using Rain.Designer.ViewModels.Mesh;
using Rain.Designer.ViewModels.Samples;
using Rain.Designer.ViewModels.Tree;
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
		public TreeViewModel Tree { get; }

		public WaveDesignerViewModel(
			MeshViewModel mesh,
			SamplesViewModel samples,
			Func<TreeViewModel> treeFactory)
		{
			Mesh = mesh;
			Samples = samples;
			Tree = treeFactory();

			Tree.SubTrees = Enumerable.Range(0, 3)
				.Select(_ =>
				{
					var subTree = treeFactory();

					subTree.SubTrees = Enumerable.Range(0, 2)
						.Select(__ => treeFactory())
						.ToList();

					return subTree;
				})
				.ToList();
		}
	}
}
