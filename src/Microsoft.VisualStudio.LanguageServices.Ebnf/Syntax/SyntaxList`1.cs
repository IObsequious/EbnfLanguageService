using System;
using System.Collections;
using System.Collections.Generic;

namespace Ollon.VisualStudio.Languages.Syntax
{
    public partial struct SyntaxList<T> : IReadOnlyList<T>, IEquatable<SyntaxList<T>>
    {
        private readonly T[] _array;

        public SyntaxList(params T[] items)
                    : this(items != null
                    ? new List<T>(items)
                        : new List<T>()
                )
        {

        }

        public SyntaxList(IEnumerable<T> items)
                    : this(items != null
                    ? new List<T>(items)
                        : new List<T>()
                )
        {

        }
        public SyntaxList(List<T> list) : this()
        {
            _array = CreateArray(list);
        }

        public T this[int index]
        {
            get
            {
                if (_array != null && _array.Length > 0)
                {
                    return _array[index];
                }

                return default(T);
            }
        }

        public int Count
        {
            get
            {
                if (_array == null)
                    return 0;

                return _array.Length;
            }
        }

        public SyntaxList<T> Insert(T item, int index)
        {
            return InsertRange(index, new T[] { item });
        }
        public SyntaxList<T> InsertRange(int index, IEnumerable<T> range)
        {
            List<T> list = ToList();
            list.InsertRange(index, range);
            return new SyntaxList<T>(list);
        }

        public SyntaxList<T> Remove(T item, int index)
        {
            return RemoveRange(index, 1);
        }
        public SyntaxList<T> RemoveRange(int index, int count)
        {
            List<T> list = ToList();
            list.RemoveRange(index, count);
            return new SyntaxList<T>(list);
        }

        public SyntaxList<T> Add(T item)
        {
            List<T> list = ToList();
            list.Add(item);
            return new SyntaxList<T>(list);
        }
        public SyntaxList<T> Remove(T item)
        {
            return RemoveRange(IndexOf(item), 1);
        }

        public SyntaxList<T> AddRange(IEnumerable<T> items)
        {
            List<T> list = ToList();
            list.AddRange(items);
            return new SyntaxList<T>(list);
        }

        public T First()
        {
            return this[0];
        }

        public T FirstOrDefault()
        {
            if (Count >= 1)
            {
                return First();
            }

            return default(T);
        }

        public T Last()
        {
            return this[Count - 1];
        }

        public T LastOrDefault()
        {
            if (Count >= 1)
            {
                return Last();
            }

            return default(T);
        }

        public int IndexOf(T item)
        {
            List<T> list = ToList();
            return list.IndexOf(item);
        }

        public int LastIndexOf(T item)
        {
            List<T> list = ToList();
            return list.LastIndexOf(item);
        }

        public static bool operator ==(SyntaxList<T> left, SyntaxList<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SyntaxList<T> left, SyntaxList<T> right)
        {
            return !left.Equals(right);
        }

        public List<T> ToList()
        {
            if (_array == null || _array.Length < 1)
                return new List<T>();

            return new List<T>(_array);
        }

        public T[] ToArray()
        {
            return _array;
        }

        public IEnumerable<T> AsEnumerable()
        {
            return ToList();
        }

        private static int CountItems(IEnumerable<T> items)
        {
            int i = 0;
            foreach (T item in items)
                i++;

            return i;
        }

        private static T[] CreateArray(IEnumerable<T> items)
        {
            int itemsCount = CountItems(items);

            T[] array = new T[itemsCount];

            int i = 0;
            foreach (T item in items)
            {
                array[i] = item;
                i++;
            }

            return array;
        }

        /// <summary>
        /// The GetEnumerator
        /// </summary>
        /// <returns>The <see cref="IEnumerator{T}"/></returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public Enumerator GetEnumerator() => new Enumerator(this);

        /// <summary>
        /// The GetEnumerator
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public override bool Equals(object obj)
        {
            return obj is SyntaxList<T> && Equals((SyntaxList<T>)obj);
        }

        public bool Equals(SyntaxList<T> other)
        {
            return EqualityComparer<T[]>.Default.Equals(_array, other._array);
        }

        public override int GetHashCode()
        {
            var hashCode = -1308253065;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<T[]>.Default.GetHashCode(_array);
            return hashCode;
        }

        public struct Enumerator : IEnumerator<T>
        {
            private SyntaxList<T> _list;
            private int _index;

            internal Enumerator(SyntaxList<T> list)
                : this()
            {
                _list = list;
                _index = -1;
            }

            public bool MoveNext()
            {
                if (_index < _list.Count)
                {
                    _index++;
                }

                return _index < _list.Count;
            }

            public T Current => _list[_index];

            object IEnumerator.Current => this.Current;

            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            void IDisposable.Dispose()
            {
            }

            public override bool Equals(object obj)
            {
                throw new NotSupportedException();
            }

            public override int GetHashCode()
            {
                throw new NotSupportedException();
            }
        }
    }
}
