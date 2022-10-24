using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Implementations.Generic
{
    public class GenericList<T> : ICollection<T>
    {
        private ICollection<T> _items;

        public GenericList()
        {
            _items = new List<T>();
        }

        public GenericList(ICollection<T> collection)
        {
            _items = collection;
        }

        public int Count => _items.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items?.Clear();
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class CountryRanking
    {
        public long PersonId { get; set; }
        public string Country { get; set; }
        public int Rank { get; set; }
    }
}
