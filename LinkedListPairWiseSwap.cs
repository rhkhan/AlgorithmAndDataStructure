void pairWiseSwap()
{
  Node temp=head;
  while(temp!=null && temp.next!=null)
  {
   int val=temp.data;
   temp.data=temp.next.data;
   temp.next.data=val;
   temp=temp.next.next;
  }
}
