using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class ColorToBrushConverter : ValueConverter<Color, Brush>
	{
		public override Brush Convert(Color value)
		{
			return new SolidColorBrush(value);
		}

		public override Color ConvertBack(Brush value)
		{
			throw new NotSupportedException();
		}
	}
}
