// C# program for sorted insert 
// in circular linked list 
using System;
namespace CircularLinkedList_sortedinsert
{
    class LinkedList
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
        Node head;

        LinkedList()
        {
            head = null;
        }

        void sortedInsert(Node new_node)
        {
            Node current = head;
            if (current == null) // if head is null
            {
                new_node.next = new_node;
                head = new_node;

            }
            else if (current.data >= new_node.data) // if newnode data is less then the head data
            {
                while (current.next != head)
                    current = current.next;

                current.next = new_node;
                new_node.next = head;
                head = new_node;
            }
            else // if newnode data is smaller between the linked list. i.e in the middle of the head and last node
            {
                while (current.next != head &&
                    current.next.data < new_node.data)
                    current = current.next;

                new_node.next = current.next;
                current.next = new_node;
            }
        }

        void printList()
        {
            if (head != null)
            {
                Node temp = head;
                do
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                }
                while (temp != head);
            }
        }

        // Driver code 
        public static void Main(String[] args)
        {
            LinkedList list = new LinkedList();
            int[] arr = { 12, 56, 2, 11, 1, 90 };
            Node temp = null;
            for (int i = 0; i < 6; i++)
            {
                temp = new Node(arr[i]);
                list.sortedInsert(temp);
            }
     
            list.printList();

            Console.Read();
        }
    }
}
