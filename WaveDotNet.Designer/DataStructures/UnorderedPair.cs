using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveDotNet.Designer.DataStructures
{
	internal struct UnorderedPair<T> : IEnumerable<T>
	{
		private T _first;
		private T _second;

		public UnorderedPair(T first, T second)
		{
			_first = first;
			_second = second;
		}

		public bool Has(T value)
		{
			return object.Equals(_first, value) || object.Equals(_second, value);
		}

		public T Second(T value)
		{
			if (object.Equals(value, _first))
				return _second;
			if (object.Equals(value, _second))
				return _first;

			throw new InvalidOperationException("Unordered pair doesn't store given element");
		}

		public IEnumerator<T> GetEnumerator()
		{
			yield return _first;
			yield return _second;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public override bool Equals(object obj)
		{
			if (obj is UnorderedPair<T> value)
				return this.Equals(value);

			return false;
		}

		public bool Equals(UnorderedPair<T> value)
		{
			return
				object.Equals(_first, value._first) && object.Equals(_second, value._second) ||
				object.Equals(_first, value._second) && object.Equals(_second, value._first);
		}

		public override int GetHashCode()
		{
			return _first.GetHashCode() ^ _second.GetHashCode();
		}

		public static bool operator ==(UnorderedPair<T> lhs, UnorderedPair<T> rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(UnorderedPair<T> lhs, UnorderedPair<T> rhs)
		{
			return !(lhs.Equals(rhs));
		}
	}
}
