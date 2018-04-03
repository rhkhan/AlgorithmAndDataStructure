using System;
using System.Collections.Generic;


namespace EulerianPathOrCircuit
{
    class Program
    {
        static void Main(string[] args)
        {

            Graph g = new Graph(5);
            g.addEdge(1, 0);
            g.addEdge(0, 2);
            g.addEdge(2, 1);
            g.addEdge(0, 3);
            g.addEdge(3, 4);
            g.test();

            Graph g2 = new Graph(5);
            g2.addEdge(1, 0);
            g2.addEdge(0, 2);
            g2.addEdge(2, 1);
            g2.addEdge(0, 3);
            g2.addEdge(3, 4);
            g2.addEdge(4, 0);
            g2.test();

            Graph g3 = new Graph(5);
            g3.addEdge(1, 0);
            g3.addEdge(0, 2);
            g3.addEdge(2, 1);
            g3.addEdge(0, 3);
            g3.addEdge(3, 4);
            g3.addEdge(1, 3);
            g3.test();

            Graph g4 = new Graph(5);
            g4.addEdge(0, 1);
            g4.addEdge(1, 2);
            g4.addEdge(2, 0);
            g4.test();

            Graph g5 = new Graph(3);
            g5.test();

            Graph g6 = new Graph(2);
            g6.addEdge(0, 1);
            g6.addEdge(0, 1);
            g6.test();

            Graph g7 = new Graph(3);
            g7.addEdge(1, 2);
            g7.addEdge(1, 2);
            g7.addEdge(2, 1);
            //g7.addEdge(2, 1);
            g7.test();

            Console.Read();
        }
    }

    public class Graph
    {
        private int V;
        private LinkedList<int>[] adjacencyList;

        public Graph(int v)
        {
            V = v;
            adjacencyList = new LinkedList<int>[V];
            for (int i = 0; i < v; i++)
                adjacencyList[i] = new LinkedList<int>();
        }

        public void addEdge(int u,int v)
        {
            adjacencyList[u].AddLast(v);
            adjacencyList[v].AddLast(u);
        }

        void dfsUtil(int v,bool[] visited)
        {
            visited[v] = true;
            foreach(LinkedList<int> list in adjacencyList)
            {
                foreach(int n in list)
                {
                    if (!visited[n])
                    {
                        dfsUtil(n, visited);
                    }
                }
            }
        }

        bool isConnected()
        {
            bool[] visited = new bool[V];
            int i;
            for (i = 0; i < visited.Length; i++)
                visited[i] = false;
            
            for(i=0;i<V;i++) // check if all vertices have non-zero degree
            {
                if (adjacencyList[i].Count != 0)
                {
                    break;
                }
                else
                {
                    if (i == V - 1)
                        return true;
                }
            }

            // Start DFS traversal from a vertex with non-zero degree
            dfsUtil(i, visited);
            
            for(i=0;i<visited.Length;i++)
            {
                if (!visited[i] && adjacencyList[i].Count>0) // check if all non-zero vertices are connected
                    return false;
            }

            return true;
        }

        int isEulerian()
        {
            //To be Eulerain all nonzero vertices must be connected
            // Eulerian cycle needs all vertices have even degree
            //Eulerian path needs 0 or 2 vertices of odd degree and all others should be even degree
            if (!isConnected())
                return 0; //not Eulerian

            int count = 0;
            for(int i=0;i<adjacencyList.Length;i++)
            {
                if (adjacencyList[i].Count % 2 != 0)
                {
                    count++;
                    if(count>2)
                    {
                        return 0; // not Eulerian
                    }
                }
            }

            return count == 2 ? 1 : 2;

        }

        public void test()
        {
            int res = isEulerian();
            if (res == 0)
                Console.WriteLine("graph is not Eulerian");
            else if (res == 1)
                Console.WriteLine("grpah has a Eulerian path");
            else
                Console.WriteLine("graph is Eulerian circuit/cycle");
        }

    }

}
