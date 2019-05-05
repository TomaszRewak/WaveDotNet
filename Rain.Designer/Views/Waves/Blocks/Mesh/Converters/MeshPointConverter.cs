using Rain.Designer.DataStructures;
using Rain.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Rain.Designer.Views.Waves.Blocks.Mesh.Converters
{
	internal enum MeshPointConverterDimension
	{
		Row,
		Column
	}
	
	internal class MeshPointConverter : ValueConverter<MeshPoint, double, MeshPointConverterDimension>
	{
		public double PointDistance { get; set; }
		public double Offset { get; set; }

		protected override double Convert(MeshPoint value, MeshPointConverterDimension parameter)
		{
			switch (parameter)
			{
				case MeshPointConverterDimension.Column:
					return value.X * PointDistance + Offset;
				case MeshPointConverterDimension.Row:
					return value.Y * PointDistance + Offset;
				default:
					throw new NotImplementedException();
			}
		}

		protected override MeshPoint ConvertBack(double value, MeshPointConverterDimension parameter)
		{
			throw new NotImplementedException();
		}
	}
}
