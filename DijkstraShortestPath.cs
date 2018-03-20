using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DijkstraAlgorithm
{
    class Program
    {

        public const int V = 9;
        public const int INF = Int32.MaxValue;
        static void Main(string[] args)
        {
            //int[][] graph=new int[V][];

            int[,] graph =  {
                                {0, 4, 0, 0, 0, 0, 0, 8, 0},
                                {4, 0, 8, 0, 0, 0, 0, 11, 0},
                                {0, 8, 0, 7, 0, 4, 0, 0, 2},
                                {0, 0, 7, 0, 9, 14, 0, 0, 0},
                                {0, 0, 0, 9, 0, 10, 0, 0, 0},
                                {0, 0, 4, 0, 10, 0, 2, 0, 0},
                                {0, 0, 0, 14, 0, 2, 0, 1, 6},
                                {8, 11, 0, 0, 0, 0, 1, 0, 7},
                                {0, 0, 2, 0, 0, 0, 6, 7, 0}
                            };

            Dijkstra(graph, 5);

            Console.Read();
        }


        
        static void Dijkstra(int[,] grpahArray, int source) { 
        
            int[] adjacentArray=new int[V];
            int[] trackAdjacent = new int[V];
            int[] sptArray = new int[V];

            for (int i = 0; i < V; i++)
                adjacentArray[i] = INF;
            adjacentArray[source] = 0;


            
            sptArray[0] = 0;
            int sptIndex=1;
            int currentSource = 0;
            

            for (int i = 0; i < V; i++)
            {
                int track=0;
                trackAdjacent = new int[V];
                for (int val = 0; val < trackAdjacent.Length; val++)
                    trackAdjacent[val] = INF;

                    for (int j = 0; j < V; j++)
                    {
                        if (grpahArray[i, j] > 0 && !sptArray.Contains(j))
                        {
                            track = j;

                            if (adjacentArray[j] > (adjacentArray[source] + grpahArray[i, j]))
                            {
                                adjacentArray[j] = adjacentArray[source] + grpahArray[i, j]; // update adjacent list
                                trackAdjacent[track] = adjacentArray[j];
                            }
                            else{
                                trackAdjacent[track] = adjacentArray[j];
                            }

                            int minValue = trackAdjacent.Min();
                            int p = Array.IndexOf(trackAdjacent, minValue);


                            // after update operation select the minimum weighted node as the destination to travel from the current source
                            // and make the travelled destination as the new source

                            currentSource = p;

                        }
                    }

                source = currentSource;// update the source in the adjacent array
                i = source-1;
                sptArray[sptIndex] = currentSource;
                sptIndex++;
                if (sptIndex > sptArray.Length - 1)
                    break;
            }

            Console.WriteLine("Dijkstra Algorithm: Distance from source vertex to destination vertex---");
            Console.WriteLine();
            Console.WriteLine("Vertex  Distance from Source");
            for (int i = 0; i < adjacentArray.Length; i++) {
                Console.WriteLine(i + "              " + adjacentArray[i]);
            }

        }


    }
}
