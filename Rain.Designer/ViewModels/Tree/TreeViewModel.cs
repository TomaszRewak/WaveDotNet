using Rain.Designer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rain.Designer.ViewModels.Tree
{
    internal class TreeViewModel : ViewModel
    {
		private readonly Func<TreeViewModel> _treeFactory;

		public TreeViewModel(Func<TreeViewModel> treeFactory)
		{
			_treeFactory = treeFactory;
		}

		private IReadOnlyCollection<TreeViewModel> _subTrees = new List<TreeViewModel>();
		public IReadOnlyCollection<TreeViewModel> SubTrees
		{
			get => _subTrees;
			set => Set(ref _subTrees, value);
		}

		private void AddSubTree()
		{
			SubTrees = SubTrees
				.Concat(new[] { _treeFactory() })
				.ToList();
		}

		public ICommand AddSubTreeCommand => new Command(AddSubTree);
    }
}
