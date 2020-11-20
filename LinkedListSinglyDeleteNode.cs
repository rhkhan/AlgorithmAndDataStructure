Node delete(Node head,int data){
  if(head==null || head.next==null)
   return;
  Node prev=head;
  Node current=head.next;
  while(current!=null && current.data!=data){
     current=current.next;
     prev=prev.next;
  }
  prev.next=current.next;
  
  return head;
}
