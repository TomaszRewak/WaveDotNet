using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class SolidColorBrushToColorConverter : ValueConverter<SolidColorBrush, Color>
	{
		public override Color Convert(SolidColorBrush value)
		{
			return value?.Color ?? Colors.Transparent;
		}

		public override SolidColorBrush ConvertBack(Color value)
		{
			throw new NotSupportedException();
		}
	}
}
