using DataStructures.Tree.Binary_Tree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.BST
{
    public class BST<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        public Node<T>  Root { get; set; }
        public BST()
        {

        }
        public BST(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Add(item);
                Console.WriteLine(item);
            }
        }
        public void Add(T value)
        {
            if(value == null)
                throw new ArgumentNullException("value = null");

            var NewNode = new Node<T>(value);

            //root == null hiç eleman yok gelen eleman root oldu
            if (Root == null)
            {
                Root = NewNode;
            }
            else
            {
                //current mevcut durumu ifade etmektedir. Rootdan başlattık
                var current = Root;
                Node<T> parent;
                while (true)
                {
                    parent = current;
                    //sol alt ağaç
                    if (value.CompareTo(current.Value) < 0)
                    {
                        current = current.Left;
                        if(current == null)
                        {
                            parent.Left = NewNode;
                            break;
                        }

                    }
                    //sağ alt ağaç
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            parent.Right = NewNode;
                            break;
                        }
                    }
                }

            }


        }

        public Node<T> FindMin(Node<T> root)
        {
            var current = root;
            while (current != null)
                current = current.Left;
            
            return current;
        }

        public Node<T> FindMax(Node<T> root)
        {
            var current = root;
            while(current != null)
                current = current.Right;

            return current;
        }

        //compareTo methodu karşılaştırır küçük ise -1, eşit ise 0, büyükse 1 döndürür
        public Node<T> Find(Node<T> root, T key)
        {
            var current = root;
            while(key.CompareTo(current.Value) != 0)
            {
                if(key.CompareTo(current.Value)<0)
                    current = current.Left; 
                else
                    current = current.Right;

                if (current == null)
                    throw new ArgumentNullException("aranılan değer bulunamadı");
            }
            return current;

        }
        public Node<T> Remove(Node<T> root, T key)
        {
            if (root == null)
                throw new ArgumentNullException("ağaç veri yapısında eleman bulunmamaktadır");

            //rekürsif ilerle
            if (key.CompareTo(root.Value) < 0)
            {
                root.Left = Remove(root.Left, key);
            }
            else if(key.CompareTo(root.Value) > 0)
            {
                root.Right = Remove(root.Right, key);
            }
            else
            {
                //silme root = key olduğundan silme işlemi uygulanır
                //tek çocuklu ya da çocuksuz
                if (root.Right == null)
                    return root.Left;
                else if (root.Left == null)
                    return root.Right;

                //iki çocuk
                root.Value = FindMin(root.Right).Value;
                root.Right = Remove(root.Right, root.Value);

                
            }
            return root;
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
