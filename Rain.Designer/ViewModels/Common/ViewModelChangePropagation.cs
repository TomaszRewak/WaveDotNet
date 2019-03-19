using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Common
{
	internal class ViewModelChangePropagation<T>
	{
		private readonly ViewModelChange<T> _change;

		public ViewModelChangePropagation(ViewModelChange<T> change)
		{
			_change = change;
		}

		public ViewModelChangePropagation<T> Then(Action action)
		{
			if (_change.Changed)
				action();

			return this;
		}
	}
}
