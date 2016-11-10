using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EPZM_XT2016_3_4
{
    internal class SortingArray<T>
    {
        private T[] arrayForSort;
        private Func<T, T, int> comparing;
        private static int countOfSorting = 0;

        public T[] ArrayForSort
        {
            get
            {
                return arrayForSort;
            }

            set
            {
                if (value == null)
                    throw new ArgumentException(nameof(arrayForSort));
                this.arrayForSort = value;
            }
        }

        public Func<T, T, int> Comparing
        {
            get
            {
                return comparing;
            }

            set
            {
                this.comparing = value;
            }
        }

        public SortingArray(T[] arrayForSort, Func<T, T, int> comparing)
        {
            this.arrayForSort = arrayForSort;
            this.comparing = comparing;
        }

        public class SortingEventArgs : EventArgs
        {
            public int CountOfSorting { get; }

            public SortingEventArgs(int count)
            {
                CountOfSorting = count;
            }
        }

        public event EventHandler<SortingEventArgs> SortingEnded;

        protected virtual void OnSortingEnded(int i)
        {
            SortingEnded?.Invoke(this, new SortingEventArgs(i));
        }

        public void StartInAnotherThread(T[] array, Func<T, T, int> comparing)
        {
            new Thread(() => this.ArraySort()).Start();
        }

        public void StartInSameThread(T[] array, Func<T, T, int> comparing)
        {
            this.ArraySort();
        }

        public void ArraySort()
        {
            if (Comparing == null)
            {
                throw new ArgumentNullException(nameof(Comparing));
            }
            {
                bool flagToEnd = true;
                do
                {
                    flagToEnd = false;
                    for (int i = 0; i < arrayForSort.Count() - 1; i++)
                    {
                        if (Comparing(arrayForSort[i], arrayForSort[i + 1]) < 0)
                        {
                            T j = arrayForSort[i];
                            arrayForSort[i] = arrayForSort[i + 1];
                            arrayForSort[i + 1] = j;
                            flagToEnd = true;
                        }
                    }
                } while (flagToEnd);
            }
            this.Print(arrayForSort);
            OnSortingEnded(++countOfSorting);
        }

        private void Print(T[] arraySort)
        {
            foreach (var item in arraySort)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}