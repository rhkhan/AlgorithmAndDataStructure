using System;
using System.Collections;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStack
{
    class Program
    {
        static Stack st = new Stack();
        static bool isEmpty=false;
        public static void reverse(Stack st)
        {
            char val = (char)st.Pop();

            if (st.Count == 0 || isEmpty)
            {
                isEmpty = true;
                st.Push(val);
                return;
            }
            else
            {
                reverse(st);
                st.Push(val);
            }
        }
        static void Main(string[] args)
        {
            //bool isEmpty = false;
            st.Push('1');
            st.Push('2');
            st.Push('3');
            st.Push('4');

            Console.WriteLine("Original Stack");

            foreach (char i in st)
            {
                Console.WriteLine(i);
            }

            // function to reverse  
            // the stack  
            reverse(st);

            Console.WriteLine("Reversed Stack");
            foreach (char c in st)
            {
                Console.WriteLine(c);
            }

            Console.Read();
        }

    }
}
