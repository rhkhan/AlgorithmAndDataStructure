Static void insert(Node node, int key)
{
  if(node==null)
   node=new Node(key);
   return;
   
  Queue<Node> queue=new Queue<Node>();
  queue.Enqueue(Node);
  
  while(queue.Count!=0)
  {
    node=queue.Dequeue();
    if(node.left==null)
    {
      node.left=new Node(node);
      break;
    }
    else
      queue.Enqueue(node.left);
      
    if(node.right==null)
    {
      node.right=new Node(node);
      break;
    }
    else
      queue.Enqueue(node.right);
  }
}

/*
  Delete operation steps:
  -> Starting at root, find the deepest and rightmost node in binary tree and node which we want to delete
  -> Replace the deepest rightmost node's data with node to be deleted
  -> Then delete the deepest rightmost node
*/

static void delete(Node root, int key)
{
   if(root==null) // if tree is empty then return;
    return;
   if(root.left==null && root.right==null)
   {
     if(root.data==key) // if key is the root node then return, because root cannot be deleted
      return;
     else
      return;
   }
   
   Queue<Node> queue=new Queue<Node>();
   queue.Enqueue(root);
   Node temp, keyNode=null;
   
   while(queue.Count!=0)
   {
     temp=queue.Dequeue();
     if(temp.data==key)
     {
       keyNode=temp; 
     }
     if(temp.left!=null)
       queue.Enqueue(temp.left);
     if(temp.right!=null)
       queue.Enqueue(temp.right);
   }
   
   if(keyNode!=null)
   {
     //deleteDepestNode(root,temp);
     if(keyNode==temp)
      temp=null;
     else
     {
       keyNode.data=temp.data;
       temp=null;
     }
     
   }
}

static void deleteDepestNode(Node root,Node delNode)
{
  Queue<Node> queue=new Queue<Node>();
  queue.Enqueue(root);
  Node temp=null;
  while(queue.Count!=0)
  {
    temp=queue.Dequeue();
    if(temp==delNode)
    {
      temp=null;
      return;
    }
    if(temp.right!=null)
    {
      if(temp.right==delNode)
      {
        temp.right==null;
        return;
      }
      else
       queue.Enqueue(temp.right);
    }
    if(temp.left!=null)
    {
      if(temp.left==delNode)
      {
        temp.left==null;
        return;
      }
      else
       queue.Enqueue(temp.left);
    }
  }
}

