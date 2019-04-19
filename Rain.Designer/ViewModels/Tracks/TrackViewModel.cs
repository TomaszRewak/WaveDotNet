using Rain.Designer.ViewModels.Common;
using Rain.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rain.Designer.ViewModels.Tracks
{
	internal class TrackViewModel
	{
		private readonly WavePlayer _wavePlayer;

		public TrackViewModel(WavePlayer wavePlayer)
		{
			_wavePlayer = wavePlayer;
		}

		private void Stop()
		{
			_wavePlayer.Stop();
		}

		public ICommand StopCommand => new Command(Stop);
	}
}
