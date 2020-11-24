void deleteNodeWithoutHead(Node pos) //pos is the node to be deleted
{
  if(pos==null)
   return;
  Node current=pos;
  while(current!=null)
  {
    if(current!=pos)
      current=current.next;
    else
    {
     if(current.next!=null)
     {
       current.data=current.next.data
       current.next=current.next.next;
     }
     else
     {
       current=null; //if the node to be deleted is the last node, then we can set it to null and return
       return;
     }  
    }
  }
}
