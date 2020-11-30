Public class LinkedListNode
{
  int data;
  LinkedListNode next;
  public LinkedListNode(int d)
  {
   data=d;
   next=null;
  }
}

public class BinaryTreeNode
{
  int data;
  BinaryTreeNode left,right;
  public BinaryTreeNode(int d)
  {
    data=d;
    left=right=null;
  }
}

public class BinaryTree
{
  LinkedListNode head;
  BinaryTreeNode root;
  
  public void push(int d)
  {
    LinkedListNode new_node=new LinkedListNode(d);
    new_node.next=head;
    head=new_node; 
  }
  
  public BinaryTreeNode covertToBinaryTree(BinaryTreeNode node)
  {
    Queue<BinaryTreeNode> queue=new Queue<BinaryTreeNode>();
    node=new BinaryTreeNode(head.data); // first node of the linkedlist is the root node of the binary tree
    queue.Enqueue(node)
    head=head.next;
    while(head!=null) // forward the list untill null
    {
      BinaryTreeNode parent=queue.Dequeue();
      
      BinaryTreeNode leftchild=new BinaryTreeNode(head.data);
      queue.Enqueue(leftchild);
      head=head.next;
      if(head!=null)
      {
       BinaryTreeNode rightchild=new BinaryTreeNode(head.data);
       queue.Enqueue(rightchild);
       head=head.next;
      }
      
      parent.left=leftchild;
      parent.right=rightchild;
    }
  }
  
   public void inorderTraversal(BinaryTreeNode node)  
    { 
        if (node != null)  
        { 
            inorderTraversal(node.left); 
            Console.Write(node.data + " "); 
            inorderTraversal(node.right); 
        } 
    }
    
    public static void Main()  
    { 
        BinaryTree tree = new BinaryTree(); 
          
        /* Last node of Linked List */
        tree.push(36);  
        tree.push(30); 
        tree.push(25); 
        tree.push(15); 
        tree.push(12); 
          
        /* First node of Linked List */
        tree.push(10);  
        BinaryTreeNode node = tree.covertToBinaryTree(tree.root); 
  
        Console.WriteLine("Inorder Traversal of the"+ 
                        " constructed Binary Tree is:"); 
        tree.inorderTraversal(node); 
    } 
    
}
