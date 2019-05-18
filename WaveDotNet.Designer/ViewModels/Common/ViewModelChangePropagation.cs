using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.ViewModels.Common
{
	internal class ViewModelChangePropagation<T>
	{
		public ViewModelChange<T> Change { get; }

		public ViewModelChangePropagation(ViewModelChange<T> change)
		{
			Change = change;
		}

		public ViewModelChangePropagation<T> Then(Action action)
		{
			if (Change.Changed)
				action();

			return this;
		}
	}

	internal static class ViewModelChangePropagationObservableSpecialization
	{
		public static ViewModelChangePropagation<T> Observe<T>(
			this ViewModelChangePropagation<T> self,
			PropertyChangedEventHandler callback) where T : INotifyPropertyChanged
		{
			if (self.Change.Changed)
			{
				if (self.Change.OldValue != null)
					self.Change.OldValue.PropertyChanged -= callback;

				if (self.Change.NewValue != null)
					self.Change.NewValue.PropertyChanged += callback;
			}

			return self;
		}
	}

	internal static class ViewModelChangePropagationCollectionSpecialization
	{
		public static ViewModelChangePropagation<IReadOnlyCollection<T>> ObserveChildren<T>(
			this ViewModelChangePropagation<IReadOnlyCollection<T>> self, 
			PropertyChangedEventHandler callback) where T : INotifyPropertyChanged
		{
			if (self.Change.Changed)
			{
				var removedChildren = self.Change.OldValue.Except(self.Change.NewValue);
				var addedChildren = self.Change.NewValue.Except(self.Change.OldValue);

				foreach (var child in removedChildren)
					child.PropertyChanged -= callback;

				foreach (var child in addedChildren)
					child.PropertyChanged += callback;
			}

			return self;
		}
	}
}
