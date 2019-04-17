using Rain.Designer.ViewModels.Common;
using Rain.Designer.ViewModels.Tree.Helpers;
using Rain.Designer.ViewModels.Waves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Rain.Designer.ViewModels.Tree.Helpers.WaveBlockFactoryHelper;

namespace Rain.Designer.ViewModels.Tree
{
    internal class NodeViewModel : ViewModel
    {
		private readonly WaveBlockFactoryHelper _waveBlockFactoryHelper;

		public NodeViewModel(WaveBlockFactoryHelper waveBlockFactoryHelper)
		{
			_waveBlockFactoryHelper = waveBlockFactoryHelper;
		}

		public IReadOnlyCollection<WaveBlockFactory> AvailableWavesBlocks => _waveBlockFactoryHelper.AvailableFactories;

		private WaveBlockViewModel _waveBlock;
		public WaveBlockViewModel WaveBlock
		{
			get => _waveBlock;
			set => Set(ref _waveBlock, value);
		}

		private void ChangeWave(WaveBlockFactory waveBlockFactory)
		{
			WaveBlock = waveBlockFactory.Create();
		}

		public ICommand ChangeWaveCommand => new Command<WaveBlockFactory>(ChangeWave);
    }
}
