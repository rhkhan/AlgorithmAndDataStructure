using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BFS;
using System.Collections;


namespace ConsoleApplication1
{
    class Program
    {
         static LinkedList<Tuple<int>>[] adjacencyList;

        static void Main()
        {
            int V,edges;
            string[] edge;
            Console.WriteLine("Enter number of Vertex: ");
            V = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of edges: ");
            edges = Convert.ToInt32(Console.ReadLine());

            adjacencyList = new LinkedList<Tuple<int>>[V];

            // intitializing empty adjacent list
            for (int i = 0; i < adjacencyList.Length; i++) {
                adjacencyList[i] = new LinkedList<Tuple<int>>();
            }

            Console.WriteLine("Enter Source Vertex and Destination Vertex (int digit)");
            while (edges > 0) {
                edge = Console.ReadLine().Split(' ');
                int start = Convert.ToInt32(edge[0]);
                int end = Convert.ToInt32(edge[1]);

                addEdge(start, end);
                edges--;
            }

            Console.WriteLine("source and destination vertex list: ");
            printAdjacencyList();

            Console.WriteLine("Enter source vertex: ");
            int s=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Traverse graph using BFS from node: ");
            GraphTraverseDFS(s);

            Console.Read();
        }

        static void addEdge(int start, int end){
            adjacencyList[start].AddFirst(new Tuple<int>(end));
        }

        // Prints the Adjacency List
        static void printAdjacencyList()
        {
            int i = 0;

            foreach (LinkedList<Tuple<int>> list in adjacencyList)
            {
                Console.Write("adjacencyList[" + i + "] -> ");

                foreach (Tuple<int> edge in list)
                {
                    Console.Write(edge.t1 + " ");
                }

                ++i;
                Console.WriteLine();
            }
        }


        // DFS traversal from a given source
        static void GraphTraverseDFS(int u)
        {

            Stack<int> s = new Stack<int>(); // Create a stack for DFS
            bool[] visited = new bool[1000]; // boolean array to track visited vertex

            for (int i = 0; i < visited.Length; i++)
                visited[i] = false; // mark all the vertices as not visited (By default set as false)


            s.Push(u); // push the starting vertex
            visited[u] = true; // mark it as visited

            while (s.Count > 0)
            { // while queue is not empty
                u = s.Pop(); // pop a vertex from stack and print
                Console.Write(u + " ");

                // Get all the adjacent vertices of the dequed vertex
                // If an adjacent vertex is not visited then push it and mark it as visited
                foreach (Tuple<int> t in adjacencyList[u])
                {
                    int n = t.t1;
                    if (!visited[n])
                    {
                        visited[n] = true;
                        s.Push(n);
                    }
                }

            }

        }



    }
}
