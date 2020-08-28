using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListIntersectionofSortedLists
{
    public class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }
    }

    class LinkedList
    {

        public Node head;
        public Node result = null;
        public Node a = null;
        public Node b = null;
        public Node getIntersection(Node a,Node b)
        {
            while(a!=null & b != null)
            {
                if (a.data == b.data)
                {
                    pushR(a.data);

                    result = result.next;
                    a = a.next;
                    b = b.next;
                }
                else if (a.data < b.data)
                {
                    a = a.next;
                }
                else
                    b = b.next;
            }
           // head.next = null;
            return head;
        }

        public void printList(Node resulthead)
        {
            Node current = resulthead;
            while (current.next != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
        }
        public void pushR(int data)
        {
            Node new_node = new Node(data);
            new_node.next = result;
            result = new_node;
        }

        public void push(Node headref, int data)
        {
            Node new_node = new Node(data);
            new_node.next = head;
            head = new_node;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            LinkedList llist = new LinkedList();
            //Node a = null;
            //Node b = null;
            //Node result = null;

            llist.push(llist.a, 6);
            llist.push(llist.a, 5);
            llist.push(llist.a, 4);
            llist.push(llist.a, 3);
            llist.push(llist.a, 2);
            llist.push(llist.a, 1);
            llist.a = llist.head;

            llist.head = null;

            llist.push(llist.b, 8);
            llist.push(llist.b, 6);
            llist.push(llist.b, 4);
            llist.push(llist.b, 2);
            llist.b = llist.head;
            llist.result =llist.getIntersection(llist.a, llist.b);


            Console.WriteLine("Intersected list: ");
            llist.printList(llist.result);
            Console.WriteLine();

            Console.Read();

        }

    }
}
