using Rain.Generator;
using Rain.Wave;
using Rain.Wave.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Tree.Helpers
{
    internal class WavePlayerHelper
    {
		public void PlayWave(IWave wave)
		{
			var player = new WavePlayer(wave);
			player.Play();
		}
    }
}
