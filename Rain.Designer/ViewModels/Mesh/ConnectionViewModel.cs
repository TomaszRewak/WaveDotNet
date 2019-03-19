using Rain.Designer.DataStructures;
using Rain.Designer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Mesh
{
	internal class ConnectionViewModel : ViewModel
	{
		private UnorderedPair<MeshPoint> _connection;
		public UnorderedPair<MeshPoint> Ends
		{
			get => _connection;
			set => Set(ref _connection, value);
		}
	}
}
