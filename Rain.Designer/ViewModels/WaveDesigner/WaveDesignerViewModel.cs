using Rain.Designer.ViewModels.Common;
using Rain.Designer.ViewModels.Mesh;
using Rain.Designer.ViewModels.Samples;
using Rain.Designer.ViewModels.Tracks;
using Rain.Designer.ViewModels.Tree;
using Rain.Designer.ViewModels.Tree.Helpers;
using Rain.Designer.ViewModels.WaveDesigner.Helpers;
using Rain.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rain.Designer.ViewModels.WaveDesigner
{
	internal class WaveDesignerViewModel : ViewModel
	{
		private readonly FileHelper _fileHelper;
		private readonly WaveBuilderHelper _waveBuilderHelper;

		public MeshViewModel Mesh { get; }
		public SamplesViewModel Samples { get; }
		public TreeDesignerViewModel TreeDesigner { get; }
		public TracksViewModel Tracks { get; }

		public WaveDesignerViewModel(
			FileHelper fileHelper,
			WaveBuilderHelper waveBuilderHelper,
			MeshViewModel mesh,
			SamplesViewModel samples,
			TreeDesignerViewModel treeDesigner,
			TracksViewModel tracks)
		{
			_fileHelper = fileHelper;
			_waveBuilderHelper = waveBuilderHelper;

			Mesh = mesh;
			Samples = samples;
			TreeDesigner = treeDesigner;
			Tracks = tracks;
		}

		private void Save()
		{
			_fileHelper.Save(TreeDesigner.Nodes);
		}

		private void Load()
		{
			if (_fileHelper.Load(out IReadOnlyCollection<Tree.NodeViewModel> nodes))
				TreeDesigner.Nodes = nodes;
		}

		public ICommand SaveCommand => new Command(Save);
		public ICommand LoadCommand => new Command(Load);
	}
}
