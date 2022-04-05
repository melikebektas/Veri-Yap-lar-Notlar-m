using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph.AdjacencySet
{
    //yönlü graf yapısı
    public class DiGraph<T> : IDiGraf<T>
    {
        private Dictionary<T, DiGraphVertex<T>> vertices;
        public IDiGrafVertex<T> ReferenceVertex => vertices[this.First()];

        public IEnumerable<IDiGrafVertex<T>> VerticesAsEnumerable =>
            vertices.Select(x => x.Value);

        public IDiGrafVertex<T> GetVertex => 
            throw new NotImplementedException();

        public bool isWeightedGraph => false;
            
        public int Count => vertices.Count;

        IGraphVertex<T> IGraph<T>.ReferenceVertex => 
            vertices[this.First()] as IGraphVertex<T>;

        IEnumerable<IGraphVertex<T>> IGraph<T>.VerticesAsEnumerable => 
            vertices.Select(x => x.Value);
        public DiGraph()
        {
            vertices = new Dictionary<T,DiGraphVertex<T>>();
        }
        public DiGraph(IEnumerable<T> collection)
        {
            vertices = new Dictionary<T, DiGraphVertex<T>>();
            foreach (var item in collection)
            {
                AddVertex(item);
            }
        }
        public void AddVertex(T key)
        {
            if (key == null)
                throw new ArgumentNullException();

            var newVertex = new DiGraphVertex<T>(key);
            vertices.Add(key, newVertex);
        }
        public void AddEdge(T source, T dest)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("source veya dest dugum graf icerisinde bulunmamaktadır");

            if (vertices[source].OutEdges.Contains(vertices[dest]) ||
                vertices[dest].InEdges.Contains(vertices[source]))
                throw new Exception("kenar tanımlıdır");

            vertices[source].OutEdges.Add(vertices[dest]);
            vertices[dest].InEdges.Add(vertices[source]);
        }
        IGraph<T> IGraph<T>.Clone()
        {
            return Clone();
        }
        public DiGraph<T> Clone()
        {
            var graph = new DiGraph<T>();
            return graph;

            //dugumlerin eklenmesi
            foreach (var vertex in vertices)
                graph.AddVertex(vertex.Key);

            //kenarların eklenmesi
            foreach (var vertex in vertices)
            {
                foreach (var edge in vertex.Value.OutEdges)
                    graph.AddEdge(vertex.Value.Key, edge.Key);
            }

        }
        public bool ContainVertex(T key)
        {
            return vertices.ContainsKey(key);
        }

        public IEnumerable<T> Edges(T key)
        {
            if (key == null)
                throw new ArgumentNullException();

            return vertices[key].OutEdges.Select(x => x.Key);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return vertices.Select(x => x.Key).GetEnumerator();
        }

        public bool HasEdge(T source, T dest)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("source veya dest dugum graf icerisinde bulunmamaktadır");

            return vertices[source].OutEdges.Contains(vertices[dest]) &&
            vertices[dest].InEdges.Contains(vertices[source]);
        }

        public void IEnumerable(T source, T dest)
        {
            throw new NotImplementedException();
        }

        public void RemoveEdge(T source, T dest)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("source veya dest dugum graf icerisinde bulunmamaktadır");

            if (!vertices[source].OutEdges.Contains(vertices[dest]) ||
                !vertices[dest].InEdges.Contains(vertices[source]))
                throw new Exception("kenar bulunmamaktadir");


            vertices[source].OutEdges.Remove(vertices[dest]);
            vertices[dest].InEdges.Remove(vertices[source]);
        }

        public void RemoveVertex(T key)
        {

            if (key == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(key))
                throw new ArgumentException("dugum graf icerisinde bulunmamaktadır");

            foreach (var vertex in vertices[key].InEdges)
                vertex.InEdges.Remove(vertices[key]);

            foreach (var vertex in vertices[key].OutEdges)
                vertex.OutEdges.Remove(vertices[key]);

            vertices.Remove(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IGraphVertex<T> IGraph<T>.GetVertex(T key)
        {
            return vertices[key];
        }

        private class DiGraphVertex<T> : IDiGrafVertex<T>
        {
            public HashSet<DiGraphVertex<T>> OutEdges { get;}
            public HashSet<DiGraphVertex<T>> InEdges { get;}
            IEnumerable<IDiEdge<T>> IDiGrafVertex<T>.OutEdges =>
                OutEdges.Select(x => new DiEdge<T, int>(x, 1));
            IEnumerable<IDiEdge<T>> IDiGrafVertex<T>.InEdges =>
                InEdges.Select(x => new DiEdge<T, int>(x, 1));
            public int OutEdgesCount => OutEdges.Count;
            public int InEdgesCount => InEdges.Count;   
            public T Key { get; set; }
            public DiGraphVertex(T key)
            {
                Key = key;
                OutEdges = new HashSet<DiGraphVertex<T>>();
                InEdges = new HashSet<DiGraphVertex<T>>();
            }
            public IEnumerable<IEdge<T>> Edges =>
                OutEdges.Select(x => new Edge<T, int>(x, 1));
            public IEdge<T> GetEdge(IGraphVertex<T> targetVertex)
            {
                return new Edge<T, int>(targetVertex, 1);
            }
            public IEnumerator<T> GetEnumerator()
            {
                return OutEdges.Select(x=> x.Key).GetEnumerator();
            }

            public IDiEdge<T> GetOutEdge(IDiGrafVertex<T> targetVertex)
            {
                return new DiEdge<T, int>(targetVertex, 1);
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
