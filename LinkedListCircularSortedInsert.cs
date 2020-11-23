 void sortedInsert(Node new_node)  
    {  
        Node current = head;  
        if (current == null)  
        {  
            new_node.next = new_node;  
            head = new_node;  
  
        }  
        else if (current.data >= new_node.data)  
        {  
            /* If value is smaller than 
                head's value then we need 
                to change next of last node */
            while (current.next != head)  
                current = current.next;  
  
            current.next = new_node;  
            new_node.next = head;  
            head = new_node;  
        }  
        else
        {  
            /* Locate the node before  
            the point of insertion */
            while (current.next != head &&  
                current.next.data < new_node.data)  
                current = current.next;  
  
            new_node.next = current.next;  
            current.next = new_node;  
        }  
    }  
