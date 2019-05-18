using WaveDotNet.Designer.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.ViewModels.Tree.Helpers
{
	internal class WaveBlockSerializationHelper
	{
		WaveBlockFactoryHelper _waveBlockFactoryHelper;

		public WaveBlockSerializationHelper(WaveBlockFactoryHelper waveBlockFactoryHelper)
		{
			_waveBlockFactoryHelper = waveBlockFactoryHelper;
		}

		public dynamic SerializeNode(NodeViewModel node)
		{
			return new
			{
				node.Position.X,
				node.Position.Y,
				WaveBlock = new
				{
					node.WaveBlock?.GetType().Name,
					Parameters = node.WaveBlock?.Serialize()
				}
			};
		}

		public NodeViewModel DeserializeNode(NodeViewModel node, dynamic value)
		{
			node.Position = new Position((double)value.X, (double)value.Y);

			var factory = _waveBlockFactoryHelper
				.AvailableFactories
				.FirstOrDefault(f => f.Type.Name == (string)value.WaveBlock.Name);

			if (factory != null)
			{
				node.WaveBlockFactory = factory;
				node.WaveBlock.Deserialize(value.WaveBlock.Parameters);
			}

			return node;
		}
	}
}
