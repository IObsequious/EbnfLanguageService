using System;
using System.Collections;
using System.Collections.Generic;

namespace Ollon.VisualStudio.Languages.Syntax
{
    public partial struct SyntaxList<T>
    {
        public struct Builder : IList<T>, IReadOnlyList<T>
        {
            private List<T> _list;
            public Builder(int capacity)
            {
                _list = new List<T>();
            }

            public T this[int index]
            {
                get
                {
                    return _list[index];
                }

                set
                {
                    _list[index] = value;
                }
            }

            public int Count
            {
                get
                {
                    return _list.Count;
                }
            }

            public bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            public T[] ToArray() => _list.ToArray();

            public SyntaxList<T> ToList() => SyntaxList.CreateRange<T>(ToArray());

            public void Add(T item)
            {
                _list.Add(item);
            }

            public void AddRange(IEnumerable<T> range)
            {
                _list.AddRange(range);
            }

            public void Clear()
            {
                _list.Clear();
            }

            public bool Contains(T item)
            {
                return _list.Contains(item);
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                _list.CopyTo(array, arrayIndex);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return _list.GetEnumerator();
            }

            public int IndexOf(T item)
            {
                return _list.IndexOf(item);
            }

            public void Insert(int index, T item)
            {
                _list.Insert(index, item);
            }

            public bool Remove(T item)
            {
                return _list.Remove(item);
            }

            public void RemoveAt(int index)
            {
                _list.RemoveAt(index);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return _list.GetEnumerator();
            }
        }
    }
}
