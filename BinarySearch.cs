using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
       static int pos= 0;

        static void Main(string[] args)
        {
            int[] array = new int[] { 10, 23, 45,60, 67, 87,104,187};
            if (binarySearch(array, 45, 0, array.Length - 1))
                Console.WriteLine("Found at position "+pos);
            else
                Console.WriteLine("Element does not exist in the array");

            Console.Read();
        }


        static bool binarySearch(int[] array, int x, int left, int right)
        {
            if (left > right)
                return false;

            int mid = (left + right) / 2;

            if (x == array[mid])
            {
                pos = mid;
                return true;
            }
            else if (x < array[mid])
                return binarySearch(array, x, left, mid - 1);
            else
                return binarySearch(array, x, mid + 1, right);

        }
    }
}
