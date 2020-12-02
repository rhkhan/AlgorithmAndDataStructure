public void sort(Node start,Node end)
{
  if(start==end)
   return;
   
  Node pivotPrev=partition(start,end)
  sort(start,pivotPrev);
  
  //if pivot is not null and start is same as pivot then pick from next of pivot
  if(pivotPrev!=null && pivotPrev==start)
   sort(start,pivotPrev.next);
  else if(pivotPrev!=null && pivotPrev.next!=null)
   sort(pivotPrev.next.next,end);
}

public Node partition(Node start,Node end)
{
  if(start==end || start==null || end==null)
   return start;
   
   Node pivotPrev=start;
   Node current= start;
   int pivot=end.data;
   
   int temp;
   while(start!=end)
   {
     if(start.data<pivot)
     {
       pivotPrev=current;
       temp=current.data;
       current.data=start.data;
       start.data=temp;
       current=current.next;
     }
     start=start.next;
   }
   temp=current.data;
   current.data=pivot;
   end.data=temp;
   
   return pivotPrev;
}
