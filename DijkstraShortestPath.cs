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

            Dijkstra(graph, 0);

            Console.Read();
        }



        static void Dijkstra(int[,] grpahArray, int source)
        {

            int[] adjacentArray = new int[V]; // to store the shortest distance value from the source to all nodes
            int[] trackAdjacent = new int[V]; // to track the min path from the recent source
            int[] sptArray = new int[V]; // to track if all the nodes have been checked
            
            int originalSource = source;

            for (int i = 0; i < V; i++)
                adjacentArray[i] = INF;
            adjacentArray[source] = 0; // From source to source, distance is always zero



            sptArray[source] = 0; // initial source vertex is tracked at the first place
            int sptIndex = 1;
            int currentSource = source;


            for (int i = currentSource; i < V; i++) // loop for source
            {
                trackAdjacent = new int[V]; // to get minimum distance value from the current source
                for (int val = 0; val < trackAdjacent.Length; val++)
                    trackAdjacent[val] = INF;

                for (int j = 0; j < V; j++) // loop from source to available valid adjacent nodes can be reached
                {
                    if (grpahArray[i, j] > 0 && !sptArray.Contains(j)) // If adjacent node can be reached and not allready considered
                    {
                        if (adjacentArray[j] > (adjacentArray[source] + grpahArray[i, j]))
                        {
                            adjacentArray[j] = adjacentArray[source] + grpahArray[i, j]; // update adjacent list
                            trackAdjacent[j] = adjacentArray[j];
                        }
                        else
                        {
                            trackAdjacent[j] = adjacentArray[j];
                        }

                        int minValue = trackAdjacent.Min();
                        int p = Array.IndexOf(trackAdjacent, minValue); // get index of the minimum vertex


                        // after update operation select the minimum weighted node as the destination to travel from the current source
                        // and make the travelled destination as the new source

                        currentSource = p; // set the current souce to the minimum distance valued vertex

                    }
                }

                source = currentSource;// update the source in the adjacent array
                i = source - 1;
                sptArray[sptIndex] = currentSource;
                sptIndex++;
                if (sptIndex > sptArray.Length - 1)
                    break;
            }

            Console.WriteLine("Dijkstra Algorithm: Distance from source vertex to destination vertex---");
            Console.WriteLine();
            Console.WriteLine("Destination   Distance from Source ("+originalSource+")");
            for (int i = 0; i < adjacentArray.Length; i++)
            {
                Console.WriteLine(i + "              " + adjacentArray[i]);
            }

        }


    }
}
