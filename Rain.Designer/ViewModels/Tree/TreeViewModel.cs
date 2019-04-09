using Rain.Designer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Tree
{
    internal class TreeViewModel : ViewModel
    {
		public TreeViewModel()
		{ }

		private IReadOnlyCollection<TreeViewModel> _subTrees;
		public IReadOnlyCollection<TreeViewModel> SubTrees
		{
			get => _subTrees;
			set => Set(ref _subTrees, value);
		}
    }
}
