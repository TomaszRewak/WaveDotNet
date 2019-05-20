using WaveDotNet.Designer.ViewModels.Common;
using WaveDotNet.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WaveDotNet.Designer.ViewModels.Tracks
{
	internal class TrackViewModel : ViewModel
	{
		private readonly WavePlayer _wavePlayer;

		public TrackViewModel(WavePlayer wavePlayer)
		{
			_wavePlayer = wavePlayer;
		}

		private bool _canPlay;
		public bool CanPlay
		{
			get => _canPlay;
			set => Set(ref _canPlay, value);
		}

		private bool _canPause = true;
		public bool CanPause
		{
			get => _canPause;
			set => Set(ref _canPause, value);
		}

		private bool _canStop = true;
		public bool CanStop
		{
			get => _canStop;
			set => Set(ref _canStop, value);
		}
		
		public void Play()
		{
			_wavePlayer.Play();

			CanPlay = false;
			CanPause = true;
			CanStop = true;
		}

		public void Pause()
		{
			_wavePlayer.Pause();

			CanPlay = true;
			CanPause = false;
			CanStop = true;
		}

		public void Stop()
		{
			_wavePlayer.Stop();

			CanPlay = true;
			CanPause = false;
			CanStop = false;
		}

		public ICommand PlayCommand => new Command(Play);
		public ICommand PauseCommand => new Command(Pause);
		public ICommand StopCommand => new Command(Stop);
	}
}
