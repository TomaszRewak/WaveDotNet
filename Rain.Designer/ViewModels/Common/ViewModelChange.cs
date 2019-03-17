using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Common
{
	internal interface IViewModelChange<T>
	{
		T OldValue { get; }
		T NewValue { get; }

		bool Changed { get; }
	}

	internal class ViewModelChange<T> : IViewModelChange<T>
	{
		public T OldValue { get; }
		public T NewValue { get; }

		public bool Changed { get; }

		public ViewModelChange(T oldValue, T newValue)
		{
			OldValue = oldValue;
			NewValue = newValue;

			Changed = newValue?.Equals(oldValue) ?? false;
		}
	}
}
