using Microsoft.Extensions.DependencyInjection;
using WaveDotNet.Designer.Modules.Helpers;
using WaveDotNet.Designer.ViewModels.Tracks;
using WaveDotNet.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.Modules
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
