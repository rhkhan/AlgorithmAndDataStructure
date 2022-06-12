using system;

public class LinkedListDoubly{
      Node head;
      
      public class Node{
         Node next, prev;
         int data;
         public Node(int d){
          data=d;
          next=prev=null;
         }
      }
      
    public void push(int data){
      Node new_node=new Node(data);
      if(head==null)
       head=new_node;
      else{
       new_node.next=head;
       head.prev=new_node;
       new_node.prev=null;
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
        //Node result=null;
        if(a.data<=b.data){
         //result=a;
         a.next=sortedMerge(a.next,b);
         a.next.prev=a;
         a.prev=null;
         return a;
        }
        else{
         //result=b;
         b.next=sortedMerge(a,b.next);
         b.next.prev=b;
         b.prev=null;
         return b;
        }
   }
   
    Node mergeSort(Node h){
      if(h==null || h.next==null){
       return h;
      }
      Node middle=getMiddle(h);
      Node nextofmiddle=middle.next;
      nextofmiddle.prev=null;
      middle.next=null;

      Node left=mergeSort(h);
      Node right=mergeSort(nextofmiddle);

      Node sortedList=sortedMerge(left,right);
      return sortedList;
   }
  
    void print(Node node) 
    {  
        Node temp = node;  
        Console.WriteLine("Forward Traversal" +  
                          "using next pointer");  
        while (node != null)  
        {  
            Console.Write(node.data + " ");  
            temp = node;  
            node = node.next;  
        }  
        Console.WriteLine("\nBackward Traversal" + 
                            "using prev pointer");  
        while (temp != null)  
        {  
            Console.Write(temp.data + " ");  
            temp = temp.prev;  
        }  
    }  
    
   // Driver code 
    public static void Main(String[] args)  
    {  
  
        LinkedListDoubly list = new LinkedListDoubly();  
        list.head = new Node(10);  
        list.head.next = new Node(30);  
        list.head.next.next = new Node(3);  
        list.head.next.next.next = new Node(4);  
        list.head.next.next.next.next = new Node(20);  
        list.head.next.next.next.next.next = new Node(5);  
          
        Node node = null;  
        node = list.mergeSort(list.head);  
        Console.WriteLine("Linked list after sorting :");  
        list.print(node);  
        
        Console.Read();
    }  
    
  
}
