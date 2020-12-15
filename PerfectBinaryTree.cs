public bool checkPerfect(Node root)
{
  if(root==null)
   return true;
  if(root.left==null && root.right==null)
   return true;
  if(root.left==null || root.right==null)
  return false;
  
  return checkPerfect(root.left) && checkPerfect(root.right);
}


// Alternate method: finding depth and then check if leaves are at the same level

static int findDepth(Node root)
{
 int d=0;
 while(root!=null);
 {
   root=root.left;
   d++;
 }
 return d;
}

static bool isPerfect(Node root)
{
  int d=findDepth(root);
  return checkIsPerfect(root,d,0);
}

static bool checkIsPerfect(Node root,int d,int level)
{
  if(root==null) //An empty tree is perfect
   return true;
  if(root.left==null && root.right==null) //If leaf node then it's depth must be same as all other leaves
   return d==level+1;
  if(root.left==null || root.right==null) // If one child is empty
   return false;
  return checkIsPerfect(root.left,d,level+1) && checkIsPerfect(root.right,d,level+1);
}
