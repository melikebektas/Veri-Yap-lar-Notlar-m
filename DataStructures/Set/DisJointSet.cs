using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Set
{
    public class DisJointSet<T> : IEnumerable<T>
    {
        private Dictionary<T, DisjointSetNode <T>> set = new Dictionary<T, DisjointSetNode<T>>();

        public int Count { get; private set; }
        public void MakeSet(T value)
        {
            if (set.ContainsKey(value))
                throw new Exception("değer  daha önce set olarak tanimlanmistir");

            var newSet = new DisjointSetNode<T>(value, 0);

            //set değeri ilk olusturuldugunda kendisini isaret etmektedir
            newSet.Parent = newSet;
            set.Add(value, newSet);
            Count++;
           
        }
        public T FindSet(T value)
        {
            
            if(!set.ContainsKey(value))
                throw new Exception("aranilan deger set icerisinde bulunamadı");

            return findSet(set[value]).Value;
        }
        private DisjointSetNode<T> findSet(DisjointSetNode<T> node)
        {
            var parent = node.Parent;
            if (node != parent)
            {
                node.Parent = findSet(node.Parent);
                return node.Parent;
            }
            return parent;
        }
        public void Union(T valueA, T valueB)
        {
            if (valueA == null || valueB == null)
                throw new ArgumentNullException();

            var RootA = FindSet(valueA);
            var RootB = FindSet(valueB);

            //RootA ile RootB eşit ise aynı set icerisindedir birlestirme islemi olmaz
            if(RootA.Equals(RootB))
                return;

            var nodeA = set[RootA];
            var nodeB = set[RootB];

            if(nodeA.Rank == nodeB.Rank)
            {
                nodeB.Parent = nodeA;
                nodeA.Rank++;
            }
            else
            {
                if(nodeA.Rank < nodeB.Rank)
                {
                    nodeA.Parent = nodeB;
                }
                else
                {
                    nodeB.Parent = nodeA;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return set.Values.Select(x => x.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
