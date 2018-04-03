using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


class Solution
{
    static int[,] cap = new int[300, 300];
    public const int INF = 10000000;
    public const int source = 0;
    public const int target = 1;


    static void Main(String[] args)
    {

        int c = Convert.ToInt32(Console.ReadLine()); //test case
        while (c > 0)
        {

            string[] parameters = Console.ReadLine().Split();
            int N = Convert.ToInt32(parameters[0]); // number of nodes
            int T = Convert.ToInt32(parameters[1]); // max number of feet
            int M = Convert.ToInt32(parameters[2]);// number of edges
            int Edge = M;

            for (int i = 0; i < 300; i++)
                for (int j = 0; j < 300; j++)
                {
                    cap[i, j] = 0;
                }

            while (M > 0)
            {

                string[] vertices = Console.ReadLine().Split();
                int v1i = Convert.ToInt32(vertices[0]);
                int v2i = Convert.ToInt32(vertices[1]);

                //cap[2 * (v1i - 1) + 2, 2 * (v2i - 1) + 3] = 1;
                //cap[2 * (v2i - 1) + 2, 2 * (v1i - 1) + 3] = 1;

                cap[2 * v1i, 2 * v2i+1] = 1;
                cap[2 * v2i, 2 * v1i + 1] = 1;

                M--;
            }


            for (int i = 0; i < N; i++)
            {
                //cap[source, 2 * i + 2] = T;
                //cap[2 * i + 3, target] = 1;

                cap[source, 2 * i + 1] = T;
                cap[2 * i + 2, 2*N+1] = 1;
            }


            //int result = fordFulkerson(2 * N + 1, source, target);

            int result = fordFulkerson(cap, 0, N-1);
            //if (Edge > N)
                //result++;

            Console.WriteLine(result);

            c--;
        }

        Console.Read();
    }

    static int V=300;

    static bool bfs(int[,] rGraph, int s, int t, int[] parent)
    {
        // Create a visited array and mark all vertices as not
        // visited
        bool[] visited= new bool[V];
        for(int i=0; i<V; ++i)
            visited[i]=false;
 
        // Create a queue, enqueue source vertex and mark
        // source vertex as visited
        Queue<Int32>queue = new Queue<Int32>();
        queue.Enqueue(s);
        visited[s] = true;
        parent[s]=-1;
 
        // Standard BFS Loop
        while (queue.Count()!=0)
        {
            int u = queue.Dequeue();
 
            for (int v=0; v<V; v++)
            {
                if (visited[v]==false && rGraph[u,v] > 0)
                {
                    queue.Enqueue(v);
                    parent[v] = u; // store the previous source (parent) path
                    visited[v] = true;
                }
            }
        }
 
        // If we reached sink in BFS starting from source, then
        // return true, else false
        return (visited[t] == true);
    }
 
    // Returns tne maximum flow from s to t in the given graph
    static int fordFulkerson(int[,] graph, int s, int t)
    {
        int u, v;
 
        int[,] rGraph = new int[V,V];
 
        for (u = 0; u < V; u++)
            for (v = 0; v < V; v++)
                rGraph[u,v] = graph[u,v];
 
        // This array is filled by BFS and to store path
        int[] parent = new int[V];
 
        int max_flow = 0;  // There is no flow initially
 
        // Augment the flow while tere is path from source
        // to sink
        while (bfs(rGraph, s, t, parent))
        {
            int path_flow = Int32.MaxValue;
            for (v=t; v!=s; v=parent[v])
            {
                u = parent[v];
                path_flow = Math.Min(path_flow, rGraph[u,v]);
            }
 
            for (v=t; v != s; v=parent[v])
            {
                u = parent[v];
                rGraph[u,v] -= path_flow;
                rGraph[v,u] += path_flow;
            }
 
            // Add path flow to overall flow
            max_flow += path_flow;
        }
 
        // Return the overall flow
        return max_flow;
    }

}




