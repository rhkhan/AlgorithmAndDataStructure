using system;

public class Node
{
  public int data;
  public Node left,right;
  
  public Node(int data)
  {
    this.data=data;
    left=right=null;
  }
}

public class Index
{
  public int index;
}

public class Program
{
  public virtual Node buildTree(int[] inArr,int[] postArr, int inStart, int inEnd, Index pIndex)
  {
    if(inStart>inEnd)
     return null;
     
     Node tNode=new Node(postArr[pIndex.index--]);
     if(inStart==inEnd)
       return tNode;
     
     int pos=searchInArray(inArr,inStart,inEnd,tNode.data);
     
     tNode.right=(inArr,postArr,pos+1, inEnd,pIndex);
     tNode.left=(inArr,postArr,inStart,pos-1,pIndex);
     
     return tNode;
  }
  
  public int searchInArray(int[] inArr,int start,int end, int value)
  {
    for(int i=start;i<=end;i++)
    {
      if(inArr[i]==value)
        break;
    }
    return i;
  }
  
  public static void Main(string[] args)
  {
    Program tree=new Program();
    int[] inArr = new int[] {4, 8, 2, 5, 1, 6, 3, 7};
    int[] post = new int[] {8, 4, 5, 2, 6, 7, 3, 1};
    int n=inArr.Length;
    Index pIndex=new Index();
    pIndex.index=n-1;
    Node root=buildTree(inArr,postArr,0,n-1,pIndex);
  }
}
