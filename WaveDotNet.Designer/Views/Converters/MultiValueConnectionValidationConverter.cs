using WaveDotNet.Designer.ViewModels.Tree;
using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class MultiValueConnectionValidationConverter : MultiValueConverter<bool>
	{
		protected override bool Convert(MultiValueConverterProvider valueProvider)
		{
			if (!valueProvider.TryGet<NodeViewModel>(0, out var from))
				return false;

			if (!valueProvider.TryGet<NodeViewModel>(1, out var to))
				return false;

			return !Contains(to, from);
		}

		private bool Contains(NodeViewModel tree, NodeViewModel node)
		{
			return tree == node || tree.Inputs.Any(input => Contains(input, node));
		}

		protected override object[] ConvertBack(bool value)
		{
			throw new NotSupportedException();
		}
	}
}
