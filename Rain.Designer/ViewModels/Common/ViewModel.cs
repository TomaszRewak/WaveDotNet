﻿using System;
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
		IViewModelChangePropagation<T> Set<T>(ref T field, T value, [CallerMemberName] string property = "");
	}

	internal class ViewModel : IViewModel
	{
		public IViewModelChangePropagation<T> Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
		{
			var change = new ViewModelChange<T>(field, value);

			if (change.Changed)
				field = value;

			return new ViewModelChangePropagation<T>(change);
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}