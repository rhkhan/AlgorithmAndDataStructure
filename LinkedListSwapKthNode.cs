/*
Approach1: (swapping data only)
 - get the length of the list, say n is the length of the list
 - declare two variables frontPos and backPos
 - set frontPos=k, backPos=n-k+1
 - set variable counter=1
 - traverse the list and increment the counter
 - current=head
 - if counter=frontPos, put the node in temp
 - if counter=backpos, swap the data betwen temp node and current node
 - return head
*/

/* 
Approach2: swapping pointers
*/

public class LinkedList
{
  Node head;
  
  void push(int data)
  {
    Node new_node=new Node(data);
    new_node.next=head;
    head=new_node;
  }
  
  int countNodes();
  {
    Node current=head;
    int count=0;
    while(current!=null)
    {
     count++;
     current=current.next;
    }
    return count;
  }
  
  void swapKthNode(int k)
  {
    int n=countNodes();
    if(n<k)
     return;
    if(frontPos==backPos)
     return;
    
    Node x=head;
    Node x_prev=null;
    for(int i=1;i<k;i++)
    {
     x_prev=x;
     x=x.next;
    }
    
    Node y=head;
    Node y_prev=null;
    for(int i=1;i<backPos;i++)
    {
     y_prev=y;
     y=y.next;
    }
    
    if(x_prev!=null)
    {
     x_prev.next=y;
    }
    if(y_prev!=null)
    {
     y_prev.next=x;
    }
    
    // swap or adjust the x and y next pointer
    Node temp=x.next;
    x.next=y.next;
    y.next=temp;
    
    if(k==1)
     head=y;
    if(k==n)
     head=x;
  }
}
