using Rain.Designer.DataStructures;
using Rain.Designer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Waves.Blocks.Mesh
{
	internal class ConnectionViewModel : ViewModel
	{
		private UnorderedPair<MeshPoint> _connection;
		public UnorderedPair<MeshPoint> Ends
		{
			get => _connection;
			set => Set(ref _connection, value).Then(UpdatePoints);
		}

		private MeshPoint _pointA;
		public MeshPoint PointA
		{
			get => _pointA;
			private set => Set(ref _pointA, value);
		}

		private MeshPoint _pointB;
		public MeshPoint PointB
		{
			get => _pointB;
			private set => Set(ref _pointB, value);
		}

		private double _stiffness = 0.5;
		public double Stiffness
		{
			get => _stiffness;
			set => Set(ref _stiffness, value);
		}

		private void UpdatePoints()
		{
			PointA = Ends.First();
			PointB = Ends.Last();
		}
	}
}
