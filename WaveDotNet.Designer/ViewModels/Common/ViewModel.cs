using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.ViewModels.Common
{
	internal interface IViewModel : INotifyPropertyChanged
	{
		ViewModelChangePropagation<T> Set<T>(ref T field, T value, [CallerMemberName] string property = "");
	}

	internal class ViewModel : IViewModel
	{
		public ViewModelChangePropagation<T> Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
		{
			var change = new ViewModelChange<T>(field, value);

			if (change.Changed)
			{
				field = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}

			return new ViewModelChangePropagation<T>(change);
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
