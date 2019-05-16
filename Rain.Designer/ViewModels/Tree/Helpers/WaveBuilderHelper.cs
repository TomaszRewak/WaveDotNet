using Rain.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Tree.Helpers
{
    internal class WaveBuilderHelper
	{
		public Func<IWave> BuildWaveFactory(NodeViewModel tree)
		{
			if (!CanBuildWave(tree))
				return null;

			var subWaveFactories = tree
				.Inputs
				.Select(node => node.WaveFactory)
				.ToArray();

			return () => tree.WaveBlock.WaveFactory(subWaveFactories.Select(factory => factory()).ToArray());
		}

		private bool CanBuildWave(NodeViewModel tree)
		{
			return
				tree.WaveBlock != null &&
				tree.WaveBlock.WaveFactory != null &&
				tree.Inputs.All(subTree => subTree.WaveFactory != null) &&
				tree.WaveBlock.MinInputs <= tree.Inputs.Count &&
				tree.WaveBlock.MaxInputs >= tree.Inputs.Count;
		}
	}
}
