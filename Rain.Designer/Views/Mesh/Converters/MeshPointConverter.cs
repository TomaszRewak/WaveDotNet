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

namespace Rain.Designer.Views.Mesh.Converters
{
	internal enum MeshPointConverterDimension
	{
		Row,
		Column
	}

	[ValueConversion(typeof(MeshPoint), typeof(double), ParameterType = typeof(MeshPointConverterDimension))]
	internal class MeshPointConverter : ValueConverter<MeshPoint, double, MeshPointConverterDimension>
	{
		public double Offset { get; set; }

		public override double Convert(MeshPoint value, MeshPointConverterDimension parameter)
		{
			switch (parameter)
			{
				case MeshPointConverterDimension.Column:
					return value.X * Offset;
				case MeshPointConverterDimension.Row:
					return value.Y * Offset;
				default:
					throw new NotImplementedException();
			}
		}

		public override MeshPoint ConvertBack(double value, MeshPointConverterDimension parameter)
		{
			throw new NotImplementedException();
		}
	}
}
