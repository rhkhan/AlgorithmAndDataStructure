using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floyd_Warshall_ShortestPath
{
    class Program
    {
        public const int INF = 999;

        static void Main(string[] args)
        {
            int[,] array = new int[4, 4]
                   {
                      { 0, 3, 6, 15 },
                      { INF,  0,  -2, INF },
                      { INF,INF, 0,   2 },
                      { 1,INF, INF,  0 }
                   };
            int[,] path = new int[4, 4];


            for(int i=0;i<array.GetLength(0);i++)
                for(int j=0;j<array.GetLength(1);j++)
                {
                    if (array[i, j] != INF && i != j)
                        path[i, j] = i;
                    else
                        path[i, j] = -1;
                }

            FloydWarshall(array,path);
        }


        static void FloydWarshall(int[,] array,int[,] path)
        {
            for (int k = 0; k <= 3; k++){
                for (int i = 0; i <= 3; i++){
                    for (int j = 0; j <= 3; j++){
                        if(array[i,k]==INF || array[k,j]==INF){
                            continue;
                        }
                        if (array[i, j] > (array[i, k] + array[k, j])){
                            array[i, j] = array[i, k] + array[k, j];
                            path[i, j] = path[k, j];
                        }
                    }
                }
            }

            for(int i=0;i<array.GetLength(0);i++){
                if (array[i, i] < 0) // check NegativeCycleException
                    throw new IndexOutOfRangeException();
            }

            Console.WriteLine("Shortest distances betweeen every pair of the vertices: ");
            for (int m = 0; m <= 3; m++){
                for (int n = 0; n <= 3; n++){
                    if (array[m, n] == INF)
                        Console.Write("INF".PadLeft(7));
                    else
                        Console.Write(array[m, n].ToString().PadLeft(7));
                }
                Console.WriteLine();
            }

            Console.WriteLine("path matrix: ");
            printPathMatrix(path);

            shortestPath(path, 3, 2);

            Console.Read();
        }

        static void printPathMatrix(int[,] path)
        {
            for (int m = 0; m <= 3; m++){
                for (int n = 0; n <= 3; n++){
                        Console.Write(path[m, n].ToString().PadLeft(7));
                }
                Console.WriteLine();
            }
        }

        static void shortestPath(int[,] path, int i, int j)
        {
            if (i < 0 || j < 0 || i >= path.GetLength(0) || j >= path.GetLength(1)){
                throw new ArgumentOutOfRangeException();
            }
            Console.WriteLine("Actual path between " + i + " and " + j + " with minimun cost: ");

            Stack sp = new Stack();
            sp.Push(j); // put j(destination) in the stack
            while (true)
            {
                j = path[i, j]; // put i,j path in j
                if (j == -1) // if j=-1 then no path, return
                    return;

                sp.Push(j); // put path j in stack

                if (j == i) // if source=destination then break, we reach the destination
                    break;
            }

            while (sp.Count>0) // print the path by popping from the stack
            {
                int p=(int)sp.Pop();
                Console.Write(p);
                if (sp.Count != 0)
                    Console.Write("->");
            }
        }

    }
}
