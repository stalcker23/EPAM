using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_3_3
{
    public class Dy<T> : IList<T>, IList, ICollection<T>, ICollection, IEnumerable<T>, IEnumerable
    {
        private T[] arrayItems;

        public DynamicArray()
        {
            this.Capacity = 8;
            this.arrayItems = new T[this.Capacity];
            this.Length = 0;
        }

        public DynamicArray(int capacity)
        {
            this.Capacity = capacity;
            this.arrayItems = new T[this.Capacity];
            this.Length = 0;
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            this.Capacity = collection.Count();
            this.arrayItems = new T[this.Capacity];

            Array.Copy((Array)collection, this.arrayItems, this.Capacity);
        }

        public int Capacity { get; private set; }

        public int Length { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index > this.Count() || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this.arrayItems[index];
            }

            set
            {
                this.arrayItems[index] = value;
            }
        }

        public void CapacityChanger(int degree)
        {
            this.Capacity *= 2 * degree;
            Array.Resize(ref this.arrayItems, this.Capacity);
        }

        object IList.this[int index]
        {
            get
            {
                if (index > this.Count() || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this.arrayItems[index];
            }

            set
            {
                this.arrayItems[index] = (T)value;
            }
        }

        int ICollection.Count { get; }
        int ICollection<T>.Count { get; }

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public bool IsSynchronized => this.arrayItems.IsSynchronized;

        public object SyncRoot => this.arrayItems.SyncRoot;

        public int Add(object value)
        {
            this.Add((T)value);
            return this.arrayItems.Length - 1;
        }

        public void Add(T item)
        {
            if (this.Capacity == this.Length)
            {
                this.CapacityChanger(1);
            }

            this[this.Length] = item;
            this.Length++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (this.Capacity < this.Length + collection.Count())
            {
                this.CapacityChanger((this.Length + collection.Count()) / this.Capacity);
            }

            foreach (var item in collection)
            {
                this.Add(item);
            }
        }

        public void Clear()
        {
            this.arrayItems = new T[8];
            this.Length = 0;
        }

        public bool Contains(object value) => this.Contains((T)value);

        public bool Contains(T item)
        {
            return this.arrayItems.Contains(item);
        }

        public void CopyTo(Array array, int index)
        {
            Array.Copy(this.arrayItems, index, array, 0, arrayItems.Length - index);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(this.arrayItems, arrayIndex, array, 0, arrayItems.Length - arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this.arrayItems);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public int IndexOf(object value) => this.IndexOf((T)value);

        public int IndexOf(T item)
        {
            return Array.IndexOf(arrayItems, item);
        }

        public void Insert(int index, object value) => this.Insert(index, (T)value);

        public void Insert(int index, T item)
        {
            if (this.Length + 1 > this.Capacity)
            {
                this.CapacityChanger(1);
            }

            this.Length++;
            for (int i = this.Length - 1; i >= index; i--)
            {
                this[i] = this[i - 1];
            }

            this[index] = item;
        }

        public void Remove(object value) => this.Remove((T)value);

        public bool Remove(T item)
        {
            var containsItem = Array.IndexOf(this.arrayItems, item);
            if (containsItem == -1)
            {
                return false;
            }

            for (int i = containsItem; i <= this.Length - 1; i++)
            {
                if (i != this.Length - 1)
                {
                    this[i] = this[i + 1];
                }
                else
                {
                    this[i] = default(T);
                }
            }

            this.Length -= 1;
            return true;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i <= this.Length - 1; i++)
            {
                if (i != this.Length - 1)
                {
                    this[i] = this[i + 1];
                }
                else
                {
                    this[i] = default(T);
                }
            }

            this.Length -= 1;
        }

        public class Enumerator : IEnumerator<T>, IEnumerator
        {
            private int last = -1;
            private T[] array;

            internal Enumerator(T[] array)
            {
                this.array = array;
            }

            public T Current
            {
                get
                {
                    if (this.last < 0 || this.last >= this.array.Length)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return this.array[this.last];
                }
            }

            public int Count
            {
                get
                {
                    return array.Count();
                }
            }

            object IEnumerator.Current => this.Current;

            public bool MoveNext()
            {
                return ++this.last < this.Count;
            }

            public void Reset()
            {
                this.last = -1;
            }

            void IDisposable.Dispose()
            {
            }
        }
    }
}