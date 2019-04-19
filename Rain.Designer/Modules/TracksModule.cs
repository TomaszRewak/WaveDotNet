using Microsoft.Extensions.DependencyInjection;
using Rain.Designer.Modules.Helpers;
using Rain.Designer.ViewModels.Tracks;
using Rain.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.Modules
{
    internal class TracksModule
	{
		public static void Register(ServiceCollection serviceCollection)
		{
			serviceCollection.AddSingleton<TracksViewModel>();
			serviceCollection.AddTransient<TrackViewModel>();
			serviceCollection.AddTransient<Func<WavePlayer, TrackViewModel>>(sp => wp => new TrackViewModel(wp));
		}
	}
}
