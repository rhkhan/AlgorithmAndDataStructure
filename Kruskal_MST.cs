using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskal
{
    class Program
    {
        static List<int> matrixWeight;
        static List<int> sourceVertexA;
        static List<int> destVertexA;
        static Dictionary<int, Node> map = new Dictionary<int, Node>();
        static List<int> resultS;
        static List<int> resultD;
        static int totalCost = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of vertices: ");
            int Vertices=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of Edges: ");
            int edge = Convert.ToInt32(Console.ReadLine());
            matrixWeight = new List<int>();
            sourceVertexA = new List<int>();
            destVertexA = new List<int>();
            resultS = new List<int>();
            resultD = new List<int>();

            Console.WriteLine("Enter Edges: source, destination, weight: ");
            while (edge > 0) //Enter each edge
            {
                // for each edge: start node, end node and vertex weight
                int[] startEndVertexWeight = Array.ConvertAll(Console.ReadLine().Split(),int.Parse);
                int startVertex = startEndVertexWeight[0];
                int endVertex = startEndVertexWeight[1];
                int weight = startEndVertexWeight[2];
                addEdge(startVertex, endVertex,weight);
                edge--;
            }

            quickSort(matrixWeight, 0, matrixWeight.Count - 1);
            for (int i = 0; i < Vertices; i++)
                makeSet(i); // make each vertice as set, and make it as a parent of it's own

            for(int i = 0; i < sourceVertexA.Count; i++)
            {
                KruskalUnion(sourceVertexA[i], destVertexA[i],matrixWeight[i]);
            }

            Console.WriteLine("Minimum Spanning Tree: ");
            for (int i = 0; i < resultS.Count; i++)
            {
                Console.Write(resultS[i] + " - " + resultD[i]);
                Console.WriteLine();
            }
            Console.WriteLine("Total Cost: " + totalCost);

            Console.Read();
        }

        static void makeSet(int data)
        {
            Node node = new Node();
            node.data = data;
            node.Parent = node;
            node.rank = 0;
            map[data] = node;
        }

        static Node findSet(Node node)
        {
            Node parent = node.Parent;
            if (node == parent)
                return parent;
            node.Parent = findSet(node.Parent);
            return node.Parent;
        }

        static void KruskalUnion(int data1,int data2,int cost)
        {
            Node node1 = map[data1];
            Node node2 = map[data2];

            Node parent1 = findSet(node1);
            Node parent2 = findSet(node2);

            if (parent1.data == parent2.data) // check if they are from the same set/check both belong to the same parent
                return;

            resultS.Add(data1);
            resultD.Add(data2);
            totalCost += cost;
            parent2.Parent = parent1; // marge two sets into one set/connect the two set
      }


        static void addEdge(int sV, int eV, int w)
        {
            sourceVertexA.Add(sV);
            destVertexA.Add(eV);
            matrixWeight.Add(w);
        }


        static void quickSort(List<int> a, int start, int end)
        {
            if (start < end)
            {
                int pIndex = partition(a, start, end);
                quickSort(a, start, pIndex - 1);
                quickSort(a, pIndex + 1, end);
            }

        }

        static int partition(List<int> a, int start, int end)
        {
            int pivot = a[end];
            int j = start;
            int temp = 0;
            int tempS = 0;
            int tempD = 0;

            for (int i = start; i < end; i++)
            {
                if (a[i] <= pivot)
                {
                    temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;

                    tempS = sourceVertexA[i];
                    sourceVertexA[i] = sourceVertexA[j];
                    sourceVertexA[j] = tempS;

                    tempD = destVertexA[i];
                    destVertexA[i] = destVertexA[j];
                    destVertexA[j] = tempD;

                    j++;
                }
            }

            temp = a[end];
            a[end] = a[j];
            a[j] = temp;

            tempS = sourceVertexA[end];
            sourceVertexA[end] = sourceVertexA[j];
            sourceVertexA[j] = tempS;

            tempD = destVertexA[end];
            destVertexA[end] = destVertexA[j];
            destVertexA[j] = tempD;

            return j;
        }

    }

    public class Tuple<T>
    {
        public T endV { get; set; }
        public T weight { get; set; }

        public Tuple(T item,T item2)
        {
            endV = item;
            weight = item2;
        }
    }

    public class Node
    {
       public int data;
       public Node Parent;
       public int rank;
    }

}
