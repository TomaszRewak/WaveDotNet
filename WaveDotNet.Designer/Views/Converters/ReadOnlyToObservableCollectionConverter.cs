using WaveDotNet.Designer.Views.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace WaveDotNet.Designer.Views.Converters
{
	internal class ReadOnlyToObservableCollectionConverter : ValueConverter<IReadOnlyCollection<object>, ObservableCollection<object>>
	{
		public ReadOnlyToObservableCollectionConverter()
		{

		}

		private readonly ObservableCollection<object> _collection = new ObservableCollection<object>();

		public override ObservableCollection<object> Convert(IReadOnlyCollection<object> values)
		{
			var oldItems = _collection.Except(values).ToList();
			var newItems = values.Except(_collection).ToList();

			foreach (var oldItem in oldItems)
				_collection.Remove(oldItem);

			foreach (var newItem in newItems)
				_collection.Add(newItem);

			return _collection;
		}

		public override IReadOnlyCollection<object> ConvertBack(ObservableCollection<object> value)
		{
			throw new NotSupportedException();
		}
	}

	internal class ReadOnlyToObservableCollectionConverterExtension : MarkupExtension
	{
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return new ReadOnlyToObservableCollectionConverter();
		}
	}
}
