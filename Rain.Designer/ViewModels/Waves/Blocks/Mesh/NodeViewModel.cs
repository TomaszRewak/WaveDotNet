using Rain.Designer.DataStructures;
using Rain.Designer.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Waves.Blocks.Mesh
{
	internal class NodeViewModel : ViewModel
	{
		private MeshPoint _position;
		public MeshPoint Position
		{
			get => _position;
			set => Set(ref _position, value);
		}

		private int? _input;
		public int? Input
		{
			get => _input;
			set => Set(ref _input, value);
		}

		private bool _isOutput;
		public bool IsOutput
		{
			get => _isOutput;
			set => Set(ref _isOutput, value);
		}

		private double _mass;
		public double Mass
		{
			get => _mass;
			set => Set(ref _mass, value);
		}
	}
}
