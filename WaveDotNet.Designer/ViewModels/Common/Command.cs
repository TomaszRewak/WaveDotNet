using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WaveDotNet.Designer.ViewModels.Common
{
	internal class Command : ICommand
	{
		private readonly Action _callback;

		public Command(Action callback)
		{
			_callback = callback;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			_callback();
		}

		public event EventHandler CanExecuteChanged;
	}
	internal class Command<T> : ICommand
	{
		private readonly Action<T> _callback;

		public Command(Action<T> callback)
		{
			_callback = callback;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			if (!(parameter is T typedParameter))
				throw new InvalidCastException();

			_callback(typedParameter);
		}

		public event EventHandler CanExecuteChanged;
	}
}
