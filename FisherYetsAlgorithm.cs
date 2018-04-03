//Algorithm: Fisher-Yets (Modern version)
//Auther: Rashedul Hossain Khan
//Purpose: Randomly shuffles an array

using System;
using System.Collections.Generic;

namespace FisherYetsAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] scratch = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            List<int> result = new List<int>();

            int n = scratch.Length-1;
            int temp = 0;
            int j=0;

            Console.WriteLine("Original Array");
            for (int index = 0; index < scratch.Length; index++)
                Console.Write(scratch[index] + " ");

            //Shuffling with two array
            while (n>0) // 0 to 7, 0 to 6, 0 to 5 and so on...
            {
                j = new Random().Next(0,n); // pick the jth number randomly
                result.Add(scratch[j]); //add the randomly picked number to a new array

                if (n == 1)
                {
                    if (j == 1)
                        result.Add(scratch[0]);
                    else
                        result.Add(scratch[1]);
                }

                temp = scratch[n]; // swap the jth and nth number; take the randomly picked number to the last index
                scratch[n] = scratch[j];
                scratch[j] = temp;

                n--;
            }
            Console.WriteLine();
            Console.WriteLine("Array after shuffling using Fisher-Yets algorithm (using 2 arrays):");
            for (int index = 0; index < result.Count; index++)
                Console.Write(result[index]+" ");


            //Shuffling with one array
            int[] scratch2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            n = scratch2.Length - 1;
            while (n > 0) // 0 to 7, 0 to 6, 0 to 5 and so on...
            {
                j = new Random().Next(0, n); // pick the jth number randomly
                temp = scratch2[n]; // swap the jth and nth number; take the randomly picked number to the last index
                scratch2[n] = scratch2[j];
                scratch2[j] = temp;
                n--;
            }

            Console.WriteLine();
            Console.WriteLine("Array after shuffling using Fisher-Yets algorithm (using one array):");
            for (int index = 0; index < scratch2.Length; index++)
                Console.Write(scratch2[index] + " ");

            Console.Read();
        }
    }
}
