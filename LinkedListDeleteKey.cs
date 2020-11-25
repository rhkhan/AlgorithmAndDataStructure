//Approach 1:
Node deleteKey(Node head,int key)
{
  Node current=head;
  Node prev=new Node(0),next=null;
  while(current!=null)
  {
    if(current.data==key)
    {
     current=current.next;
     //head=current;
    }
    else
    {
      prev.next=current;
      current=current.next;
    }
  }
   head=prev;
   return head.next;
}

//Approach 2:
void deleteKey(int key)
    {
        // Store head node
        Node temp = head, prev = null;
 
        // If head node itself holds the key
        // or multiple occurrences of key
        while (temp != null && temp.data == key)
        {
            head = temp.next; // Changed head
            temp = head; // Change Temp
        }
 
        // Delete occurrences other than head
        while (temp != null) 
        {
            // Search for the key to be deleted,
            // keep track of the previous node
            // as we need to change 'prev->next'
            while (temp != null && temp.data != key) 
            {
                prev = temp;
                temp = temp.next;
            }
 
            // If key was not present in linked list
            if (temp == null)
                return;
 
            // Unlink the node from linked list
            prev.next = temp.next;
 
            // Update Temp for next iteration of outer loop
            temp = prev.next;
        }
    }
