using WaveDotNet.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.ViewModels.Tree.Helpers
{
    internal class WaveBuilderHelper
	{
		public IWave BuildWave(NodeViewModel tree)
		{
			if (!CanBuildWave(tree))
				return null;

			var subWaves = tree
				.Inputs
				.Select(node => node.Wave)
				.ToArray();

			return tree.WaveBlock.WaveFactory(subWaves);
		}

		private bool CanBuildWave(NodeViewModel tree)
		{
			return
				tree.WaveBlock != null &&
				tree.WaveBlock.WaveFactory != null &&
				tree.Inputs.All(subTree => subTree.Wave != null) &&
				tree.WaveBlock.MinInputs <= tree.Inputs.Count &&
				tree.WaveBlock.MaxInputs >= tree.Inputs.Count;
		}
	}
}
