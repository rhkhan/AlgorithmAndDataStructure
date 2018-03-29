using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 23, 14, 56, 12, 10, 9, 4, 2, 50 };
            int[] temp = new int[array.Length];

            margeSort(array, temp, 0, array.Length - 1);

            for (int i = 0; i < array.Length; i++) {
                Console.Write(array[i]+" ");
            }

            Console.Read();
        }

        static void margeSort(int[] array, int[] temp, int start, int end)
        {
            if (start >= end)
                return;

            int middle = (start + end) / 2;
            margeSort(array, temp, start, middle);
            margeSort(array, temp, middle + 1, end);
            margeHalves(array, temp, start, end);
        }

        static void margeHalves(int[] array, int[] temp, int start, int end)
        {
            int leftHalfEnd = (start + end) / 2;
            int rightHalfStart = leftHalfEnd + 1;
            int size = end - start+1;

            int leftIndex = start; // first half start;
            int rightIndex = rightHalfStart; // second half start
            int index = start;

            // traverse through left-half and right-half and sort the both sides and put value into temp array
            while (leftIndex <= leftHalfEnd && rightIndex <= end)
            {
                if (array[leftIndex] <= array[rightIndex])
                {
                    temp[index] = array[leftIndex];
                    leftIndex++;
                }
                else
                {
                    temp[index] = array[rightIndex];
                    rightIndex++;
                }

                index++;
            }

            Array.ConstrainedCopy(array, leftIndex, temp, index, leftHalfEnd - leftIndex + 1); // copy the remaining element from the left side into temp;
            Array.ConstrainedCopy(array, rightIndex, temp, index, end - rightIndex + 1); // copy the remaining element from the right side into temp;
            Array.ConstrainedCopy(temp, start, array, start, size);// finally copy the final temp array back to the original array
        }
    }
}
