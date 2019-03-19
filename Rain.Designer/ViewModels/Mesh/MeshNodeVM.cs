using Rain.Designer.DataStructures;
using Rain.Designer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Mesh
{
	internal class MeshNodeVM : ViewModel
	{
		private MeshPoint _position;
		public MeshPoint Position
		{
			get => _position;
			set => Set(ref _position, value);
		}
	}
}
