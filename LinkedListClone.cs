// Approach 1: using O(1) space, O(2n) time
static Node clone(Node start)
{
  Node current=start, temp=null;
  
  while(current!=null)
  {
    temp=current.next;
    current.next=new Node(current.data);
    current.next.next=temp;
    curren=temp;
  }
  
  current=start;
  while(current!=null) // adjusting the random pointer
  {
    if(current.next!=null)
     current.next.random=(current.random!=null)?current.random.next:current.random;
     
     current=(current.next!=null)?current.next.next:current.next;
  }
  
  Node original=start, copy=start.next;
  temp=copy;
  while(original!=null && copy!=null) //seperating the original and copy list;
  {
    copy.next=copy.next.next;
    original.next=original.next.next;
    
    original=original.next;
    copy=copy.next;
  }
  return temp;
}

Approach 2: O(n) space and O(n) time

public Node clone()
{
 Node originalCurr=this.head, cloneCurr=null;
 Dictionary<Node,Node> map=New Dictionary<Node,Node>();
 
 while(originalCurr!=null)
 {
  cloneCurr=new Node(originalCurr.data);
  map.add(originalCurr,cloneCurr);
  originalCurr=originalCurr.next;
 }
 
 originalCurr=this.head;
 while(originalCurr!=null)
 {
  cloneCurr=map[originalCurr];
  cloneCurr.next=map[originalCurr.next];
  cloneCurr.random=map[originalCurr.random];
  originalCurr=originalCurr.next;
 }
 
 return map[this.head];
}


public static void Main(String[] args)  
{  
    Node start = new Node(1);  
    start.next = new Node(2);  
    start.next.next = new Node(3);  
    start.next.next.next = new Node(4);  
    start.next.next.next.next = new Node(5);  
  
    // 1's random points to 3  
    start.random = start.next.next;  
  
    // 2's random points to 1  
    start.next.random = start;  
  
    // 3's and 4's random points to 5  
    start.next.next.random = start.next.next.next.next;  
    start.next.next.next.random = start.next.next.next.next;  
  
    // 5's random points to 2  
    start.next.next.next.next.random = start.next;  
  
    Console.WriteLine("Original list : ");  
    print(start);  
  
    Console.WriteLine("Cloned list : ");  
    Node cloned_list = clone(start);  
    print(cloned_list);  
}
