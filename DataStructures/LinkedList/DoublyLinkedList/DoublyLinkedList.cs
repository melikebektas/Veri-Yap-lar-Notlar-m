using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T>: IEnumerable<T>
    {
        private bool isHeadNull => Head == null;

        //listenin başını gösterir
        public DoublyLinkedListNode<T> Head { get; set; }
        //listenin sonunu gösterir
        public DoublyLinkedListNode<T> Tail { get; set; }
        public void AddFirst(T value)
        {
            var NewNode = new DoublyLinkedListNode<T>(value);

            if (Head != null)
            {
                Head.Prev = NewNode;
            }
            NewNode.Next = Head;
            NewNode.Prev = null;

            Head = NewNode;

            if (Tail == null)
            {
                Tail = Head;
            }
        }

        public void AddLast(T value)
        {
            if (Tail == null)
            {
                AddFirst(value);
                return;
            }

            var NewNode = new DoublyLinkedListNode<T>(value);

            NewNode.Prev = Tail;
            NewNode.Next = null;
            Tail.Next = NewNode;
            Tail = NewNode;
            return;
        }

        public void AddAfter(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            //refNode parametresi boş olamaz
            if (refNode == null)
                throw new ArgumentNullException();

            //Listede tek bir düğümün olması durumu  
            //Tek düğüm hem Head hem de Tail
            if (refNode == Head && refNode == Tail)
            {
                refNode.Next = newNode;
                refNode.Prev = null;

                newNode.Prev = refNode;
                newNode.Next = null;

                Head = refNode;
                Tail = newNode;

                return;
            }
            //refNode != Tail ise araya ekleme işlemi 
            if (refNode != Tail)
            {
                newNode.Next = refNode.Next;
                newNode.Prev = refNode;

                refNode.Next = newNode;
                refNode.Next.Prev = newNode;
            }
            //refNode == Tail yani kuyruğun sonuna ekleme
            else
            {
                newNode.Next = null;
                newNode.Prev = refNode;

                refNode.Next = newNode;

                Tail = newNode;

            }
        }
        public void AddBefore(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            //refNode parametresi boş olamaz
            if (refNode == null)
                throw new ArgumentNullException();

            if(refNode == Head && refNode == Tail)
            {
                newNode.Next = refNode;
                newNode.Prev = null;

                refNode.Prev = newNode;
                refNode.Next = null;


                Head = newNode;
                Tail = refNode;

                return;
            }
            if (refNode != Tail) 
            {
                newNode.Next = refNode;
                newNode.Prev = refNode.Prev;

                refNode.Prev = newNode;
                refNode.Prev.Next = newNode;
                
            }
            else 
            {
                newNode.Next = refNode;
                newNode.Prev = refNode.Prev;

                refNode.Prev = newNode;
                refNode.Prev.Next = newNode;
                Tail = refNode;
            }
        }
        public T RemoveFirst()
        {
            if (isHeadNull)
                throw Exception("listede eleman bulunmamaktadır");

            var temp = Head.Value;
            if(Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
            }
            return temp;
        }
         public T RemoveLast() 
        {
            if (isHeadNull)
                throw Exception("listede eleman bulunmamaktadır");

            var temp = Tail.Value;
            if (Tail  == Head)
            {
                Head = null;
                Tail = null;
            }
            else 
            {   
                Tail.Prev.Next = null;
                Tail = Tail.Prev;      
            }
            return temp;

        }
        public void Remove(T value)
        {
            if (isHeadNull)
                throw Exception("listede eleman bulunmamaktadır");

            //kuyrukta tek eleman olması durumu
            if (Head == Tail)
            {
                if (Head.Value.Equals(value)) 
                {
                    RemoveFirst();
                }
                return;
            }
            //en az iki eleman olması durumu
            var current = Head;
            while(current != null)
            {
                if (current.Value.Equals(value))
                {
                    //current -> ilk eleman ise 
                    if (current.Prev == null) 
                    {
                        current.Next.Prev = null;
                        Head = current.Next;
                    }
                    //current -> son eleman ise
                    else if (current.Next == null) 
                    {
                        current.Prev.Next = null;
                        Tail = current.Prev;
                    }
                    //current -> arada bir eleman ise
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    break;
                }
                current = current.Next;
            }
        }

        private Exception Exception(string v)
        {
            throw new NotImplementedException();
        }

        private List<DoublyLinkedListNode<T>> GetAllNodes()
        {
            var list = new List<DoublyLinkedListNode<T>>();
            var current = Head;
            while (current != null)
            {
                list.Add(current);
                current = current.Next;
            }
            return list;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}