/*
  Approach 1: O(n) space using array
  
store the alternate nodes in an array. reverse the array
append the array content at the end of the list

Node current=head
//int count=1;
while(current!=null)
{
  //count++;
  if(current.next!=null)
   current.next=current.next.next;

   current=current.next;
}

current.next=appned the reversed nodes at the end
*/

/* Approach 2: 
 - Maintain two list, one is for odd and another one is for even
 - reverse the even list
 - traverse the odd list and append the head of the even list to the last of the odd list
*/

public void reverseAlternateAppend(Node odd) // since head node is the odd positioned node
{
  if(odd==null || odd.next==null || odd.next.next==null) // nothing to reverse and append
   return;
   
   Node even=odd.next;
   
   Node a=odd;
   Node b=even;
   
   while(a!=null)
   {
     if(a.next!=null)
      a=a.next.next;
   }
   
   while(b!=null)
   {
     if(b.next!=null)
      b=b.next.next;
   }
   
   Node revB=reverse(even);
   
   a=odd;
   while(a.next!=null)
   {
     a=a.next;
   }
   a.next=revB;
}

public Node reverse(Node even)
{
  Node current=even;
  Node prev,next=null;
  while(current!=null)
  {
    next=current.next;
    current.next=prev;
    prev=current;
    current=next;
  }
  
  return even;
}

