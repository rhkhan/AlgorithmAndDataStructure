public Node mirror(Node root) // recursive method
{
  if(root==null)
   return null;
   
   Node left=mirror(root.left);
   Node right=mirror(root.right);
   
   root.left=right;
   root.right=left;
   
   return root
}

public void mirror(Node root) // using level order traversal 
{
  if(root==null)
   return;
  
  Queue<Node> queue=new Queue<Node>();
  queue.Enqueue(root);
  
  while(queue.Count!=0)
  {
    Node current=queue.Dequeue();
    
    //swap left and right nodes
    Node temp=current.left;
    current.left=current.right;
    current.right=temp;
    
    if(current.left!=null)
      queue.Enqueue(current.left);
    if(current.right!=null)
      queue.Enqueue(current.right);
  }
}
