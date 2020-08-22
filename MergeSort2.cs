using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort2
{

    public class MergeSort
    {
        public void sort(int[] arr,int l,int r)
        {
            if (l < r)
            {
                int mid = (l + r) / 2;
                sort(arr, l, mid);
                sort(arr, mid + 1, r);
                merge(arr, l, mid, r);
            }
        }

        public void merge(int[] arr,int l,int m,int r)
        {
            int sizeLeft = m - l + 1;
            int sizeRight = r - m;

            int[] leftArr = new int[sizeLeft];
            int[] rightArr = new int[sizeRight];
            int i, j;

            for (i = 0;i< sizeLeft; i++)
                leftArr[i] = arr[l + i];
            for (i = 0; i < sizeRight; i++)
                rightArr[i] = arr[m + 1 + i];

            i = 0; j = 0;
            int k = l;
            while(i<sizeLeft && j < sizeRight)
            {
                if (leftArr[i] <= rightArr[j])
                {
                    arr[k] = leftArr[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArr[j];
                    j++;
                }
                k++;
            }

            //For the remaining elements
            while(i<sizeLeft)
            {
                arr[k] = leftArr[i];
                i++;
                k++;
            }

            while (i < sizeRight)
            {
                arr[k] = rightArr[i];
                i++;
                k++;
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            MergeSort ms = new MergeSort();
            Console.WriteLine("Given Array");
            printArray(arr);
            ms.sort(arr, 0, arr.Length - 1);
            Console.WriteLine("Sorted Array");
            printArray(arr);

            Console.Read();
        }

        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

    }
}
