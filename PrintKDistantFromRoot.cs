public void printKDistant(Node root,int k)
{
  if(root==null)
   return;
  if(k==0)
  {
    Console.writ(root.data+" ");
    return;
  }
  else
  {
    printKDistant(root.left,k-1);
    printKDistant(root.right,k-1);
  }
}
