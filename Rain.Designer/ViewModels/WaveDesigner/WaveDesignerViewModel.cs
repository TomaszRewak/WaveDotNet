using Rain.Designer.ViewModels.Common;
using Rain.Designer.ViewModels.Mesh;
using Rain.Designer.ViewModels.Samples;
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
		private readonly WaveLoaderHelper _waveLoaderHelper;

		public MeshViewModel Mesh { get; }
		public SamplesViewModel Samples { get; }
		public TreeDesignerViewModel TreeDesigner { get; }

		public WaveDesignerViewModel(
			FileHelper fileHelper,
			WaveBuilderHelper waveBuilderHelper,
			WaveLoaderHelper waveLoaderHelper,
			MeshViewModel mesh,
			SamplesViewModel samples,
			TreeDesignerViewModel treeDesigner)
		{
			_fileHelper = fileHelper;
			_waveBuilderHelper = waveBuilderHelper;
			_waveLoaderHelper = waveLoaderHelper;

			Mesh = mesh;
			Samples = samples;
			TreeDesigner = treeDesigner;
		}

		private void Save()
		{
			_fileHelper.Save(_waveBuilderHelper.BuildWave(TreeDesigner.Tree));
		}

		private void Load()
		{
			if (_fileHelper.Load(out IWave wave))
				TreeDesigner.Tree = _waveLoaderHelper.Load(wave);
		}

		public ICommand SaveCommand => new Command(Save);
		public ICommand LoadCommand => new Command(Load);
	}
}
