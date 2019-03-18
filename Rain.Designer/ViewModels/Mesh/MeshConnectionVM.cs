using Rain.Designer.DataStructures;
using Rain.Designer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Mesh
{
	internal interface IMeshConnectionVM : IViewModel
	{
		UnorderedPair<MeshPoint> Connection { get; }
	}

	internal class MeshConnectionVM : ViewModel, IMeshConnectionVM
	{
		private UnorderedPair<MeshPoint> _connection;
		public UnorderedPair<MeshPoint> Connection
		{
			get => _connection;
			set => Set(ref _connection, value);
		}
	}
}
