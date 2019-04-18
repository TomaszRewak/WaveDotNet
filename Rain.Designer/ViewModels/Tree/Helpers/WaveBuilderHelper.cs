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
		public IWave BuildWave(TreeViewModel tree)
		{
			var subWaves = tree
				.SubTrees
				.Select(BuildWave)
				.ToArray();

			return tree.WaveBlock.GenerateWave(subWaves);
		}
    }
}
