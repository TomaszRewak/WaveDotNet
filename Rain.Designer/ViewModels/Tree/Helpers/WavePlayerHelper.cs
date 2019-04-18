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
			Thread thread1 = new Thread(() => {
				var player = new WavePlayer(new WhiteNoiseWaveGenerator());
				player.Play();

				while (true)
					Thread.Sleep(500);
			});
			thread1.Start();
		}
    }
}
