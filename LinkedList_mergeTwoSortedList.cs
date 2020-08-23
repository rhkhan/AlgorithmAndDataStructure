using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoSortedLinkedList
{
    class Node
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

        public void insert(int data)
        {
            if (head == null)
                head = new Node(data);

            else
            {
                Node current = head;
                while (current.next != null)
                    current = current.next;

                current.next = new Node(data);
            }

        }

    }

     
    class MergeLinkedList
    {
        public Node mergeLists(Node nodeA, Node nodeB)
        {
            Node temp = new Node(0);
            Node result = temp;
            while (nodeA != null && nodeB != null)
            {
                if (nodeA.data <= nodeB.data)
                {
                    temp.next = nodeA;
                    nodeA = nodeA.next;
                }
                else
                {
                    temp.next = nodeB;
                    nodeB = nodeB.next;
                }
                temp = temp.next;
            }

            while (nodeA != null)
            {
                temp.next = nodeA;
                nodeA = nodeA.next;
            }

            while (nodeB != null)
            {
                temp.next = nodeB;
                nodeB = nodeB.next;
            }
            return result.next;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list1 = new LinkedList();
            LinkedList list2 = new LinkedList();

   
            list1.insert(5);
            list1.insert(10);
            list1.insert(15);

            list2.insert(2);
            list2.insert(3);
            list2.insert(20);

            MergeLinkedList mll = new MergeLinkedList();
            Node result =mll.mergeLists(list1.head, list2.head);

            while (result != null)
            {
                Console.Write(result.data + " ");
                result = result.next;
            }

            Console.Read();
        }
    }
}
