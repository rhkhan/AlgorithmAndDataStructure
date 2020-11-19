// C# program to rotate a linked list 
using System;

public class LinkedList
{
    Node head;
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

    void rotate(int k)
    {

        Node current = head;
        Node rhead = null;

        int count = 0;
        while (current != null && count < k)
        {
            current = current.next;
            count++;
        }
        rhead = current;

        current = head;
        count = 0;
        while (current != null && count < k-1)
        {
            current = current.next;
            count++;
        }
        current.next = null;

        Node c = rhead;
        while (c.next != null)
        {
            c = c.next;
        }
        c.next = head;

        head = rhead;
    }

    void push(int new_data)
    {
        Node new_node = new Node(new_data);
        new_node.next = head;
        head = new_node;
    }

    void printList()
    {
        Node temp = head;
        while (temp != null)
        {
            Console.Write(temp.data + " ");
            temp = temp.next;
        }
        Console.WriteLine();
    }

    /* Driver code */
    public static void Main()
    {
        LinkedList llist = new LinkedList();

        // create a list 10->20->30->40->50->60 
        for (int i = 60; i >= 10; i -= 10)
            llist.push(i);

        Console.WriteLine("Given list");
        llist.printList();

        llist.rotate(4);

        Console.WriteLine("Rotated Linked List");
        llist.printList();

        Console.Read();
    }
}
