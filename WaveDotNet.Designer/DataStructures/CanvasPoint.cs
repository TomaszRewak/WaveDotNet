using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.DataStructures
{
	internal struct Position
	{
		public double X { get; }
		public double Y { get; }

		public Position(double x, double y)
		{
			X = x;
			Y = y;
		}
	}
}
