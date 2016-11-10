using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_3_3
{
    public class DynamicArray<T> : IList<T>, IList, ICollection<T>, ICollection, IEnumerable<T>, IEnumerable, ICloneable
    {
        protected T[] arrayItems;

        public DynamicArray() : this(8)
        {
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
            this.Length = collection.Count();
            Array.Copy((Array)collection, this.arrayItems, this.Capacity);
        }

        public int Capacity
        {
            get
            {
                return this.arrayItems.Length;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                Array.Resize(ref this.arrayItems, value);
            }
        }

        public int Length { get; private set; }

        public T this[int index]
        {
            get
            {
                if (Math.Abs(index) > this.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (index < 0)
                {
                    return this.arrayItems[this.Length + index];
                }

                return this.arrayItems[index];
            }

            set
            {
                {
                    if (Math.Abs(index) > this.Length)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    if (index < 0)
                    {
                        this.arrayItems[this.Length + index] = value;
                    }
                    else
                    {
                        this.arrayItems[index] = value;
                    }
                }
            }
        }

        private void CapacityChanger(int degree)
        {
            this.Capacity *= 2 * degree;
            Array.Resize(ref this.arrayItems, this.Capacity);
        }

        object IList.this[int index]
        {
            get
            {
                return this[index];
            }

            set
            {
                this[index] = (T)value;
            }
        }

        int ICollection.Count => this.Length;

        int ICollection<T>.Count => this.Length;

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public bool IsSynchronized => this.arrayItems.IsSynchronized;

        public object SyncRoot => this.arrayItems.SyncRoot;

        int IList.Add(object value)
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

            this[Length] = item;
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
            this.Length = 0;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        bool IList.Contains(object value) => this.Contains((T)value);

        public bool Contains(T item)
        {
            return this.arrayItems.Contains(item);
        }

        void ICollection.CopyTo(Array array, int index) => this.CopyTo((T[])array, index);

        public void CopyTo(T[] array, int arrayIndex)
        {
            int j = arrayIndex;
            for (int i = 0; i < this.Length; i++)
            {
                array.SetValue(arrayItems[i], j);
                j++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this.arrayItems, this.Length);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        int IList.IndexOf(object value) => this.IndexOf((T)value);

        public int IndexOf(T item)
        {
            return Array.IndexOf(arrayItems, item, 0, Length);
        }

        void IList.Insert(int index, object value) => this.Insert(index, (T)value);

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

        void IList.Remove(object value) => this.Remove((T)value);

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

            this.Length--;
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

            this.Length--;
        }

        public T[] ToArray()
        {
            T[] arrayCopy = new T[this.Length];
            Array.Copy(this.arrayItems, arrayCopy, Length);
            return arrayCopy;
        }

        internal class Enumerator : IEnumerator<T>, IEnumerator
        {
            private int last = -1;
            private T[] array;
            private int length;

            internal Enumerator(T[] array, int length)
            {
                this.array = array;
                this.length = length;
            }

            public T Current
            {
                get
                {
                    if (this.last < 0 || this.last > length - 1)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return this.array[this.last];
                }
            }

            object IEnumerator.Current => this.Current;

            public bool MoveNext()
            {
                return ++this.last < this.length;
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