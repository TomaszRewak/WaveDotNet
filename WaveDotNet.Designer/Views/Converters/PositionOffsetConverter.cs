using WaveDotNet.Designer.DataStructures;
using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class PositionOffsetConverter : ValueConverter<Position, Position>
	{
		public double OffsetX { get; set; }
		public double OffsetY { get; set; }

		public override Position Convert(Position value)
		{
			return new Position(
				value.X + OffsetX,
				value.Y + OffsetY);
		}

		public override Position ConvertBack(Position value)
		{
			return new Position(
				value.X - OffsetX,
				value.Y - OffsetY);
		}
	}
}
