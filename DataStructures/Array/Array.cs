using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Array
{

    //IEnumerable ifadesi numaralndırma yeteneği sağlar.
    //IClonable ilgili Array'in kopyalanabilme yeteneğini sağlar.

    public class Array<T> : IEnumerable<T>, ICloneable
    {
        private T[] InnerList;

        public int Count { get; private set; }
        public int Capacity => InnerList.Length;

        public Array()
        {
            InnerList  = new T[2];
            Count = 0;
        }

        public Array(params T[] initial)
        {
            InnerList = new T[initial.Length];
            Count = 0;
            for (int i = 0; i < initial.Length; i++)
                Add(initial[i]);
        }
        public Array(IEnumerable<T> collection)
        {
            InnerList = new T[collection.ToArray().Length];
            Count=0;
            foreach (var item in collection)
                Add(item);
        }

        public void Add(T item) 
        {
            if (InnerList.Length == Count)
            {
                DoubleArray();
            }
            InnerList[Count] = item;
            Count++;

        }

        private void DoubleArray()
        {
            var temp = new T[InnerList.Length * 2];
            System.Array.Copy(InnerList, temp, InnerList.Length);
            InnerList = temp;

        }
        public T Remove()
        {
            if (Count== 0)
            {
                Console.WriteLine("dizide eleman bulunmamaktadır.");
            }

            if (InnerList.Length / 4 == Count) 
            {
                HalfArray();
            }

            var temp = InnerList[Count - 1];

            if(Count>0)
                Count--;
            return temp;
        }

        private void HalfArray()
        {
            if (InnerList.Length > 2)
            {
                var temp = new T[InnerList.Length / 2];
                System.Array.Copy(InnerList, temp, InnerList.Length / 4);
                InnerList = temp;
            }
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InnerList.Take(Count).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }

    }
}
