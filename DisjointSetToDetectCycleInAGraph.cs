using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisjointSet_DetectCycleInAGraph
{
    class Program
    {
        static LinkedList<Tuple<int>>[] adjacencyList;
        static Dictionary<int, Node> map = new Dictionary<int, Node>();

        static void Main(string[] args)
        {

            int Vertices = Convert.ToInt32(Console.ReadLine());
            int Edges = Convert.ToInt32(Console.ReadLine());
            adjacencyList = new LinkedList<Tuple<int>>[Vertices];

            for (int i = 0; i < adjacencyList.Length; i++)
                adjacencyList[i] = new LinkedList<Tuple<int>>(); // initialize empty adjacency list

            Console.WriteLine("Enter Start(vertex) and End(Vertex) of each edge: ");
            while (Edges > 0) //Enter each edge
            {
                int[] startEndVertex = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int startVertex = startEndVertex[0];
                int endVertex = startEndVertex[1];
                addEdge(startVertex, endVertex);
                Edges--;
            }
            printAdjacencyList();

            if (isCycle(adjacencyList))
                Console.WriteLine("Graph contains cycle");
            else
                Console.WriteLine("Graph does not contain cycle");

            Console.Read();
        }

        static void addEdge(int sV, int eV)
        {
            adjacencyList[sV].AddFirst(new Tuple<int>(eV));
        }

        // Prints the Adjacency List
        public static void printAdjacencyList()
        {
            int i = 0;
            foreach (LinkedList<Tuple<int>> list in adjacencyList)
            {
                if (adjacencyList[i].Count > 0)
                {
                    Console.Write("adjacencyList[" + i + "] -> ");
                    foreach (Tuple<int> edge in list)
                    {
                        Console.Write(edge.endV);
                    }
                }
                ++i;
                Console.WriteLine();
            }
        }

        static bool isCycle(LinkedList<Tuple<int>>[] adjacencyList)
        {
            for(int j = 0; j < adjacencyList.Length; j++)
            {
                makeSet(j); // initialize each vertex and set vertex as the parent of it's own.
                            // each vertex is itself a disjoint set.
            }

            int i = 0; //loop through all edges and find subsets of both vertex (start and end) of every edge
                       // to determine if both vertices are from the same subset (or parent of both vertices are same).
            foreach (LinkedList<Tuple<int>> list in adjacencyList)
            {
                foreach (Tuple<int> d in list)
                {
                    Node node1 = map[i];
                    Node node2 = map[d.endV];
                    Node parent1 = findSet(node1);
                    Node parent2 = findSet(node2);
                    if (parent1.data == parent2.data) // parent data is same so there is a cycle in the graph
                        return true;

                    union(parent1.data, parent2.data); // otherwise make a union to marge the two sets.
                }
                ++i;
            }

           

            return false;
        }

        static void makeSet(int data)
        {
            Node node = new Node();
            node.data = data;
            node.parent = node;
            map[data] = node;
        }

        static void union(int data1,int data2)
        {
            Node node1 = map[data1];
            Node node2 = map[data2];

            node2.parent = node1;
        }

        static Node findSet(Node node)
        {
            Node parent = node.parent;
            if (parent == node)
                return parent;
            node.parent = findSet(node.parent);
            return node.parent;
        }
    }


    public class Node
    {
       public int data;
       public Node parent;
    }

    public class Tuple<T>
    {
        public T endV { get; set; }
        public Tuple(T item)
        {
            endV = item;
        }
    }

}
