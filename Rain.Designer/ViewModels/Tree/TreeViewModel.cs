using Rain.Designer.ViewModels.Common;
using Rain.Designer.ViewModels.Tree.Helpers;
using Rain.Designer.ViewModels.Waves;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Rain.Designer.ViewModels.Tree.Helpers.WaveBlockFactoryHelper;

namespace Rain.Designer.ViewModels.Tree
{
	internal class TreeViewModel : ViewModel
	{
		private readonly WaveBlockFactoryHelper _waveBlockFactoryHelper;
		private readonly Func<TreeViewModel> _treeFactory;

		public TreeViewModel(
			WaveBlockFactoryHelper waveBlockFactoryHelper,
			Func<TreeViewModel> treeFactory)
		{
			_waveBlockFactoryHelper = waveBlockFactoryHelper;
			_treeFactory = treeFactory;
		}

		private void SubTreeChanged(object subTree, PropertyChangedEventArgs args)
		{
			if (args.PropertyName == nameof(TreeViewModel.Width))
				this.UpdateWidth();
		}

		private IReadOnlyCollection<TreeViewModel> _subTrees = new List<TreeViewModel>();
		public IReadOnlyCollection<TreeViewModel> SubTrees
		{
			get => _subTrees;
			set => Set(ref _subTrees, value)
				.ObserveChildren(SubTreeChanged)
				.Then(UpdateWidth);
		}

		public IReadOnlyCollection<WaveBlockFactory> AvailableWavesBlocks
		{
			get => _waveBlockFactoryHelper.AvailableFactories;
		}

		private WaveBlockViewModel _waveBlock;
		public WaveBlockViewModel WaveBlock
		{
			get => _waveBlock;
			set => Set(ref _waveBlock, value);
		}

		private int _width = 1;
		public int Width
		{
			get => _width;
			set => Set(ref _width, value);
		}

		private void AddSubTree()
		{
			SubTrees = SubTrees
				.Concat(new[] { _treeFactory() })
				.ToList();
		}
		private void ChangeWave(WaveBlockFactory waveBlockFactory)
		{
			WaveBlock = waveBlockFactory.Create();
		}

		private void UpdateWidth()
		{
			Width = SubTrees.Any()
				? SubTrees.Sum(subTree => subTree.Width)
				: 1;
		}

		public ICommand AddSubTreeCommand => new Command(AddSubTree);
		public ICommand ChangeWaveCommand => new Command<WaveBlockFactory>(ChangeWave);
	}
}
