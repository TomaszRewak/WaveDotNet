using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain.Designer.ViewModels.Common
{
	internal interface IViewModelChangePropagation<T>
	{
		IViewModelChangePropagation<T> Then(Action action);
	}

	internal class ViewModelChangePropagation<T> : IViewModelChangePropagation<T>
	{
		private readonly IViewModelChange<T> _change;

		public ViewModelChangePropagation(IViewModelChange<T> change)
		{
			_change = change;
		}

		public IViewModelChangePropagation<T> Then(Action action)
		{
			if (_change.Changed)
				action();

			return this;
		}
	}
}
