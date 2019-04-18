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

		private TreeViewModel _selectedNode;
		public TreeViewModel SelectedNode
		{
			get => _selectedNode;
			set => Set(ref _selectedNode, value);
		}

		private void SelectNode(TreeViewModel node)
		{
			this.SelectedNode = node;
		}

		public ICommand SelectNodeCommand => new Command<TreeViewModel>(SelectNode);
    }
}
