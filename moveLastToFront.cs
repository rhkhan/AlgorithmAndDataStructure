public void moveLastToFront(){
 if(head==null || head.next==null)
  return;
  
 Node current=head;
 Node prev=null;
 while(current.next!=null){
  prev=current;
  current=current.next;
 }
 prev.next=null;
 current.next=head;
 head=current // set new head
}
