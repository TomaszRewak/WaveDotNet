using Rain.Designer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rain.Designer.ViewModels.Tree
{
    internal class TreeViewModel : ViewModel
    {
		private readonly Func<TreeViewModel> _treeFactory;

		public TreeViewModel(
			Func<TreeViewModel> treeFactory, 
			NodeViewModel rootNode)
		{
			_treeFactory = treeFactory;

			RootNode = rootNode;
		}

		private void SubTreeChanged(object subTree, PropertyChangedEventArgs args)
		{
			if (args.PropertyName == nameof(TreeViewModel.Width))
				this.UpdateWidth();
		}

		public NodeViewModel RootNode { get; }

		private IReadOnlyCollection<TreeViewModel> _subTrees = new List<TreeViewModel>();
		public IReadOnlyCollection<TreeViewModel> SubTrees
		{
			get => _subTrees;
			set => Set(ref _subTrees, value)
				.ObserveChildren(SubTreeChanged)
				.Then(UpdateWidth);
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

		private void UpdateWidth()
		{
			Width = SubTrees.Any() 
				? SubTrees.Sum(subTree => subTree.Width)
				: 1;
		}

		public ICommand AddSubTreeCommand => new Command(AddSubTree);
    }
}
