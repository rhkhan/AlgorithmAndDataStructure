/*
Approach 1:
 - Do in-order traversal of tree
 - make the first node of the tree as the head of the list
 - traverse the tree until the left and right child of a node is null
 - if node is the head then set the next node
 - if node is not the head then set next and prev pointer
 - if node is last the set the next to head and prev to the previous node
*/


//Approach 2:
public class Tree
{
  public Node binaryTreetoCDLL(Node root)
  {
   if(root==null)
    return null;

    Node leftList=binaryTreetoCDLL(root.left);
    Node rightList=binaryTreetoCDLL(root.right);

    root.left=root.right=root;

    return concatenate(concatenate(leftList,root),rightList));
  }

  public Node concatenate(Node leftList,Node rightList)
  {
    if(leftList==null)
     return rightList;
    if(rightList==null)
     return leftList;

     Node leftLast=leftList.left; // leftList previous pointer points to the last node of the left list
     Node rightLast=rightList.left;

     //concating
     leftLast.right=rightList;
     rightList.left=leftLast;

     //adjusting the pointer for the circular pointing
     leftList.left=rightLast;
     rightLast.right=leftList

     return leftList;
  }
}
public class Program 
{ 
    public static void Main(string[] args) 
    { 
        // Build the tree  
        Tree tree = new Tree(); 
        tree.root = new Node(10); 
        tree.root.left = new Node(12); 
        tree.root.right = new Node(15); 
        tree.root.left.left = new Node(25); 
        tree.root.left.right = new Node(30); 
        tree.root.right.left = new Node(36); 
  
        // head refers to the head of the Link List  
        Node head = tree.binaryTreetoCDLL(tree.root); 
    } 
} 
