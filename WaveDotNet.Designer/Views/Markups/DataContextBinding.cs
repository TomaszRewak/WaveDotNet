using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace WaveDotNet.Designer.Views.Markups
{
	internal class DataContextBinding : MarkupExtension
	{
		public string Path { get; set; }
		public Type ControlType { get; set; }
		public IValueConverter Converter { get; set; }

		public DataContextBinding()
		{ }

		public DataContextBinding(string path)
		{
			Path = path;
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var path = string.IsNullOrWhiteSpace(Path)
				? "DataContext"
				: $"DataContext.{Path}";

			var binding = new Binding(path)
			{
				RelativeSource = new RelativeSource
				{
					AncestorType = ControlType
				},
				Converter = Converter
			};

			return binding.ProvideValue(serviceProvider);
		}
	}
}
