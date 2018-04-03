using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleuryAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let us first create and test graphs shown in above figure
            Graph g1=new Graph(4);
            g1.addEdge(0, 1);
            g1.addEdge(0, 2);
            g1.addEdge(1, 2);
            g1.addEdge(2, 3);
            g1.printEulerianCircuit();

            Graph g2 = new Graph(3);
            g2.addEdge(0, 1);
            g2.addEdge(1, 2);
            g2.addEdge(2, 0);
            g2.printEulerianCircuit();

            Graph g3 = new Graph(5);
            g3.addEdge(1, 0);
            g3.addEdge(0, 2);
            g3.addEdge(2, 1);
            g3.addEdge(0, 3);
            g3.addEdge(3, 4);
            g3.addEdge(3, 2);
            g3.addEdge(3, 1);
            g3.addEdge(2, 4);
            g3.printEulerianCircuit();

        }
    }

    public class Graph
    {
        public LinkedList<int>[] adjacencyList;
        private int V;
        bool[] visited;
        public Graph(int v)
        {
            V = v;
            visited = new bool[V];
            //for (int i = 0; i < visited.Length; i++)
                //visited[i] = false;

            adjacencyList = new LinkedList<int>[V];
            for (int i = 0; i < v; i++)
                adjacencyList[i] = new LinkedList<int>();
        }

        public void addEdge(int u,int v)
        {
            adjacencyList[u].AddLast(v);
            adjacencyList[v].AddLast(u);
        }

        public void dfsUtil(bool[] visited,int i)
        {
            visited[i] = true;
           foreach(LinkedList<int> list in adjacencyList)
            {
                foreach(int n in list)
                {
                    if (!visited[n])
                        dfsUtil(visited, n);
                }
            }
        }

        public bool isConnected()
        {
            bool[] visited = new bool[V];
            int i;

            for (i = 0; i < visited.Length; i++)
                visited[i] = false;
            for (i = 0; i < adjacencyList.Length; i++) //Check if all vertices are non-zero degree
            {
                if (adjacencyList[i].Count != 0)
                    break;
                if (i == V - 1)
                    return true;
            }

            dfsUtil(visited, i); // start dfs traversal from first non-zero degree vertex

            for(i = 0; i < visited.Length; i++)
            {
                if(!visited[i] && adjacencyList[i].Count > 0)// check if all non-zero vertices are connected
                {
                    return false;
                }
            }
            return true;

        }


        public bool isEulerianCircuit()
        {
            if (isConnected())
            {
                for (int i = 0; i < adjacencyList.Length; i++)
                {
                    if (adjacencyList[i].Count % 2 != 0)
                        return false;
                }
            }

            return true;
        }

        public void printEulerianCircuit()
        {
            if (isEulerianCircuit())
            {
                int u = 0;
                for (int i = 0; i < adjacencyList.Length; i++)
                {
                    if (adjacencyList[i].Count % 2 != 0)
                    {
                        u = i;
                        break;
                    }
                }

                //print tour starting from odd vertex
                printEulerCircuitUtil(u);
            }
        }

        public void printEulerCircuitUtil(int u)
        {
            foreach (LinkedList<int> list in adjacencyList)
            {
                foreach (int n in list)
                {
                    if(n!=-1 && isValidNextEdge(u, n))
                    {
                        Console.WriteLine(u + " - " + n);
                        removeEdge(u, n);
                        printEulerCircuitUtil(n);
                    }
                }
            }
        }

        public void removeEdge(int u,int v)
        {
            int count = 0;
            foreach(int val in adjacencyList[u])
            {
                count++;
                if (val == v)
                {
                    adjacencyList[u].Remove(v);
                }

            }
            foreach (int val in adjacencyList[v])
            {
                if (val == u)
                {
                    adjacencyList[v].Remove(u);
                }

            }
        }

        public bool isValidNextEdge(int u,int v)
        {
            int adjacentCount = 0;
            foreach(int val in adjacencyList[u])
            {
                if (val != -1)
                {
                    adjacentCount++;
                }
            }
            if (adjacentCount == 1)
                return true;

            bool[] visited = new bool[V];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;

            int count1 = dfsCount(visited, u);
            removeEdge(u, v);
            int count2 = dfsCount(visited, u);
            addEdge(u, v);
            return (count1 > count2) ? false : true;
        }

        public int dfsCount(bool[] visited,int i)
        {
            visited[i] = true;
            int count = 1;


            foreach (int val in adjacencyList[i])
            {
                if (val !=-1 && !visited[val])
                {
                    count += dfsCount(visited, val);
                }

            }


            return count;
        }

    }

}
