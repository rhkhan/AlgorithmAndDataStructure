using System;
using System.Threading;

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

    void swapNodes(int x,int y) // x=4,y=3; 1->2->3->4->5->6->7
    {
        if (head == null)
            return;


        Node current = head;
        Node prv = null;
        Node tmp = null;
        Node next1 = null;
        int val = 0;
        while (current != null)
        {
            prv = current;
            current = current.next;

            if (current.data == x || current.data == y)
            {
                if (current.data == x) val = y;
                else val = x;

                tmp = current;
                next1 = tmp.next;
                break;
            }
        }

        Node current2 = head;
        Node prv2 = null;
        Node tmp2 = null;
        Node next2 = null;
        while (current2 != null)
        {
            prv2 = current2;
            current2 = current2.next;

            if (current2.data == val)
            {
                tmp2 = current2;
                next2 = tmp2.next;
                break;
            }
        }

        prv.next = tmp2;
        tmp2.next = tmp;
        tmp.next = next2;
    }


    public void swapNodes2(int x, int y)
    {
        if (x == y) return;

        Node prevX = null, currX = head;
        while (currX != null && currX.data != x)
        {
            prevX = currX;
            currX = currX.next;
        }

        Node prevY = null, currY = head;
        while (currY != null && currY.data != y)
        {
            prevY = currY;
            currY = currY.next;
        }

        if (currX == null || currY == null)
            return;


        if (prevX != null)
            prevX.next = currY;
        else //otherwise it is the headnode, make y the new head  
            head = currY;

        if (prevY != null)
            prevY.next = currX;
        else //otherwise it is the headnode, make x the new head  
            head = currX;

        // Swap next pointers  
        Node temp = currX.next;
        currX.next = currY.next;
        currY.next = temp;
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
        llist.push(7);
        llist.push(6);
        llist.push(5);
        llist.push(4);
        llist.push(3);
        llist.push(2);
        llist.push(1);


        Console.Write("\n Linked list before calling swapNodes() ");
        llist.printList();

        llist.swapNodes2(4, 3);

        Console.Write("\n Linked list after calling swapNodes() ");
        llist.printList();

        Console.Read();
    }
}
