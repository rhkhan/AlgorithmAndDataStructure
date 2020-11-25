/*
 Approach:
  - Create a new linked list by reverse nodes of the linked upto k 
  - Create another linked list by reversing from k to the last
  - append both the first and second list
*/

/*
  - Reverse the first k nodes
  - recursively add the remaining nodes after k and append to the next of the first list
*/

Node reverse(Node head,int k)
{
  Node next,prev=null;
  Node current=head;
  int count=0;
  
  while(count<k && current!=null)
  {
   next=current.next;
   current.next=prev;
   prev=current;
   current=next;
   count++;
  }
  
  if(next!=null)
  {
    head.next=reverse(next,k);
  }
  
  return prev;
}
