using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private bool isHeadNull;

        public SinglyLinkedList() { }

        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection) { this.AddFirst(item); }
        }

        //listenin başını head gösterir
        public SinglyLinkedListNode<T> Head { get; set; }

        public void AddFirst(T value) {

            var NewNode = new SinglyLinkedListNode<T>(value);
            NewNode.Next = Head;
            Head = NewNode;

        }
        public void AddLast(T value)
        {
            var NewNode = new SinglyLinkedListNode<T>(value);

            //Listenin boş olması durumu
            if (Head == null) {

                Head = NewNode;
            }

            var current = Head;
            while (current != null) {

                current = current.Next;
            }
            current = NewNode;

        }


        public void AddAftter(SinglyLinkedListNode<T> node, T value)
        {
            if (node == null) {

                throw new ArgumentNullException();
            }

            if (Head == null)
            {
                AddFirst(value);
                return;
            }
            var NewNode = new SinglyLinkedListNode<T>(value);
            var current = Head;

            while (current != null) {
                if (current.Equals(node)) {

                    NewNode.Next = current.Next;
                    current.Next = NewNode;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException("The reference node is not in this list.");
        }

        public T RemoveFirst()
        {
            if (isHeadNull)
            {
                throw new Exception("silinecek herhangi bir eleman bulunmamaktadır.");
            }
            var FirstValue = Head.Value;
            Head = Head.Next;
            return FirstValue;
        }
        public T RemoveLast()
        {
            var current = Head;
            SinglyLinkedListNode<T> prev = null;

            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }

            var LastValue = prev.Next.Value;
            prev.Next = null;
            return LastValue;
        }
        public void Remove(T value) 
        {
            if (isHeadNull)
                throw new Exception("silinecek herhangi bir eleman bulunmamaktadır.");
            if (value==null)
                throw new ArgumentNullException();

            var current = Head;
            SinglyLinkedListNode<T> prev = null;
            do
            {
                if (current.Value.Equals(value))
                { 
                    //son eleman mı?
                    if(current == null)
                    {
                        // head
                        if (prev == null)
                        {
                            Head = null;
                            return;
                        }
                        //son eleman
                        else 
                        { 
                            prev.Next = null;
                            return;
                        }

                    }
                    else 
                    {   //head
                        if (prev == null)
                        {
                            Head = Head.Next;
                            return;
                        }
                        //ara düğüm
                        else
                        {
                            prev.Next = current.Next;
                            return;
                        }
                    }
                
                }
                prev = current;
                current = current.Next;

            } while (current!=null);
            throw new ArgumentException("silinecek eleman bulunamadı");
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
