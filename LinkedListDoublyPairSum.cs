// Solution: O(n^2)
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
} // O(n^2) solution


// Solution: O(n)
public void pairSum( Node head, int x)  
    {  
        Node first = head;  
        Node second = head;  
        while (second.next != null)  
            second = second.next;  
   
        bool found = false;  
        while (first != null && second != null &&  first != second && second.next != first)  
        {  
            if ((first.data + second.data) == x)  
            {  
                found = true;  
                Console.WriteLine( "(" + first.data +  ", "+ second.data + ")" );  
  
                first = first.next;  
                second = second.prev;  
            }  
            else
            {  
                if ((first.data + second.data) < x)  
                    first = first.next;  
                else
                    second = second.prev;  
            }  
        }  
        if (found == false)  
            Console.WriteLine("No pair found");  
    }  //Time compexity: O(n), Auxiliary space : O(1)
