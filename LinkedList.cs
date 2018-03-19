using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedList
{
   public class Program
    {
 

        static void Main(string[] args)
        {

            Node head = null; // initially linked list is empty
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0) {
                int data = Convert.ToInt32(Console.ReadLine());
                head=insert(head, data); // insert data sequentially in linked list.
                T--;
            }

            display(head);
        }


        public static Node insert(Node head, int data)
        {
            Node nod = head; // set the Nodes with the newly assigned node
            if (head == null)
            {

                return new Node(data);
            }

            while (head.Next != null) // traverse if current node has next pointer
            {
                head = head.Next;
            }
            head.Next = new Node(data); // set the current head next pointer to the newly assigned data/node

            return nod; // return the linked-list nodes information
        }

        public static void display(Node head) {
            Node start = head;
            while (start != null) {
                Console.Write(start.Data+" ");
                start = start.Next;
            }
        }

    }
    
public class Node{

        int data;
        Node next;

        public Node(int newData) {
            data = newData;
            next = null;
        }

        public int Data {
            get { return data; }
            set { data = value; }
        }

        public Node Next
        {
            get { return next; }
            set { next = value; }
        }

    }
    
}
