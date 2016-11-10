using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_XT2016_3_3_3
{
    public class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable
    {
        public CycledDynamicArray() : base()
        {
        }

        public CycledDynamicArray(int capacity) : base(capacity)
        {
        }

        public CycledDynamicArray(IEnumerable<T> collection) : base(collection)
        {
        }

        public new IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this.arrayItems, this.Length);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public new class Enumerator : IEnumerator<T>, IEnumerator
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
                    return this.array[this.last % this.length];
                }
            }

            object IEnumerator.Current => this.Current;

            public bool MoveNext()
            {
                if (this.length == 0)
                    return false;
                return (++this.last % this.length) < length;
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