/*
   traverse the tree using level order traversal
   declare two variable named oddLevelSum and evelLevelSum
   update the oddLevelSum for all the odd leveled nodes and evenLevelSum for all the even leveled nodes
   calculate the difference and return the result
*/

public int oddEvenLevelDiff(Node root)
{
  if(root==null)
   return 0;
  Queue<Node> queue=new Queue<Node>();
  queue.Enqueue(root);
  int oddLevelSum,evenLevelSum=0;
  int level=1;
  while(queue.Count>0)
  {
    int queueSize=queue.Count;
    while(queueSize-->0)
    {
       Node tmp=queue.Dequeue();
       if(level%2==0)
        evenLevelSum+=tmp.data;
       else
        oddLevelSum+=tmp.data;
        
       if(tmp.left!=null)
        queue.Enqueue(tmp.left);
       if(tmp.right!=null)
        queue.Enqueue(tmp.right);
    }
      level++;
  }
  return oddLevelSum-evenLevelSum;
}
