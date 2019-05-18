using WaveDotNet.Designer.Views.Common;
using WaveDotNet.Designer.Views.Markups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class TypeToDataTemplateConverter : ValueConverter<Type, DataTemplate>
	{
		public Binding DataContextSource { get; set; }

		public override DataTemplate Convert(Type value)
		{
			if (value == null)
				return new DataTemplate();

			var visualTree = new FrameworkElementFactory(value);

			if (DataContextSource != null)
				visualTree.SetBinding(FrameworkElement.DataContextProperty, DataContextSource);

			return new DataTemplate
			{
				VisualTree = visualTree
			};
		}

		public override Type ConvertBack(DataTemplate value)
		{
			throw new NotSupportedException();
		}
	}
}
