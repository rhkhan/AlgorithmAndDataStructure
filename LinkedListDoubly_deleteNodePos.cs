public void deleteNode(Node head, int pos){
  Node current=head;
  int count=1;
  if(count==pos)// delete first node. i.e. head node
   {
     head=head.next;
     head.next.prev=null;
     return;
   }
  while(current.next!=null)
  {
    count++;
    if(count==pos)
    {
      current.next=current.next.next;
      if(current.next!=null)
      {
        current.next.prev=current;
      }
      return;
    }
    
    current=current.next; // otherwise proceed forward
  }
}
