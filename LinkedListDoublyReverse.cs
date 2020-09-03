 void reverse()  
    {  
        Node temp = null;  
        Node current = head;  
  
        while (current != null)  
        {  
            temp = current.prev;  
            current.prev = current.next;  
            current.next = temp;  
            current = current.prev;  
        }  
  
        /* Before changing head, check for 
          the cases like empty list and 
         list with only one node */
        if (temp != null) 
        {  
            head = temp.prev;  
        }  
    }
