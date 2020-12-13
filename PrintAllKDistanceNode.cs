public virtual int printKDistanceNode(Node node, Node target,int k)
{
  if(root==null)
   return -1;
   
   if(node==target)
   {
    printKDistanceDown(node,k);
    return 0;
   }
    
   int dl=printKDistanceNode(node.left,target,k)
   if(dl!=-1)
   {
     if(dl+1==k)
     {
       Console.Write(node.data); 
       Console.WriteLine(""); 
     }
     
    else
    {
      printKDistanceNodeDown(node.right,k-dl-2);
    }
    return dl+1;
   }
   
       int dr = printkdistanceNode(node.right, target, k); 
  if (dr != -1) 
  { 
     if (dr + 1 == k) 
     {   
         Console.Write(node.data); 
         Console.WriteLine(""); 
      } 
      else
      { 
        printkdistanceNodeDown(node.left, k - dr - 2); 
      } 
    return 1 + dr; 
  } 
 return -1; 
}
