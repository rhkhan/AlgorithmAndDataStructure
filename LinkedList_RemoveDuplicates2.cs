using System;

public class LinkedList
{
    Node head; // head of list 
    class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            data = d; next = null;
        }
    }

    void removeDuplicates()
    {
        if (head == null)
            return;

        Node current = head;
        Node next = head.next;

        while (next != null && current!=null)
        {
            if (current.data == next.data)
            {
                next = next.next;
                current.next = next;
            }
            else // advance to next current
                current = current.next;
        }
    }


    public void push(int new_data)
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

    public static void Main(String[] args)
    {
        LinkedList llist = new LinkedList();
        llist.push(20);
        llist.push(13);
        llist.push(13);
        llist.push(11);
        llist.push(11);
        llist.push(11);

        Console.WriteLine("List before removal of duplicates");
        llist.printList();

        llist.removeDuplicates();

        Console.WriteLine("List after removal of elements");
        llist.printList();
        
        Console.Read();
    }
}
