using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyCollection
{
    internal class MyCollection : IList<uint>
    {
        public int Count { get; private set; }
        public bool IsReadOnly { get; }

        private uint[] thisArray;

        public MyCollection()
        {
            IsReadOnly = false;
            thisArray = new uint[10];
            Count = 0;
        }

        public MyCollection(params uint[] arr) : this()
        {
            if (arr.Length >= thisArray.Length)
            {
                thisArray = new uint[arr.Length * 2];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                thisArray[i] = arr[i];
            }
            Count = arr.Length;
        }

        public uint this[int index]
        {
            get
            {
                try
                {
                    return thisArray[index];
                }
                catch (IndexOutOfRangeException e)
                {
                    throw new IndexOutOfRangeException("Going outside the array.");
                }
            }
            set
            {
                throw new Exception("This collection does not support recording in this way");
            }
        }

        public void Add(uint item)
        {
            thisArray[Count] = item;
            Count++;

            IncreaseTheArray();
        }

        public void Clear()
        {
            uint[] newArray = new uint[10];
            thisArray = newArray;
            Count = 0;
        }

        public bool Contains(uint item)
        {
            foreach (uint value in thisArray)
            {
                if (value == item)
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(uint[] array, int arrayIndex)
        {
            if (arrayIndex >= Count)
            {
                throw new IndexOutOfRangeException("Going outside the array.");
            }

            for (int i = 0; i < Count - arrayIndex; i++)
            {
                array[i] = thisArray[arrayIndex + i];
            }
        }

        public IEnumerator<uint> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return thisArray[i];
            }
        }

        public int IndexOf(uint item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (thisArray[i] == item)
                {
                    return i;
                }
            }

            return -1;
        }


        public void Insert(int index, uint item)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Going outside the array.");
            }

            Count++;
            for (int i = Count; i > index; i--)
            {
                thisArray[i] = thisArray[i - 1];
            }
            thisArray[index] = item;

            IncreaseTheArray();
        }

        public bool Remove(uint item)
        {
            bool isRemoved = false;
            int index = -1;

            foreach (uint value in thisArray)
            {
                index++;
                if (value == item)
                {
                    isRemoved = true;
                    Count--;
                    break;
                }
            }

            if (isRemoved)
            {
                for (int i = index; i < Count; i++)
                {
                    thisArray[i] = thisArray[i + 1];
                    //Console.WriteLine(thisArray[index]);
                }
            }

            return isRemoved;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Going outside the array.");
            }

            Count--;

            for (int i = index; i < Count; i++)
            {
                thisArray[i] = thisArray[i + 1];
            }
        }

        private void IncreaseTheArray()
        {
            if ((thisArray.Length / 2) > Count)
            {
                uint[] newArray = new uint[thisArray.Length * 2];
                CopyTo(newArray, 0);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return thisArray[i];
            }
        }
    }
}
