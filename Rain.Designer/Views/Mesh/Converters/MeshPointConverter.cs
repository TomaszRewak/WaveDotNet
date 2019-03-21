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
	internal class MeshPointConverter : IValueConverter
	{
		public double Offset { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(parameter is MeshPointConverterDimension dimension))
				return null;

			if (!(value is MeshPoint meshPoint))
				return null;

			switch (dimension)
			{
				case MeshPointConverterDimension.Column:
					return meshPoint.X * Offset;
				case MeshPointConverterDimension.Row:
					return meshPoint.Y * Offset;
			}

			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
