static Boolean isBST(Node root, Node l, Node r)  
{  
    if (root == null)  
        return true;  
  
    if (l != null && root.data <= l.data)  
        return false;  
    if (r != null && root.data >= r.data)  
        return false;  
  
    return isBST(root.left, l, root) &&  isBST(root.right, root, r);  
}  

// Driver code 
public static void Main(String []args) 
{  
    Node root = newNode(3);  
    root.left = newNode(2);  
    root.right = newNode(5);  
    root.left.left = newNode(1);  
    root.left.right = newNode(4);  
  
    if (isBST(root,null,null))  
        Console.Write("Is BST");  
    else
        Console.Write("Not a BST");  
} 
