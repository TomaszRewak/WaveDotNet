using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class BooleanToSolidColorBrushConverter : ValueConverter<bool, Brush>
	{
		public Color True { get; set; }
		public Color False { get; set; }

		public override Brush Convert(bool value)
		{
			return value
				? new SolidColorBrush(True)
				: new SolidColorBrush(False);
		}

		public override bool ConvertBack(Brush value)
		{
			throw new NotSupportedException();
		}
	}
}
