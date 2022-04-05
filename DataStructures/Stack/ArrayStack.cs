namespace DataStructures.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        public int Count { get; private set; }
        private readonly List<T> list = new List<T>();

        public T Peek()
        {
            //stack yapısında hiç eleman yok ise
            if (Count == 0)
                throw new ArgumentNullException("stack yapısında eleman bulunmamaktadır");

            return list[list.Count - 1];
        }

        public T Pop()
        {
            //stack yapısında hiç eleman yok ise
            if (Count == 0)
                throw new ArgumentNullException("stack yapısında eleman bulunmamaktadır");

            var temp = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            Count--;
            return temp;
        }

        public void Push(T value)
        { 
            if(value == null)
                throw new ArgumentNullException("eklenecek veri bulunmamaktadır");

            list.Add(value);
            Count++;

        }
    }
}