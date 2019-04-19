using Rain.Designer.ViewModels.Common;
using Rain.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Tracks
{
    internal class TracksViewModel : ViewModel
    {
		private readonly Func<WavePlayer, TrackViewModel> _trackFactory;

		public TracksViewModel(Func<WavePlayer, TrackViewModel> trackFactory)
		{
			_trackFactory = trackFactory;
		}

		private IReadOnlyCollection<TrackViewModel> _tracks = new List<TrackViewModel>();
		public IReadOnlyCollection<TrackViewModel> Tracks
		{
			get => _tracks;
			set => Set(ref _tracks, value);
		}

		public void AddTrack(WavePlayer player)
		{
			var track = _trackFactory(player);

			this.Tracks = Tracks
				.Union(new[] { track })
				.ToList();
		}
    }
}
