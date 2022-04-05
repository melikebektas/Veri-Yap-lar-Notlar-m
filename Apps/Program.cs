using DataStructures.Tree.BST;
using DataStructures.Tree.Binary_Tree;

namespace Apps
{

    class Program
    {
        static void Main(string[] args)
        {
            var arr  = new int[] {16, 23, 44,  12, 55, 40, 6};
          
            DataStructures.SortingAlgorithm.BubbleSort.Sort<int>(arr);

            foreach (int i in arr)
            {
                Console.WriteLine(i + " ");
            }
          /*  var graph = new DataStructures
                .Graph.AdjacencySet.
                WeightedGraph<char, double>(new char[] {'A', 'B', 'C', 'D'});

            graph.AddEdge('A', 'B', 1.2);
            graph.AddEdge('A', 'D', 2.3);
            graph.AddEdge('D', 'C', 5.5);

            Console.WriteLine("Is there an edge between A and B ? {0}", graph.HasEdge('A', 'B') ? "Yes" : "No");
            Console.WriteLine("Is there an edge between B and A ? {0}", graph.HasEdge('B', 'A') ? "Yes" : "No");

            foreach (char vertex in graph)
            {
                Console.WriteLine(vertex);
            }
         //   Console.WriteLine($"Number of vertex count {graph.Count}");

            /*var graph = new DataStructures.Graph.AdjacencySet.Graph<char>(new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G'});
            foreach(var vertex in graph)
            {
                Console.WriteLine(vertex);
            }

            Console.WriteLine($"nomber of graph vertex: {graph.Count}");

            graph.AddEdge('A','B');
            graph.AddEdge('A','C');
            graph.AddEdge('C','D');
            graph.AddEdge('C','E');
            graph.AddEdge('D','E');
            graph.AddEdge('E','F');
            graph.AddEdge('F','G');

            Console.WriteLine("Is there an edge between A and B ? {0} ", graph.HasEdge('A','B') ? "YES" : "NO");
            Console.WriteLine("Is there an edge between A and B ? {0} ", graph.HasEdge('A','D') ? "YES" : "NO");

            foreach(var key in graph)
            {
                Console.WriteLine(key);
                foreach(var vertex in graph.GetVertex(key).Edges)
                    Console.WriteLine("    " + vertex);
            }
            */
            //bheap yapısından nesne oluşturmadık çünkü abstract class
            //var heap = new DataStructures.Heap.MinHeap<int>(new int[] { 7, 4, 8, 1, 5, 10, 9, 11, 9, 6, 2 });

            /* var heap = new DataStructures.Heap.MaxHeap<int>(new int[] { 54, 45, 36, 27, 29, 18, 21, 99 });
             heap.DeleteMinMax();

             foreach (var item in heap)
             {
                 Console.WriteLine(item);
             }
             /*var BST = new BST<int>(new int [] {23, 16, 45, 3, 22, 37, 99});

             var list = new BinaryTree<int>().InOrder(BST.Root);
             Console.WriteLine("InOrder");
             foreach (var node in list)
             {
                 Console.WriteLine(node);    
             }
             Console.WriteLine("PreOrder");
             var list2 = new BinaryTree<int>().PreOrder(BST.Root);

             foreach (var node in list2)
             {
                 Console.WriteLine(node);
             }
             Console.WriteLine("PostOrder");
             var list3 = new BinaryTree<int>().PostOrder(BST.Root);

             foreach (var node in list3)
             {
                 Console.WriteLine(node);
             }
             var list4 = new BinaryTree<int>().LevelOrderNonRecursiveTraversal(BST.Root);
             foreach (var node in list4)
             {
                 Console.WriteLine(node);
             }

             Console.WriteLine("en küçük eleman " + BST.FindMin(BST.Root));
             Console.WriteLine("en büyük eleman " + BST.FindMax(BST.Root));

             BST.Find(BST.Root, 16);

             /*var numbers = new int[] { 10, 20, 30};
             var q1 = new DataStructures.Queue.Queue<int>();
             var q2 = new DataStructures.Queue.Queue<int>(QueueType.LinkedList);

             foreach (var number in numbers)
             {
                 Console.WriteLine(number);
                 q1.EnQueue(number);
                 q2.EnQueue(number);
             }

             Console.WriteLine(q1.Count);
             Console.WriteLine(q2.Count);

             Console.WriteLine(q1.DeQueue() + " has been removed q1");
             Console.WriteLine(q2.DeQueue() + " has been removed q2");

             Console.WriteLine(q1.Count);
             Console.WriteLine(q2.Count);

             Console.WriteLine(q1.Peek());
             Console.WriteLine(q2.Peek());
             */
            /*  var charset = new char[] { 'a', 'b', 'c', 'd', 'e' };
              var stack1 = new DataStructures.Stack.Stack<char>();
              var stack2 = new DataStructures.Stack.Stack<char>(StackType.LinkedList);

              foreach (char c in charset)
              {
                  Console.WriteLine(c);
                  stack1.Push(c);
                  stack2.Push(c);
              }
              Console.WriteLine("Peek : ");
              Console.WriteLine(stack1.Peek());
              Console.WriteLine(stack2.Peek());

              Console.WriteLine("Count : ");
              Console.WriteLine(stack1.Count);
              Console.WriteLine(stack2.Count);

              Console.WriteLine("Pop : ");
              Console.WriteLine(stack1.Pop() + " has been removed");
              Console.WriteLine(stack2.Pop() + " has been removed");
              /*
              var liste = new DoublyLinkedList<int>();
              liste.AddFirst(12);
              liste.AddFirst(23);

              liste.AddLast(44);
              liste.AddLast(55);

              liste.AddAfter(liste.Head.Next, new DoublyLinkedListNode<int>(13));

              foreach (int item in liste)
              {
                  Console.WriteLine(item);
              }

              var p1 = new DataStructures.Array.Array<int>(1, 2, 3, 4);
               var p2 = new int[] { 8,9, 10, 11, 12};
               var p3 = new List<int> { 5, 15, 20, 25 };
               var p4 = new ArrayList() { 12, 13, 14 }; //tip güvenliği mevcut değil generic değil hata verir. */

            /* var arr = new DataStructures
                 .Array
                 .Array<int>();

            /* foreach (int i in arr)
             {
                 Console.WriteLine(i);
             }*/

            /*for (int j = 0; j < 8; j++)
            {
                arr.Add(j);
                Console.WriteLine($"{j+1} has been added to array");
                Console.WriteLine($"{arr.Count}/{arr.Capacity}");
            }
            Console.WriteLine();

            for (int i=arr.Count; i>=1; i--) 
            { 
                Console.WriteLine($"{arr.Remove()} has been removed from the array");
                Console.WriteLine($"{arr.Count}/{arr.Capacity}");
            }

          /*arr.Add(22);
            arr.Add(11);
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);

            arr.Remove();

            foreach(var item in arr)
            {
                Console.WriteLine(item);
            } 

            //liste içerisinde yer alan ikiye bölünebilen elemanaları ekrana yazdırdık
            /*arr.Where(x=> x %2 ==0).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine($"{arr.Count}/{arr.Capacity}");
            Console.ReadKey();
        }*/
            /*
                        // linked list oluşturduk
                        var linkedList = new SinglyLinkedList<int>();

                        linkedList.AddFirst(1);
                        linkedList.AddFirst(2);
                        linkedList.AddFirst(3);
                        //3 2 1  O(1)

                        linkedList.AddLast(4);
                        linkedList.AddLast(5);
                        // 3 2 1 4 5 O(n) döngü var

                        linkedList.AddAftter(linkedList.Head.Next, 32);
                        linkedList.AddAftter(linkedList.Head.Next, 33);
                        // 3 2 32 33 1 4 5 O(n) döngü var

                        var list = new LinkedList<int>();
                        list.AddFirst(1);
                        list.AddFirst(2);
                        list.AddFirst(3);

                        foreach (var item in list) 
                        {
                            //Console.WriteLine(item);
                        }

                        foreach (var item in linkedList) 
                        {
                           // Console.WriteLine(item);
                        }

                        var arr = new char[] {'a', 'b', 'c' };
                        var arrList = new ArrayList(arr);
                        var list1 = new List<char>(arr);
                        var clinkedList = new LinkedList<char>(arr);

                        var linkedlist = new SinglyLinkedList<char>(arr);

                        foreach (var item in linkedlist)
                        { //Console.WriteLine(item);
                        }

                        var rnd = new Random();
                        var initial = Enumerable .Range(1,10).OrderBy(x => rnd.Next()).ToList();
                        var linkedlist2 = new SinglyLinkedList<int>(initial);

                        //LINQ- Link Integrated Query
                        var q = from item in linkedlist2
                                where item%2==1
                                select item;

                       // linkedlist2.Where(x => x > 5).ToList().ForEach(x=> Console.Write(x +  " "));
                        foreach (var item in q) { //Console.WriteLine(item); 
                        }

                        linkedlist2.RemoveFirst();
                        foreach (var item in linkedlist2) { Console.WriteLine("linkedlist2" +item); }

                        linkedlist.RemoveLast();   */
        }

        /* private static string FindMin(Node<int> root)
         {
             throw new NotImplementedException();
         }*/
    }
}
