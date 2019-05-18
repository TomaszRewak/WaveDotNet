using WaveDotNet.Designer.ViewModels.Common;
using WaveDotNet.Designer.ViewModels.Tracks;
using WaveDotNet.Designer.ViewModels.Tree;
using WaveDotNet.Designer.ViewModels.Tree.Helpers;
using WaveDotNet.Designer.ViewModels.WaveDesigner.Helpers;
using WaveDotNet.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WaveDotNet.Designer.ViewModels.WaveDesigner
{
	internal class WaveDesignerViewModel : ViewModel
	{
		private readonly FileHelper _fileHelper;
		private readonly WaveBuilderHelper _waveBuilderHelper;
		
		public TreeViewModel TreeDesigner { get; }
		public TracksViewModel Tracks { get; }

		public WaveDesignerViewModel(
			FileHelper fileHelper,
			WaveBuilderHelper waveBuilderHelper,
			TreeViewModel treeDesigner,
			TracksViewModel tracks)
		{
			_fileHelper = fileHelper;
			_waveBuilderHelper = waveBuilderHelper;
			
			TreeDesigner = treeDesigner;
			Tracks = tracks;
		}

		private void Save()
		{
			_fileHelper.Save(this);
		}

		private void Load()
		{
			_fileHelper.Load(this);
		}

		public ICommand SaveCommand => new Command(Save);
		public ICommand LoadCommand => new Command(Load);
	}
}
