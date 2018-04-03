using System;
using System.Collections.Generic;


namespace SegmentTreeMultiplication
{
    public class Program
    {
        static int[] tree;
        static int maxsize;
        static int height;
        static int STARTINDEX = 0;
        static int ENDINDEX;
        static int ROOT = 0;

        public static void Main()
        {
            int T;
            Int32.TryParse(Console.ReadLine(), out T);

            for (int testCase = 1; testCase <= T; testCase++)
                {
                Console.ReadLine();
                //int[] NQ = Array.ConvertAll(Console.ReadLine().Split(),Int32.Parse);
                    string[] Snq = Console.ReadLine().Split();

                    int N = 0;// Convert.ToInt32(Snq[0]);//NQ[0];
                    int Q = 0; //Convert.ToInt32(Snq[1]);//NQ[1];
                    int.TryParse(Snq[0], out N);
                    int.TryParse(Snq[1], out Q);

                    int[] elements = new int[N];
                    string[] sElements = Console.ReadLine().Split();
                    for (int el = 0; el < sElements.Length; el++)
                        int.TryParse(sElements[el], out elements[el]);

                    //elements = Array.ConvertAll(sElements, Int32.Parse);
                    ENDINDEX = elements.Length - 1;

                    // Defining the size of the segement tree from the original tree
                    height = (int)(Math.Ceiling(Math.Log(elements.Length) / Math.Log(2)));
                    maxsize = 2 * (int)Math.Pow(2, height) - 1;
                    tree = new int[maxsize];


                    buildSegmentTree(elements, STARTINDEX, ENDINDEX, ROOT);

                    int[] rs = new int[Q]; // start 
                    int[] re = new int[Q]; // end
                    int[] min = new int[Q]; // minimum multiplication value
                    int minCount = 0;

                    for (int query = 1; query <= Q; query++) // Loop for defining each query range
                    {
                        //int[] qr = Array.ConvertAll(Console.ReadLine().Split(), Int32.Parse);
                        string[] sQR = Console.ReadLine().Split();
                        //int[] qr = Array.ConvertAll(sQR, Int32.Parse);
                        //int qs = qr[0];
                        //int qe = qr[1];
                        int qs = 0;
                        int qe = 0;

                        int.TryParse(sQR[0], out qs);
                        int.TryParse(sQR[1], out qe);

                        int count = 0, j = 0;
                        List<int> store = new List<int>();

                        for (int i = qs; i <= qe; i++) // multiplication for each element inside a query range
                        { // To generate index like (2,2),(2,3),(2,4),(3,3),(3,4),(4,4) for the range 2 to 4
                            count = i;
                            while (count <= qe)
                            {
                                store.Add(getIntervalMultiplication(STARTINDEX, ENDINDEX, i - 1, count - 1, ROOT));

                                if (j == 0)// first time assignment
                                {
                                    min[minCount] = store[j];
                                    rs[minCount] = i;
                                    re[minCount] = count;
                                }

                                if (store[j] < min[minCount])
                                {
                                    rs[minCount] = i;
                                    re[minCount] = count;
                                    min[minCount] = store[j];
                                }
                                else if (store[j] == min[minCount])
                                {
                                    if ((count - i) > (re[minCount] - rs[minCount]))
                                    {
                                        rs[minCount] = i;
                                        re[minCount] = count;
                                    }
                                }

                                j++;
                                count++;
                            }

                        }
                        minCount++;

                    }

                    Console.WriteLine("Case {0}:", testCase);
                    for (int c = 0; c < min.Length; c++)
                    {
                        Console.WriteLine(min[c] + " " + rs[c] + " " + (re[c]));
                    }
                }
        
            Console.Read();
        }


        static int buildSegmentTree(int[] array, int startIndex, int endIndex, int current)
        {
            if (startIndex > endIndex)
                return 1;

            if (startIndex == endIndex)
            {
                tree[current] = array[startIndex];
                return tree[current];
            }

            int mid =  (startIndex + (endIndex - startIndex) / 2);
            tree[current] = buildSegmentTree(array, startIndex, mid, 2*current+1)* buildSegmentTree(array, mid + 1, endIndex, 2*current+2);

            return tree[current];

        }

        static int getIntervalMultiplication(int startIndex, int endIndex, int queryStart, int queryEnd, int current)
        {
            //if current node limit lies within the query range then return current segment node value
            if (queryStart <= startIndex && queryEnd >= endIndex)
            {
                return tree[current];
            }
            // if current node limit lies fully outside the query range then return 1
            if (endIndex < queryStart || startIndex > queryEnd)
            {
                return 1;
            }
            // else current node limit and query range intersect partially each other then
            // traverse through left and right leaf nodes
            int mid = startIndex + (endIndex - startIndex) / 2;
            return getIntervalMultiplication(startIndex, mid, queryStart, queryEnd, 2*current+1)
                     * getIntervalMultiplication(mid + 1, endIndex, queryStart, queryEnd, 2*current+2);

        }


    }
}
