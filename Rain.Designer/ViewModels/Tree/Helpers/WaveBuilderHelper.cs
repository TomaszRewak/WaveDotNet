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
		public IWave BuildWave(NodeViewModel tree)
		{
			var subWaves = tree
				.Inputs
				.Select(BuildWave)
				.ToArray();

			return tree.WaveBlock.GenerateWave(subWaves);
		}
    }
}
