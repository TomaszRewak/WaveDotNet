using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.ViewModels.Common
{
	internal class ViewModelChange<T>
	{
		public T OldValue { get; }
		public T NewValue { get; }

		public bool Changed { get; }

		public ViewModelChange(T oldValue, T newValue)
		{
			OldValue = oldValue;
			NewValue = newValue;

			Changed = !(newValue?.Equals(oldValue) ?? false);
		}
	}
}
