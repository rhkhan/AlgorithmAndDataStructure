using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoPrims_MST
{
    class Program
    {
        static LinkedList<Tuple<int>>[] adjacencyList;
        static List<int> mstSet = new List<int>();
        static int[] vKeyVal;
        const int INF = int.MaxValue;
        static int totalVertex=0;
        static int s, d, w;
        static List<int> sourceV;
        static List<int> destinationV;
        static List<int> weightVal;
        static int min = int.MaxValue;
        static int minVertex = 0;

        #region ########### public properties ##########
        public static int MIN
        {
            get{return min;}
            set{min = value;}
        }
        public static int minVERTEX
        {
            get{return minVertex;}
            set{minVertex = value;}
        }
        public static int S
        {
            get { return s; }
            set { s = value; }
        }
        public static int D
        {
            get { return d; }
            set { d = value; }
        }
        public static int W
        {
            get { return w; }
            set { w = value; }
        }
        #endregion ########### End declaration of public properties ##########

        static void Main(string[] args)
        {
            int Vertices = Convert.ToInt32(Console.ReadLine());
            int Edges = Convert.ToInt32(Console.ReadLine());
            totalVertex = Vertices;

            adjacencyList = new LinkedList<Tuple<int>>[Vertices];
            mstSet = new List<int>();
            sourceV = new List<int>();
            destinationV = new List<int>();
            weightVal = new List<int>();

            vKeyVal = new int[Vertices];
            vKeyVal[0] = 0;
            for (int i = 1; i < vKeyVal.Length; i++)
                vKeyVal[i] = INF;
            mstSet.Add(0);// vertex 0 is picked initially

            for (int i = 0; i < adjacencyList.Length; i++)
                adjacencyList[i] = new LinkedList<Tuple<int>>(); // initialize empty adjacency list

            Console.WriteLine("Enter Start(vertex), End(Vertex) and Weight of each edge: ");
            while (Edges > 0) //Enter each edge
            {
                int[] startEndVertex = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int startVertex = startEndVertex[0];
                int endVertex = startEndVertex[1];
                int weight = startEndVertex[2];
                addEdge(startVertex, endVertex,weight);
                Edges--;
            }

            while (mstSet.Count <= Vertices-1)
            {
                primsMST(adjacencyList, mstSet.Count - 1);
            }

            for(int i = 0; i < Vertices-1; i++)
            {
               Console.WriteLine(sourceV[i] + " -> " + destinationV[i] + ", weight: " + weightVal[i]);
            }
            Console.Read();
        }

        static void addEdge(int sV, int eV,int weight)
        {
            adjacencyList[sV].AddFirst(new Tuple<int>(eV,weight));
            adjacencyList[eV].AddFirst(new Tuple<int>(sV, weight));
        }

        static void iterateAdjacent(LinkedList<Tuple<int>>[] adjacencyList, int count)
        {
            foreach (Tuple<int> list in adjacencyList[mstSet[count]])
            {
                if (vKeyVal[list.endV] == int.MaxValue)
                    vKeyVal[list.endV] = list.weight;

                if (vKeyVal[list.endV] < int.MaxValue && MIN > vKeyVal[list.endV] && !mstSet.Contains(list.endV))
                {
                    MIN = vKeyVal[list.endV];
                    minVERTEX = list.endV;

                    S = mstSet[count];
                    D = minVERTEX;
                    W = MIN;
                }
            }
        }

        static void primsMST(LinkedList<Tuple<int>>[] adjacencyList,int count)
        {
            minVERTEX = 0;
            MIN = int.MaxValue;

            iterateAdjacent(adjacencyList,count); //iterate over adjacent vertices

            if (minVERTEX == 0 && mstSet.Count < totalVertex){
                count--; //backtrack to find untravelled vertex
                iterateAdjacent(adjacencyList, count); //iterate over adjacent vertices
            }

            sourceV.Add(S);
            destinationV.Add(D);
            weightVal.Add(W);
            mstSet.Add(minVERTEX);
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
}
