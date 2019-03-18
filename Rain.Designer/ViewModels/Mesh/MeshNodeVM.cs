using Rain.Designer.DataStructures;
using Rain.Designer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Mesh
{
	internal interface IMeshNodeVM
	{
		MeshPoint Position { get; }
	}

	internal class MeshNodeVM : ViewModel, IMeshNodeVM
	{
		private MeshPoint _position;
		public MeshPoint Position
		{
			get => _position;
			set => Set(ref _position, value);
		}
	}
}
