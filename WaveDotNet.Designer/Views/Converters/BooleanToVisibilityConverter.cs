using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class BooleanToVisibilityConverter : ValueConverter<bool, Visibility>
	{
		public Visibility True { get; set; }

		public Visibility False { get; set; }

		public override Visibility Convert(bool value)
		{
			return value
				? True
				: False;
		}

		public override bool ConvertBack(Visibility value)
		{
			return value == True;
		}
	}
}
