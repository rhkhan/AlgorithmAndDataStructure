using system;

public class Program
{
   public static void Main(string[] args)
   {
    string expression="a?b?c:d:e";
    BinaryTree tree=new BinaryTree();
    char[] expressionArr=expression.ToCharArray();
    Node root=tree.convertExpression(expressionArr,0);
    tree.printTree(root);
   }   
}

public class Node
{
    public char data; 
    public Node left, right; 
  
    public Node(char item) 
    { 
        data = item; 
        left = null; 
        right = null; 
    } 
}

public class BinaryTree
{
  public Node convertExpression(char[] expArr,int i)
  {
    if(i>=expArr.Length)
     return null;
     
    Node root=new Node(expArr[i]);
    i++;
    
    if(i<expArr.Length && expArr[i]=='?')
      root.left=convertExpression(expArr,i+1);
    else if(i<expArr.Length)
      root.right=convertExpression(expArr,i+1);
    
    return root;
  }
  
  public void printTree(Node root)
  {
     if (root == null) 
        { 
            return; 
        } 
        Console.Write(root.data + " "); 
        printTree(root.left); 
        printTree(root.right); 
  }
}
