using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public interface IGraph<T> : IEnumerable<T>
    {
        bool isWeightedGraph { get; }
        int Count { get; }
        IGraphVertex<T> ReferenceVertex { get; }
        IEnumerable<IGraphVertex<T>> VerticesAsEnumerable { get; }
        IEnumerable<T> Edges(T key);
        IGraph<T> Clone();
        bool ContainVertex(T key);
        IGraphVertex<T> GetVertex(T key);
        bool HasEdge(T source, T dest);
        void AddVertex(T key);
        void RemoveVertex(T key);
        void RemoveEdge(T source, T dest);
        void IEnumerable(T source, T dest);
    }
    public interface IGraphVertex<T> : IEnumerable<T>
    {
        T Key { get; }
        IEnumerable<IEdge<T>> Edges { get; }

        IEdge<T> GetEdge(IGraphVertex<T> targetVertex);
    }
    public interface IEdge<T>
    {
        //hedef dugumun degeri
        T TargetVertexKey { get; }

        //hedef dugumun kendisi
        IGraphVertex<T> TargetVertex { get; }

        //grafın agirligini ifade ettik
        W Weight<W>() where W : IComparable;

    }
    public interface IDiGraf<T> : IGraph<T>
    {
        new IDiGrafVertex<T> ReferenceVertex { get; }
        new IEnumerable<IDiGrafVertex<T>> VerticesAsEnumerable { get; } 
        new IDiGrafVertex<T> GetVertex { get; }
    }
    public interface IDiGrafVertex<T> : IGraphVertex<T>
    {
        IDiEdge<T> GetOutEdge(IDiGrafVertex<T> targetVertex);
        IEnumerable<IDiEdge<T>> OutEdges { get; } 
        IEnumerable<IDiEdge<T>> InEdges { get; } 
        int OutEdgesCount { get; }
        int InEdgesCount { get; }

    }
    public interface IDiEdge<T> : IEdge<T>
    {
       new IDiGrafVertex<T> TargetVertex { get; }
    }
}
