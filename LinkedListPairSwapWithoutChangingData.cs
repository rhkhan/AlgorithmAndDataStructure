using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPairWiseSwap
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

        public Node head;
        public void swapPairWise()
        {
            Node current = head;
            Node prev = null;
            int counter = 1;
            Node resTemp = null;
            int pos = 1;
            while (current != null && current.next != null) // check null of two nodes such as: current and it's next node
            {
                counter++;
                // to walk through the nodes set prev to current and current to next
                prev = current; // set current to prev
                current = current.next; // and set next to current
                if (counter % 2 == 0) // if two nodes i.e. pair of nodes is considered
                {
                    if (current.next == null) // for the even number of nodes the last current node will have no node after that, i.e current node is tha last
                    {
                        // swap the last two nodes
                        Node tmp = current; // put current which is last to temp
                        tmp.next = prev; // set node which is before last node as the next of the current node
                        prev.next = null; // as prev node will be the last node
                        current = tmp; // set current to the newly swapped sequence

                    }
                    else // for the odd number of nodes
                    {
                        // swap current and prev node
                        prev.next = current.next; // set current's next node to the prev's next node
                        current.next = prev; // current node will come before the prev node to finish the swap operation
                    }

                    if (resTemp == null)
                        resTemp = current; //initialize new resTemp with current
                    else
                    {
                        int i = 1;
                        pos *= 2; // every time 2 nodes will be added to proceed to the next
                        var h = resTemp;
                        while (h.next != null && i<pos) // proceed untill newly added two nodes are passed through
                        {
                            i++;
                            h = h.next;
                        }
                        
                        h.next = current; // add new current swapped nodes to the next after proceeding to the end of resultTemp
                        //dd.next.next = current;

                    }


                    current = current.next; // Finally proceed to the next to nodes to be considered
                }

            }

            head = resTemp; // finally set head with the new restTemp;
        }

        public void printList()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
        }

        public void push(int data)
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

            /* Created Linked List 1->2->3->4->5 */
            //llist.push(6);
            llist.push(5);
            llist.push(4);
            llist.push(3);
            llist.push(2);
            llist.push(1);

            Console.WriteLine("Linked List before calling pairWiseSwap() ");
            llist.printList();
            Console.WriteLine();

            llist.swapPairWise();

            Console.WriteLine("Linked List after calling pairWiseSwap() ");
            llist.printList();
            Console.WriteLine();

            Console.Read();

        }
    }
}
