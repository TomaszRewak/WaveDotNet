using Rain.Designer.ViewModels.Tree;
using Rain.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Rain.Designer.Views.Tree.Converters
{
	internal class ChildNodePositionConverter : MultiValueConverter<double>
	{
		public BindingBase NodeIndex { get; set; }
		public BindingBase Tree { get; set; }
		public BindingBase Width { get; set; }

		public double NodesDistance { get; set; }

		protected override double Convert(MultiValueConverterProvider valueProvider)
		{
			var nodeIndex = valueProvider.Get<int>(0);
			var tree = valueProvider.Get<TreeViewModel>(1);

			if (nodeIndex >= tree.SubTrees.Count)
				return 0;

			var nodesToTheLeft =
				tree
					.SubTrees
					.Take(nodeIndex)
					.Sum(subTree => subTree.Width)
				+
				tree
					.SubTrees
					.ElementAt(nodeIndex)
					.Width * 0.5
				-
				tree.Width * 0.5;

			return nodesToTheLeft * NodesDistance;
		}

		protected override object[] ConvertBack(double value)
		{
			throw new NotImplementedException();
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var binding = new MultiBinding() { Converter = this };
			binding.Bindings.Add(NodeIndex);
			binding.Bindings.Add(Tree);
			binding.Bindings.Add(Width);

			return binding.ProvideValue(serviceProvider);
		}
	}
}
