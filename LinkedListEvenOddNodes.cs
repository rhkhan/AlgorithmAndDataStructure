/*
Approach:
1. Traverse the list
2. declare two temp list such as temp1 and temp2 for even and odd respectively
3. if event is found then add in temp1 list and forward main list and temp1 list
4. if odd is found then add in temp2 list and forwared main list and temp2 list
5. finaly merge odd list to the event list and return the final list
*/

public Node segregateEvenOdd(Node head){
 Node temp1=null;
 Node temp2=null;
 Node current=head;
 while(current!=null){
   if(current.data%2==0)
   {
     if(temp1==null)
      temp1=new Node(current.data);
     else
     {
       while(temp1!=null)
       {
        temp1=temp1.next;
       }
       temp1.next=new Node(current.data);
     }
   }
   else
   {
      if(temp2==null)
      temp2=new Node(current.data);
     else
     {
       while(temp2!=null)
       {
        temp2=temp2.next;
       }
       temp2.next=new Node(current.data);
     }
   }
   current=current.next;
 }
  // finaly merge the even and odd
  while(temp1.next!=null){
    temp1=temp1.next;
  }
  temp1.next=temp2;
  return temp1;
}
