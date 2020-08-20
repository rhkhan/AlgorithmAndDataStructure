using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedComponentsInGraph
{

    class Graph
    {
       public int vertex;
        public List<int>[] adjListArray;

        public Graph(int vertex)
        {
            adjListArray = new List<int>[vertex];
            for (int i = 0; i < vertex; i++)
                adjListArray[i] = new List<int>();
        }

        public void addEdge(int source,int destination)
        {
            // due to undirected graph, we will consider both source->dest and dest->source
            adjListArray[source].Add(destination);
            adjListArray[destination].Add(source);
        }

        public void connectedComponents(bool[] visited,int v)
        {
            for(int i=0;i<v;i++)
            {
                if (!visited[i])
                {
                    DFS(visited, i);
                }
                //Console.WriteLine();
            }
        }

        public void DFS(bool[] visited,int v)
        {
            visited[v] = true;
            Console.Write(v + " ");

            foreach(int item in adjListArray[v])
            {
                if (!visited[item])
                    DFS(visited, item);
            }

            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int V = 5;
            Graph graph = new Graph(V);
            graph.addEdge(1, 0);
            graph.addEdge(2, 3);
            graph.addEdge(3, 4);

            bool[] visited = new bool[V];
            graph.connectedComponents(visited, V);

            Console.Read();
        }
    }
}
