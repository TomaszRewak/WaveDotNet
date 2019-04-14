using Rain.Designer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rain.Designer.ViewModels.Tree
{
    internal class TreeDesignerViewModel : ViewModel
    {
		public TreeViewModel Tree { get; }

		public TreeDesignerViewModel(TreeViewModel tree)
		{
			Tree = tree;
		}

		private TreeViewModel _selectedSubTree;
		public TreeViewModel SelectedSubTree
		{
			get => _selectedSubTree;
			set => Set(ref _selectedSubTree, value);
		}

		private void SelectSubTree(TreeViewModel tree)
		{
			this.SelectedSubTree = tree;
		}

		public ICommand SelectTreeCommand => new Command<TreeViewModel>(SelectSubTree);
    }
}
