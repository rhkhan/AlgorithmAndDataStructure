class LinkedList
{
  Node head;
  
  class Node
  {
    int data;
    Node right,down;
    Node(int d)
    {
      this.data=d;
      right=down=null;
    }
  } // End Node class
 
  public Node push(Node head_ref,int data)
  {
    Node new_node=new Node(data);
    new_node.down=head_ref;
    head_ref=new_node;
    return head_ref;
  }
  
  public Node merge(Node a,Node b)
  {
    Node result=null;
    if(a==null) return b;
    if(b==null) return a;
    if(a.data<b.data)
    {
      result=a;
      result.down=merge(a.down,b);
    }
    else
    {
      result=b;
      result.down=merge(a,b.down);
    }
   
    result.right=null;
    return result;
  }
  
  public Node flatten(Node root)
  {
    if(root==null || root.next==null)
    {
      return root;
    }
    
    root.right=flatten(root.right);
    root=merge(root,root.right);
    
    return root;
  }
  
  void printList()
  {
    Node current=head;
    while(current!=null);
    {
      Console.Write(current.data+" ")
      current=current.down;
    }
    Console.WriteLine();
  }
  
  public static void main(String args[])
  {
    LinkedList L= new LinkedList();
    L.head=L.push(L.head,30);
    L.head=L.push(L.head,8);
    L.head=L.push(L.head,7);
    L.head=L.push(L.head,5);
    
    L.head.right=L.push(L.head.right,20);
    L.head.right=L.push(L.head.right,10);
    
    L.head.right.right = L.push(L.head.right.right, 50); 
    L.head.right.right = L.push(L.head.right.right, 22); 
    L.head.right.right = L.push(L.head.right.right, 19); 
  
    L.head.right.right.right = L.push(L.head.right.right.right, 45); 
    L.head.right.right.right = L.push(L.head.right.right.right, 40); 
    L.head.right.right.right = L.push(L.head.right.right.right, 35); 
    L.head.right.right.right = L.push(L.head.right.right.right, 20); 
    
    L.head=L.flatten(L.head);
    L.printList();
  }
 
}
