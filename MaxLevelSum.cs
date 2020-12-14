public static int maxLevelSumResult(Node root)
{
  if(root==null)
   return 0;
  int result=root.data;
  Queue<Node> queue=new Queue<Node>();
  queue.Enqueue(root);
  
  while(queue.Count>0)
  {
    int queueSize=queue.count;
    int sum=0;
    while(count-->0)
    {
      Node temp=queue.Pop();
      sum+=temp.data;
      if(temp.left!=null)
       queue.Enqueue(temp.left);
      if(temp.right!=null)
       queue.Enqueue(temp.right);
    }
    result=Math.max(sum,result);
  }
  
  return result;
}
