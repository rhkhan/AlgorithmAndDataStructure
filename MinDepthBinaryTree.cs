public virtual int minimumDepth(Node root)
{
  if(root==null) //if tree is empty return 0
   return 0
  if(root.left==null && root.right==null) //if root is not empty but left and right is null then return 1
   return 1;
  if(root.left==null) //if left is empty then recur for right subtree
   return minimumDepth(root.right)+1;
  if(root.right==null) //if right is empty then recur for left subtree
   return minimumDepth(root.left)+1;
   
  return Math.Min(minimumDepth(root.left),minimumDepth(root.right))+1; // else pick the minimum of left and right subtree
}
