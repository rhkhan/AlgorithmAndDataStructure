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
      
      Node lastNode(Node node){
          while(node.next!=null){
            node=node.next;
          }
          return node;
      }
      
      public void quicksort(Node head){
        Node last=lastNode(head);
        _quicksort(head,last);
      }
      
      public void _quicksort(Node low, Node high){
         if(low!=null && low!=high && low!=high.next){
           Node temp=partition(low,high);
           _quicksort(low,temp.prev);
           _quicksort(temp.next,high);
         }
      }
      
      public Node paritition(Node low,Node high){
        int x=high.data;
        int tmp;
        Node i=low.prev;
        for(Node j=low;j!=high;j=j.next){
          if(j.data<=x){
            i=(i==null)?low:i.next;
            tmp=j.data;
            j.data=i.data;
            i.data=temp;
          }
        }
        i=(i==null)?low:i.next;
        tmp=i.data;
        i.data=high.data;
        high.data=temp;
        return i;
      }
      
    public void printList(Node head)  
    {  
        while(head!=null){  
            Console.Write(head.data+" ");  
            head = head.next;  
        }  
    }  
      

    public void push(int new_Data)  
    {  
        Node new_Node = new Node(new_Data); /* allocate node */
        if(head==null) 
        {  
            head = new_Node;  
            return;  
        }  
        new_Node.next = head;  
        head.prev = new_Node;  
        new_Node.prev = null;  
        head = new_Node;  
    }  
      
    /* Driver code */
    public static void Main(String[] args){  
            LinkedListDoubly list = new LinkedListDoubly();  
              
              
            list.push(5);  
            list.push(20);  
            list.push(4);  
            list.push(3);  
            list.push(30);  
              
              
            Console.WriteLine("Linked List before sorting ");  
            list.printList(list.head);  
            Console.WriteLine("\nLinked List after sorting");  
            list.quickSort(list.head);  
            list.printList(list.head);  
    }  
    
      
}
