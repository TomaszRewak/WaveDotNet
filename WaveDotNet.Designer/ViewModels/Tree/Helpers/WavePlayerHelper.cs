using WaveDotNet.Designer.ViewModels.Tracks;
using WaveDotNet.Generator;
using WaveDotNet.Wave;
using WaveDotNet.Wave.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.ViewModels.Tree.Helpers
{
    internal class WavePlayerHelper
    {
		private readonly TracksViewModel _tracks;

		public WavePlayerHelper(TracksViewModel tracks)
		{
			_tracks = tracks;
		}

		public void PlayWave(IWave wave)
		{
			var player = new WavePlayer(wave);
			player.Play();

			_tracks.AddTrack(player);
		}
    }
}
