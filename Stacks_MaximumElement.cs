using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_MaximumElement
{
    class Program
    {
        static void Main(String[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            Stack<int> st = new Stack<int>();
            Stack<int> m = new Stack<int>();
            int max = int.MinValue;

            while (N > 0)
            {
                string s = "";
                while ((s = Console.ReadLine()) != null)
                {
                    string[] qN = s.Split(' ');
                    if (qN[0].Equals("1"))
                    {
                        int val = Convert.ToInt32(qN[1]);
                        max = Math.Max(val, max);
                        st.Push(max);
                    }
                    else if (qN[0].Equals("2"))
                    {
                        if (st.Count > 0)
                            st.Pop();

                        if (st.Count == 0)
                            max = int.MinValue;
                        else
                        {
                            max = st.Peek();
                        } 
                    }
                    else
                        Console.WriteLine(st.Peek());
                }
                N--;
            }
            Console.Read();
        }
    }
}
