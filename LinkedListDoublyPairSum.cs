public void printSumPairs(Node head,int x)
{
  if(head==null || head.next==null)
    return;
  
  while(head.next!=null)
  {
    if(head.data>=x)
      head=head.next;
    else
    {
      Node current=head;
      while(current.next!=null)
      {
        current=current.next;
        if((head.data+current.data)==x)
        {
          Console.WriteLine(head.data+","+current.data);
        }
      } // end inner while loop
    }
  } // end outer while loop  
}

// O(n^2) solution
