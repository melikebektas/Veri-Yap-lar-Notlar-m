namespace DataStructures.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {

        //readonly ifadeler ya tanımlandığı yerde ya da constructor içerisinde başlatılması
        private readonly List<T> list = new List<T>(); 
        public int Count { get; private set; }

        public T DeQueue()
        {
            if (Count == 0)
                throw new Exception("kuruk boş, eleman bulunmamaktadır");

            var temp = list[0];
            list.RemoveAt(0);
            Count--;
            return temp;
        }

        public void EnQueue(T value)
        {
            if (value == null)
                throw new ArgumentNullException("eklenecek bir değer girilmemiştir");

            list.Add(value);
            Count++;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new Exception("kuruk boş, eleman bulunmamaktadır");

            return list[0];
        }
    }
}