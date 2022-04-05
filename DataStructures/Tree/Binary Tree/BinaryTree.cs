using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataStructures.Tree.Binary_Tree
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public List<Node<T>> list { get; private set; }
        public BinaryTree()
        {
            list = new List<Node<T>>(); 
        }

        public List<Node<T>> InOrder(Node<T> root)
        {
            if (!(root == null))
            {
                InOrder(root.Left);
                list.Add(root);
                InOrder(root.Right);
            }
            return list;
        }
        public List<Node<T>> InOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var S = new DataStructures.Stack.Stack<Node<T>>();
            Node<T> currentNode = root;
            bool done = false;
            while (!done)
            {
                if (currentNode != null)
                {
                    S.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    if(currentNode == null)
                    {
                        done = true;    
                    }
                    else
                    {
                        currentNode = S.Pop();
                        list.Add(currentNode);
                        currentNode = currentNode.Right;
                    }
                }
            }
            return list;
        }

        public List<Node<T>> PreOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var S = new DataStructures.Stack.Stack<Node<T>>();

            if (root == null)
                throw new ArgumentNullException("ağaçta eleman bulunmamaktadır");

            S.Push(root);
            while (!(S.Count == 0))
            {
                var temp = S.Pop();
                list.Add(temp);
                if(temp.Right != null)
                    S.Push(temp.Right);
                if (temp.Left != null)
                    S.Push(temp.Left);
            }
            return list;
        }

        public List<Node<T>> LevelOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var Q = new DataStructures.Queue.Queue<Node<T>>();
            Q.EnQueue(root);

            while (Q.Count > 0)
            {
                var temp = Q.DeQueue();
                list.Add(temp);
                if (temp.Left != null)
                    Q.EnQueue(temp.Left);
                if (temp.Right != null)
                    Q.EnQueue(temp.Right);
            }
            return list;

        }

            public List<Node<T>> PreOrder(Node<T> root)
        {
            if (!(root == null))
            {
                list.Add(root);
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
            return list;
        }

        public List<Node<T>> PostOrder(Node<T> root)
        {
            if (!(root == null))
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                list.Add(root);
            }
            return list;
        }
        public static int MaxDepth(Node<T> root)
        {
            //ağaçta eleman yok derinlik 0
            if (root == null)
                return 0;

            int leftDepth = MaxDepth(root.Left);
            int rightDepth = MaxDepth(root.Right);

            return (leftDepth >= rightDepth) ?
                leftDepth+1:
                rightDepth+1;
        }

        //en derin düğümü geri döndüren method
        public Node<T> DeepestNode(Node<T> root)
        {
           Node<T> temp = null;
            if(root == null)
                throw new ArgumentNullException("ağaç yapısında eleman bulunmamaktadır");

            var q = new DataStructures.Queue.Queue<Node<T>>();
            q.EnQueue(root);
            while (q.Count > 0)
            {
                temp = q.DeQueue();
                if (temp.Left != null)
                    q.EnQueue(temp.Left);
                if (temp.Right != null)
                    q.EnQueue(temp.Right);
            }
            return temp;
        }

        //ağaç yapısındaki yaprak düğüm sayısını bulan method
        public static int NumberOfLeafs(Node<T> root)
        {
            int count = 0;

            if (root == null)
                return count;

            var q = new DataStructures.Queue.Queue<Node<T>>();
            q.EnQueue(root);
            while (q.Count > 0)
            {
                var temp = q.DeQueue();
                if (temp.Left == null && temp.Right == null)
                    count++;
                if (temp.Left != null)
                    q.EnQueue(temp.Left);
                if (temp.Right != null)
                    q.EnQueue(temp.Right);
            }
            return count;
        }
        //ağaç yapısındaki tam düğümlerin sayısını bulan method
        public static int NumberOfFullNodes(Node<T> root) => new BinaryTree<T>()
            .LevelOrderNonRecursiveTraversal(root)
            .Where(node => node.Left != null && node.Right != null)
            .ToList().Count;

        //ağaç yapısındaki yarım düğümlerin sayısını bulan method
        public static int NumberOfHalfNodes(Node<T> root) => new BinaryTree<T>()
            .LevelOrderNonRecursiveTraversal(root)
            .Where(node => (node.Left != null && node.Right == null) || (node.Left == null && node.Right != null))
            .ToList().Count;
    }
}
