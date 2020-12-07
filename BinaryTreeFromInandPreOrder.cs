    public class Node { 
    public char data; 
    public Node left, right; 
  
    public Node(char item) 
    { 
        data = item; 
        left = right = null; 
    } 
} 

public class Program
{
    public static void Main(string[] args) 
    { 
        Program tree = new Program(); 
        char[] inArr = new char[] { 'D', 'B', 'E', 'A', 'F', 'C' }; 
        char[] pre = new char[] { 'A', 'B', 'D', 'E', 'C', 'F' }; 
        int len = arr.Length; 
        tree.root = tree.buildTree(inArr, pre, 0, len - 1); 
  
        // building the tree by printing inorder traversal 
        Console.WriteLine("Inorder traversal of "
                          + "constructed tree is : "); 
        tree.printInorder(tree.root); 
    }
    
    public Node root;
    public static int preIndex=0;
    
    public virtual Node buildTree(char[] inArr,char[] pre, int inStart,int inEnd)
    {
      if(inStart>inEnd)
        return null;
      
      Node tNode=new Node(pre[preIndex++]);
      if(inStart==inEnd)
       return tNode;
       
      int index=serach(inArr,inStart,inEnd,tNode.data);
      
      tNode.left=buildTree(inArr,pre,inStart,index-1);
      tNode.right=buildTree(inArra,pre,index+1,inEnd);
      
      return tNode;
    }
    
    public int search(char[] inArr,int inStart,int inEnd, char value)
    {
      for(int i=inStart;i<=inEnd;i++)
      {
        if(inArra[i]==value)
         return i;
      }
      
      return i;
    }
    
}    
    
    
