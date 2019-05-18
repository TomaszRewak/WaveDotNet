using Microsoft.Extensions.DependencyInjection;
using WaveDotNet.Designer.Modules;
using WaveDotNet.Designer.ViewModels.WaveDesigner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WaveDotNet.Designer
{
	internal partial class App : Application, INotifyPropertyChanged
	{
		public WaveDesignerViewModel WaveDesigner { get; private set; }

		protected override void OnStartup(StartupEventArgs e)
		{
			var container = PrepareServiceProvider();

			WaveDesigner = container.GetRequiredService<WaveDesignerViewModel>();
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WaveDesigner)));

			base.OnStartup(e);
		}

		private ServiceProvider PrepareServiceProvider()
		{
			var serviceCollection = new ServiceCollection();
			
			WaveDesignerModule.Register(serviceCollection);
			TreeModule.Register(serviceCollection);
			TracksModule.Register(serviceCollection);

			return serviceCollection.BuildServiceProvider();
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
