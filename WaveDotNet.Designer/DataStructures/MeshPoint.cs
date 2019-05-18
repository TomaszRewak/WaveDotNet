using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.DataStructures
{
	internal struct MeshPoint
	{
		public int X { get; set; }
		public int Y { get; set; }

		public MeshPoint(int x, int y)
		{
			X = x;
			Y = y;
		}

		public override bool Equals(object obj)
		{
			if (obj is MeshPoint value)
				return this.Equals(value);

			return false;
		}

		public bool Equals(MeshPoint value)
		{
			return X == value.X && Y == value.Y;
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode();
		}

		public static bool operator ==(MeshPoint lhs, MeshPoint rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(MeshPoint lhs, MeshPoint rhs)
		{
			return !lhs.Equals(rhs);
		}
	}
}
