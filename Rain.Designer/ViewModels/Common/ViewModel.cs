using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Common
{
	internal interface IViewModel : INotifyPropertyChanged
	{
		void Set<T>(ref T field, T value, [CallerMemberName] string property = "");
	}

	internal class ViewModel : IViewModel
	{
		public void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
		{
			if (object.Equals(field, value))
			{
				field = value;

				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
