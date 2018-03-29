using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {

        int _ar_size;
        _ar_size = Convert.ToInt32(Console.ReadLine());
        int[] _ar = new int[_ar_size];
        String elements = Console.ReadLine();
        String[] split_elements = elements.Split(' ');
        for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
        {
            _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
        }

        QuickSort(_ar, 0, _ar.Length - 1);

        for (int i = 0; i < _ar.Length; i++)
            Console.Write(_ar[i] + " ");

        Console.Read();
    }

    static void QuickSort(int[] ar, int start, int end)
    {

        if (start < end)
        {
            int pIndex = partition(ar, start, end);
            QuickSort(ar, start, pIndex - 1); // before the pivot element
            QuickSort(ar, pIndex + 1, end); // after the pivot element
        }
    }

    static int partition(int[] a, int start, int end)
    {
        int pivot = a[end]; // place the last element as pivot
        int j = start; // index of smaller element
        int temp = 0;

        for (int i = start; i < end; i++)
        {
            if (a[i] <= pivot)
            {
                temp = a[i];
                a[i] = a[j];
                a[j] = temp;
                j++;
            }
        }

        temp = a[end];
        a[end] = a[j];
        a[j] = temp;

        return j;
    }

}
