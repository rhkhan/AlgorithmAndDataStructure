 void sortedInsert(Node new_node)  
    {  
        Node current = head;  
        if (current == null)  
        {  
            //set the next of new_node to new_node to make it circular
            // and set the new_node as the head node
            new_node.next = new_node;  
            head = new_node;  
  
        }  
        else if (current.data >= new_node.data)  
        {  
            /* If new_node data is smaller then
                current/root node then traverse
                to add the new_node at first position
                And set the new_node as head node*/
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
