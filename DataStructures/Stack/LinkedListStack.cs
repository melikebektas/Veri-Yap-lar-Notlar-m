using DataStructures.LinkedList.SinglyLinkedList;

namespace DataStructures.Stack
{
    public class LinkedListStack<T> : IStack<T>
    {
        private readonly SinglyLinkedList<T> list = new SinglyLinkedList<T>();
        public int Count { get; private set; }

        public T Peek()
        {
            //stack yapısında hiç eleman yok ise
            if (Count == 0)
                throw new ArgumentNullException("stack yapısında eleman bulunmamaktadır");

            return list.Head.Value;
        }

        public T Pop()
        {
            //stack yapısında hiç eleman yok ise
            if (Count == 0)
                throw new ArgumentNullException("stack yapısında eleman bulunmamaktadır");

            var temp = list.RemoveFirst();
            Count--;
            return temp;


        }

        public void Push(T value)
        {
            if (value == null)
                throw new ArgumentNullException("eklenecek veri bulunmamaktadır");

            list.AddFirst(value);
            Count++;
        }
    }
}