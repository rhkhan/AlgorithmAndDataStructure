using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FordFulkerson
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let us create a graph shown in the above example
            int[,] graph = new int[,] 
                                    { 
                                         {0, 10, 10, 0, 0},
                                         {0, 0, 0, 10, 0},
                                         {0, 0, 0, 0, 10},
                                         {0, 0, 0, 0, 10},
                                         {0, 0, 0, 0, 0}
                                    };
            MaxFlow m = new MaxFlow();

            Console.WriteLine("The maximum possible flow is " +
                               m.fordFulkerson(graph, 0, 4));

            Console.Read();
        }
    }


    class MaxFlow
    {
        const int V = 5; //Number of vertices in graph

        /* Returns true if there is a path from source 's' to sink
          't' in residual graph. Also fills parent[] to store the
          path */
        bool bfs(int[,] rGraph, int s, int t, int[] parent)
        {
            // Create a visited array and mark all vertices as not
            // visited
            bool[] visited = new bool[V];
            for (int i = 0; i < V; ++i)
                visited[i] = false;

            // Create a queue, enqueue source vertex and mark
            // source vertex as visited
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            visited[s] = true;
            parent[s] = -1;

            // Standard BFS Loop
            while (queue.Count != 0)
            {
                int u = queue.Dequeue();

                for (int v = 0; v < V; v++)
                {
                    if (visited[v] == false && rGraph[u, v] > 0)
                    {
                        queue.Enqueue(v);
                        parent[v] = u;
                        visited[v] = true;
                    }
                }
            }

            // If we reached sink in BFS starting from source, then
            // return true, else false
            return (visited[t] == true);
        }

        // Returns tne maximum flow from s to t in the given graph
        public int fordFulkerson(int[,] graph, int s, int t)
        {
            int u, v;

            // Create a residual graph and fill the residual graph
            // with given capacities in the original graph as
            // residual capacities in residual graph

            // Residual graph where rGraph[i][j] indicates
            // residual capacity of edge from i to j (if there
            // is an edge. If rGraph[i][j] is 0, then there is
            // not)
            int[,] rGraph = new int[V, V];

            for (u = 0; u < V; u++)
                for (v = 0; v < V; v++)
                    rGraph[u, v] = graph[u, v];

            // This array is filled by BFS and to store path
            int[] parent = new int[V];

            int max_flow = 0;  // There is no flow initially

            // Augment the flow while tere is path from source
            // to sink
            while (bfs(rGraph, s, t, parent))
            {
                // Find minimum residual capacity of the edhes
                // along the path filled by BFS. Or we can say
                // find the maximum flow through the path found.
                int path_flow = Int32.MaxValue;
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    path_flow = Math.Min(path_flow, rGraph[u, v]);
                }

                // update residual capacities of the edges and
                // reverse edges along the path
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] -= path_flow;
                    rGraph[v, u] += path_flow;
                }

                // Add path flow to overall flow
                max_flow += path_flow;
            }

            // Return the overall flow
            return max_flow;
        }
    }
}
