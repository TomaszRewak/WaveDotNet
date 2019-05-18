using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class ColorBrightnessConverter : ValueConverter<Color, Color>
	{
		public double Brightness { get; set; }

		public override Color Convert(Color value)
		{
			return Color.FromArgb(
				value.A,
				(byte)(value.R * (1 - Brightness) + 255 * Brightness),
				(byte)(value.G * (1 - Brightness) + 255 * Brightness),
				(byte)(value.B * (1 - Brightness) + 255 * Brightness));
		}

		public override Color ConvertBack(Color value)
		{
			throw new NotSupportedException();
		}
	}
}
