static int minLevelSumResult(Node root)
{
  if(root==null)
   return 0;
  Queue<Node> queue=new Queue<Node>();
  int sum=0;
  bool isMinLevel=false;
  queue.Enqueue(root);
  
  while(!isMinLevel)
  {
    int queueSize=queue.Count;
    while(queueSize-->0)
    {
      Node temp=queue.Dequeue();
      if(tmp.left==null && temp.right==null)
      {
        sum+=temp.data;
        isMinLevel=true;
      }
      if(temp.left!=null)
       queue.Enqueue(temp.left);
      if(temp.right!=null)
       queue.Enqueue(temp.right);
    }
  }
  return sum;
}
