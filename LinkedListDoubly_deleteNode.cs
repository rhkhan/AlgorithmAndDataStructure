using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList_deleteNode
{
    class Program
    {
        Node head;

        public class Node
        {
            public int data;
            public Node prev;
            public Node next;
            public Node(int d) { data = d; }
        }

        public void push(int new_data) // inserting node at front
        {
            Node new_Node = new Node(new_data);
            new_Node.next = head;
            new_Node.prev = null;
            if (head != null)
                head.prev = new_Node;
            head = new_Node;
        }

        public void printlist(Node node)
        {

            while (node != null)
            {
                Console.Write(node.data + " ");
                node = node.next;
            }

            Console.WriteLine();
        }

        void deleteNode(Node del,int key)
        {

            Node Tprev = null;
            Node current = head;

            if (current == null)
                return;
            

            while (current != null)
            {
                if (current.data == key) // if key is found
                {
                    Tprev = current.prev;
                    if (current.next == null) // if last node
                    {
                        Tprev.next = null;
                    }
                    else
                    {
                        current = current.next;
                        current.prev = Tprev;
                        if (Tprev != null) // if middle node
                        {
                            Tprev.next = current;
                            //head = current;
                        }
                        else // if first node then update head with the current node
                        {
                            head = current;
                        }
                    }
                    
                    //head = current;
                    return;
                }
                else // proceed forward to search for the key
                {
                    Tprev = current;
                    current = current.next;
                }
            }
        }


        static void Main(string[] args)
        {
            // Start with the empty list 
            Program dll = new Program();
            dll.push(2);
            // 4->2->NULL 
            dll.push(4);
            // 8->4->2->NULL 
            dll.push(8);
            // 10->8->4->2->NULL 
            dll.push(10);

            Console.Write("Created DLL is: ");
            dll.printlist(dll.head);

            // Deleting first node 
            dll.deleteNode(dll.head,2);

            // List after deleting first node 
            // 8->4->2 
            Console.Write("\nList after deleting last node: ");
            dll.printlist(dll.head);

            // Deleting middle node from 8->4->2 
            dll.deleteNode(dll.head, 8);

            Console.Write("\nList after Deleting middle node: ");
            dll.printlist(dll.head);

            dll.deleteNode(dll.head, 10);
            Console.Write("\nList after Deleting first node: ");
            dll.printlist(dll.head);

            Console.Read();
        }
    }
}
