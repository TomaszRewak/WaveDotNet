using Rain.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rain.Designer.Views.Converters
{
	internal class TypeToDataTemplateConverter : ValueConverter<Type, DataTemplate>
	{
		public override DataTemplate Convert(Type value)
		{
			if (value == null)
				return new DataTemplate();

			return new DataTemplate
			{
				VisualTree = new FrameworkElementFactory(value)
			};
		}

		public override Type ConvertBack(DataTemplate value)
		{
			throw new NotImplementedException();
		}
	}
}
