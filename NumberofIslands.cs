using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberofIslands
{

    class DisjontSet
    {
       public int[] parent;
        //int[,] mat;
        public DisjontSet(int row,int col)
        {
            parent = new int[row * col];
        }

        public void makeSet(int d)
        {
            parent[d] = d;
        }
        
        public int findset(int x)
        {
            if (parent[x] == x)
                return x;
            parent[x] = findset(parent[x]);
            return parent[x];
        }

        public void union(int x,int y)
        {
            parent[x] = y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[,] matIslands= 
                    {
                        { 1, 1, 0, 0, 0 },
                        { 0, 1, 0, 0, 1},
                        { 1, 0, 0, 1, 1},
                        { 0, 0, 0, 0, 0},
                        { 1, 0, 1, 0, 1}
                    };

            countIslands(matIslands);

            Console.Read();
        }

        static void countIslands(int[,] matIslands)
        {
            int row = matIslands.GetLength(0);
            int col = matIslands.GetLength(1);

            DisjontSet dsu = new DisjontSet(row, col);

            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    if (matIslands[i, j] == 1)
                        dsu.makeSet(i * col + j); // make set for each nonzero cell
                    else
                        dsu.parent[i * col + j] = -1;
                }
            }

            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    if (matIslands[i, j] == 1) // foreach nonzero cell
                    {
                        int x = dsu.findset(i * col + j); //find it's parent

                        //######## find the parent of each nonzero adjacent cell,
                        // ###### if parent is not same then do union ########

                        if (i - 1 >= 0 && matIslands[i - 1, j] == 1) //up
                        {
                            int y = dsu.findset((i - 1) * col + j); // find parent of the adjacent nonzero cell
                            if(x!=y) // if they do not belong to the same set then do a union
                                dsu.union((i - 1) * col + j, x); // making both cell to the same set
                        }
                        if (i - 1 >= 0 && j - 1 >= 0 && matIslands[i - 1, j - 1] == 1) //diagonal up left
                        {
                            int y = dsu.findset((i - 1) * col + (j - 1));
                            if (x != y)
                                dsu.union((i - 1) * col + (j - 1), x);
                        }
                            
                        if (i - 1 >= 0 && j + 1 < col && matIslands[i - 1, j + 1] == 1) //diagonal up right
                        {
                            int y = dsu.findset((i - 1) * col + (j + 1));
                            if (x != y)
                                dsu.union((i - 1) * col + (j + 1), x);
                        }
                        if (i + 1 < row && matIslands[i + 1, j] == 1) //down
                        {
                            int y = dsu.findset((i + 1) * col + j);
                            if (x != y)
                                dsu.union((i + 1) * col + j, x);
                        }
                        if (i + 1 < row && j - 1 >= 0 && matIslands[i + 1, j - 1] == 1) //diagonal down left
                        {
                            int y = dsu.findset((i + 1) * col + (j - 1));
                            if (x != y)
                                dsu.union((i + 1) * col + (j - 1), x);
                        }
                        if (i + 1 < row && j + 1 < col && matIslands[i + 1, j + 1] == 1) //diagonal down right
                        {
                            int y = dsu.findset((i + 1) * col + (j + 1));
                            if (x != y)
                                dsu.union((i + 1) * col + (j + 1), x);
                        }
                        if (j-1>=0 && matIslands[i, j-1] == 1) //left
                        {
                            int y = dsu.findset(i * col + (j - 1));
                            if (x != y)
                                dsu.union(i * col + (j - 1), x);
                        }
                        if (j + 1<col && matIslands[i, j + 1] == 1) //right
                        {
                            int y = dsu.findset(i * col + (j + 1));
                            if (x != y)
                                dsu.union(i * col + (j + 1), x);
                        }
                            
                    }
                }
            }// end outer loop

            Dictionary<int, int> dic = new Dictionary<int, int>();
            for(int i = 0; i < dsu.parent.Length; i++)
            {
                
                if (dsu.parent[i] != -1)
                {
                    if (!dic.ContainsKey(dsu.parent[i]))
                        dic.Add(dsu.parent[i],1); // for each different non -1 value, add a key
                }
            }

            Console.WriteLine("Number of Islands: " + dic.Keys.Count()); // print the number of keys, that will represent the number of islands
        }// end countIslands method

    }
}
