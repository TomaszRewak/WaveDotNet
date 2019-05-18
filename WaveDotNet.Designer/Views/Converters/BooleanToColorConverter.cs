using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class BooleanToColorConverter : ValueConverter<bool, Color>
	{
		public Color True { get; set; }
		public Color False { get; set; }

		public override Color Convert(bool value)
		{
			return value
				? True
				: False;
		}

		public override bool ConvertBack(Color value)
		{
			throw new NotSupportedException();
		}
	}
}
