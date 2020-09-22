using System; 
  
public class Node 
{ 
    public int data; 
    public Node left, right; 
    public Node(int item) 
    { 
        data = item; 
        left = right = null; 
    } 
} 

class BinaryTree 
{ 
    public Node root; 
      
    public BinaryTree() 
    { 
        root = null; 
    } 
    
    public virtual int height(Node root) 
    { 
        if (root == null) 
        { 
            return 0; 
        } 
        else
        { 
            int lheight = height(root.left); 
            int rheight = height(root.right); 

            if (lheight > rheight) 
            { 
                return (lheight + 1); 
            } 
            else
            { 
                return (rheight + 1); 
            } 
        } 
    } 
    
    public virtual void printLevelOrder() 
    { 
        int h = height(root); 
        int i; 
        for (i = 1; i <= h; i++) 
        { 
            printGivenLevel(root, i); 
        } 
    } 
    
    public void printGivenLevel(Node root,int level)
    {
       if(root==null)
        return;
       if(level==1)
        Console.Write(root.data + " "); 
       else if(level > 1)
       {
         printGivenLevel(root.left,level-1);
         priintGivenLevel(root.right,level-1);
       }
    }
    
    public static void Main(string[] args) 
    { 
        BinaryTree tree = new BinaryTree(); 
        tree.root = new Node(1); 
        tree.root.left = new Node(2); 
        tree.root.right = new Node(3); 
        tree.root.left.left = new Node(4); 
        tree.root.left.right = new Node(5); 

        Console.WriteLine("Level order traversal " +  
                              "of binary tree is "); 
        tree.printLevelOrder(); 
    } 
} 
    
