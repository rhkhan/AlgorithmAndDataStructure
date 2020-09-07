using system;

public class LinkedList{

  public class Node{
     public int data;
     public Node next;
     public Node(int d){
      this.data=d;
      this.next=null;
     }
  }
  
  public void push(int data){
    Node new_node=new Node(data);
    if(head==null)
     head=new_node;
    else{
     new_node.next=head;
     head=new_node;
    }
  }
  
  public Node getMiddle(Node head){
    Node fastptr=head, slowptr=head;
    while(fastptr!=null && fastptr.next!=null){
      slowptr=slowptr.next;
      fastptr=fastptr.next.next;
    }
    return slowptr;
  }
  
  Public Node sortedMerge(Node a, Node b){
   if(a==null)
    return b;
   if(b==null)
    return a;
    Node result=null;
    if(a.val<=b.val){
     result=a;
     result.next=sortedMerge(a.next,b);
    }
    else{
     result=b;
     result.next=sortedMerge(a,b.next);
    }
    return result;
  }
  
  public Node mergeSort(Node h){
    if(h==null || h.next==null){
     return h;
    }
    Node middle=getMiddle(h);
    Node nextofmiddle=middle.next;
    middle.next=null;
    
    Node left=mergeSort(h);
    Node right=mergeSort(nextofmiddle);
    
    Node sortedList=sortedMerge(left,right);
    return sortedList;
  }
  
   void printList(Node node) 
    { 
        while (node != null) { 
            Console.Write(node.data + " "); 
            node = node.next; 
        } 
    } 
    
  public static void Main(String[] args) 
    { 
  
        LinkedList li = new LinkedList(); 
        /*  
        * Let us create a unsorted linked list to test the functions  
        * created. The list shall be a: 2->3->20->5->10->15  
        */
        li.push(15); 
        li.push(10); 
        li.push(5); 
        li.push(20); 
        li.push(3); 
        li.push(2); 
  
        // Apply merge Sort 
        li.head = li.mergeSort(li.head); 
        Console.Write("\n Sorted Linked List is: \n"); 
        li.printList(li.head); 
    } 
    

}
