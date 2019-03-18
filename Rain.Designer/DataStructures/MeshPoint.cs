using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.DataStructures
{
	internal struct MeshPoint
	{
		public int Row { get; set; }
		public int Column { get; set; }

		public override bool Equals(object obj)
		{
			if (obj is MeshPoint value)
				this.Equals(value);

			return false;
		}

		public bool Equals(MeshPoint value)
		{
			return Row == value.Row && Column == value.Column;
		}

		public override int GetHashCode()
		{
			return Row.GetHashCode() ^ Column.GetHashCode();
		}

		public static bool operator == (MeshPoint lhs, MeshPoint rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(MeshPoint lhs, MeshPoint rhs)
		{
			return !lhs.Equals(rhs);
		}
	}
}
