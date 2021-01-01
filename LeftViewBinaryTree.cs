public class BinaryTree
{
  public Node root;
  public static int max_level=0;
  
  public virtual void printLeftView(Node root,int level) //Recursive way
  {
    if(root==null)
     return;
    if(level>max_level)
    {
       Console.write(root.data+" ");
       max_level=level;
    }
    printLeftView(root.left,level+1);
    printLeftView(root.right,level+1);
  }
  
  public virtual void printLeftViewIterative(Node root,int level) //Iterative using queue
  {
    if(root==null)
     return;
    Queue<Node> q=new Queue<Node>();
    queue.Enqueue(root);
    while(queue.Count>0)
    {
      int n=queue.Count;
      for(int i=1;i<=n;i++)
      {
        Node temp=queue.Dequeue();
        if(i==1) // first node of the current level
        {
         Console.Write(temp.data+" ");
        }
        if(temp.left!=null)
         queue.Enqueue(temp.left);
        if(temp.right!=null)
         queue.Enqueue(temp.right);
      }
    }
  }
  
  public static void Main()
  {
    printLeftView(root,1);
  }
}
