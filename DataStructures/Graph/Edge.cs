using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public class Edge<T, TW> : IEdge<T>
        where TW : IComparable
    {
        public Edge(IGraphVertex<T> target, TW weight)
        {
            TargetVertex = target;
            this.weight = weight;
        }
        private object weight;
        public T TargetVertexKey => TargetVertex.Key;

        public IGraphVertex<T> TargetVertex { get; private set; }

        public W Weight<W>() where W : IComparable
        {
            return (W)weight;
        }
        public override string ToString()
        {
            return TargetVertexKey.ToString();
        }
    }
    public class DiEdge<T, TW> : IDiEdge<T>
    {
        private object weight;
        public IDiGrafVertex<T> TargetVertex { get; private set; }

        public T TargetVertexKey => TargetVertex.Key;
        IGraphVertex<T> IEdge<T>.TargetVertex => TargetVertex as IGraphVertex<T>;
        public DiEdge(IDiGrafVertex<T> target, TW weight)
        {
            TargetVertex = target;
            this.weight= weight;
        }
        public W Weight<W>() where W : IComparable
        {
            return (W)weight;
        }
        public override string ToString()
        {
            return $"{TargetVertexKey}";
        }
    }
}
