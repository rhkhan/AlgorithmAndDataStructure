using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroOneKnapsackAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayValue = { 60, 100, 120 };
            int[] arrayWeight = { 10, 20, 30 };
            int totalWeight = 50;
            int n = arrayValue.Length;

            int[,] arrayMatrix = new int[n, totalWeight+1];

            for (int i = 0; i < n; i++)
                arrayMatrix[i, 0] = 0; // set 0 when totalWeight=0, for all the individual item 

            for (int j = 1; j <= totalWeight; j++)
            {
                if (arrayWeight[0] <= j)
                    arrayMatrix[0, j] = arrayWeight[0]; // set value of all columns of row 0 to the weight value when weight
                                                        // value is less then or equal to totalWeight 
            }


            arrayMatrix = knapsack(arrayValue, arrayWeight, arrayMatrix,totalWeight,n);


            Console.WriteLine("Knapsack matrix: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= totalWeight; j++)
                {
                    Console.Write((" " + arrayMatrix[i, j]).PadLeft(7));
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            int rowIndex = arrayValue.Length-1;
            int colIndex = totalWeight;
            List<int> selectedItem = new List<int>();
            int sum = 0;

            Console.WriteLine("Selected items with maximum value and less then or equal to total weight are: ");
            while (rowIndex >= 0)
            {
                if (sum > totalWeight)
                    break;
                if (arrayMatrix[rowIndex - 1, colIndex] == arrayMatrix[rowIndex, colIndex])
                {
                    //selectedItem.Add(arrayWeight[rowIndex-1]);
                    selectedItem.Add(rowIndex - 1);
                    sum += arrayWeight[rowIndex - 1];
                    rowIndex--;
                }
                else
                {
                    //arrayMatrix[i - 1, j - aw[i]]
                    //selectedItem.Add(arrayWeight[rowIndex-1]);
                    selectedItem.Add(rowIndex - 1);
                    sum += arrayWeight[rowIndex];
                }
            }

            
            for (int item = selectedItem.Count-1; item>=0; item--)
                Console.WriteLine((arrayWeight[selectedItem[item]]+"("+arrayValue[selectedItem[item]]+")").PadLeft(7));

            Console.Read();
        }


        static int[,] knapsack(int[] av, int[] aw, int[,] arrayMatrix, int totalWeight, int n)
        {
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j <= totalWeight; j++)
                {
                    if (j < aw[i])
                    {
                        arrayMatrix[i, j] = arrayMatrix[i - 1, j];
                    }
                    else
                    {
                        arrayMatrix[i, j] = Math.Max(av[i] + arrayMatrix[i - 1, j - aw[i]], arrayMatrix[i - 1, j]);
                    }
                }
            }
            int maxVal = arrayMatrix[n-1,totalWeight];
            return arrayMatrix;
        }

    }
}
